using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timeInMinutes = 3*60;
    public float dTime = 0;

    private Panel panel;
    public Text text;
    private float start_time = 99999999999f;


    public int maxfull = 100;
    public int full;

    public float eatCountdown = 0.0f;

    public List<ScreenLine> lines;
    public int curLineIndex = 0;

    public HiveBehaviour hive;
    public float MaxCountdown = 5.0f;

    private float time;

    // Singleton instance.
    public static TimerScript Instance = null;

    // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set this to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {

        PanelController panel = transform.GetComponent<PanelController>();
        panel.UpdateMe += UpdateMe;

        full = maxfull;
        eatCountdown = 0.0f;
        this.panel = panel.panel;

        ResetLines();
        hive = FindObjectOfType<HiveBehaviour>();
    }

    public float GetHungriness()
    {
        //Debug.Log((maxfull - full) * 1.0f / (1.0f * maxfull));
        //return (maxfull - full)*1.0f/(1.0f*maxfull);
        return 1.0f;
    }

    public void Eat()
    {
        full = full + 25;
        FullLimits();
    }

    public void FullLimits()
    {
        if (full > maxfull)
        {
            full = maxfull;
        }
        else if (full < 0.0f)
        {
            full = 0;
        }
    }


    public void TimePasses(int popSize)
    {
        full = full - popSize;
        FullLimits();
    }


    public void UpdateMe()
    {
        
        if (start_time >= 9999999999f)
        {
            start_time = Time.time;
            time = start_time;
            dTime = timeInMinutes;
        }
        else
        {
            eatCountdown += (Time.time-time);
            //Debug.Log(eatCountdown);
            time = Time.time;
            if (eatCountdown > MaxCountdown)
            {
                TimePasses(hive.GetPopulationSize());
                eatCountdown = 0f;
                hive.IncreaseAggressiveness();
            }
            //if (full <= 10.0f)
           
            dTime = timeInMinutes-(time-start_time);
        }
        UpdateDisplay();

        if (dTime <= 0)
        {
            panel.SUCCEED();
        }
    }

    public void UpdateDisplay()
    {
        int minutes = (int)(dTime / 60);
        int seconds = (int)(dTime-((int)(dTime / 60))*60);

        //Debug.Log(minutes);
        //Debug.Log(seconds);
        string sec = seconds.ToString();
        string min = minutes.ToString();
        if (seconds < 10) sec = "0" + sec;
        min = "0" + min;
        
        text.text =  min+ ":" + sec;
    }

    public void WriteToLines (string message)
    {
        if (curLineIndex >= (lines.Count - 1))
        {
            ResetLines();
        }
        lines[curLineIndex].Write(message);
        lines[curLineIndex + 1].AwaitingInput();
        curLineIndex++;
    }

    public void ResetLines()
    {
        foreach (ScreenLine line in lines)
        {
            line.Clear();
        }

        lines[0].AwaitingInput();
        curLineIndex = 0;
    }

}
