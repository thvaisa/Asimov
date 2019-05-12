using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timeInMinutes = 5*60;
    public float dTime = 0;

    private Panel panel;
    public Text text;
    private float start_time = 99999999999f;

    public int maxfull = 100;
    public int full;

    public float eatCountdown = 0.0f;

    void Start()
    {

        PanelController panel = transform.GetComponent<PanelController>();
        panel.UpdateMe += UpdateMe;
        full = maxfull;
        eatCountdown = 0.0f;
    }

    public float GetHungriness()
    {
        return (maxfull - full)/(1f*maxfull);
    }

    public void Eat()
    {
        full = full + 25;
        if (full > maxfull) full = maxfull;
    }


    public void TimePasses(int popSize)
    {
        full = full - popSize;
    }


    public void UpdateMe()
    {
        
        if (start_time >= 9999999999f)
        {
            start_time = Time.time;
            dTime = timeInMinutes;
        }
        else
        {
            float time = Time.time;
            eatCountdown += (time - start_time);
            if (eatCountdown > 1.0f)
            {
                TimePasses(1);
                eatCountdown = 0f;
            }
            dTime = timeInMinutes-(time-start_time);
        }
        UpdateDisplay();
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

}
