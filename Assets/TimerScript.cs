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

    void Start()
    {

        PanelController panel = transform.GetComponent<PanelController>();
        panel.UpdateMe += UpdateMe;
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
