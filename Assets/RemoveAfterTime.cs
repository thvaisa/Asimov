using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAfterTime : MonoBehaviour
{
    public float TimeInSeconds = 1.5f;

    private float timePassed = 0;

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed > TimeInSeconds)
        {
            Destroy(gameObject);
        }
    }
}
