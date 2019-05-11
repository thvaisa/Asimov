using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterScript : MonoBehaviour
{
    [Range(0, 1)] public float meter1 = 0;
    [Range(0, 1)] public float meter2 = 0;
    [Range(0, 1)] public float meter3 = 0;

    public HandScript hand1;
    public HandScript hand2;
    public HandScript hand3;

    private Panel panel;

    void Start()
    {

        PanelController panel = transform.GetComponent<PanelController>();
        panel.UpdateMe += UpdateMe;

    }

    public void UpdateMe()
    {
        hand1.UpdateMe(meter1);
        hand2.UpdateMe(meter2);
        hand3.UpdateMe(meter3);
    }


}
