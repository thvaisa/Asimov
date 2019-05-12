using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterScript : MonoBehaviour
{
    [Range(0, 1)] public float meter1 = 0;
    [Range(0, 1)] public float meter2 = 0;
    [Range(0, 1)] public float meter3 = 0;

    public HandScript hand1;
    public HandScript hand2;
    public HandScript hand3;

    public Text textLeft;
    public Text textMiddle;
    public Text textRight;

    public TimerScript timer;
    public HiveBehaviour hive;

    private Panel panel;

    void Start()
    {

        PanelController panel = transform.GetComponent<PanelController>();
        panel.UpdateMe += UpdateMe;

        timer = FindObjectOfType<TimerScript>();
        hive = FindObjectOfType<HiveBehaviour>();

    }

    public void UpdateMe()
    {

        meter1 = hive.GetAgrressivinesPercentage();
        meter2 = hive.GetPopulationPercentage();
        meter3 = timer.GetHungriness();
        int i = (int)(5 * hive.GetAgrressivinesPercentage());   
        int j = (int)(5 * hive.GetPopulationPercentage());
        int k = (int)(5 * timer.GetHungriness());
        if (i > 4) i = 4;
        if (j > 4) j = 4;
        if (k > 4) k = 4;
        textLeft.text = i.ToString();
        textMiddle.text = j.ToString();
        textRight.text = k.ToString();
        hand1.UpdateMe(meter1);
        hand2.UpdateMe(meter2);
        hand3.UpdateMe(meter3);
    }


}
