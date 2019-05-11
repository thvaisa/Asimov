using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    public float minRange = 60;
    public float maxRange = -60;

    private RectTransform rectTransform;

    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void UpdateMe(float value)
    {
        //Debug.Log(value);
        rectTransform.rotation = Quaternion.Euler(0f, 0f, (60 - 120 * value));
    }

}
