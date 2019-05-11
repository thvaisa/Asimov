using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackObject : MonoBehaviour
{
    public Transform trackedObject;

    // Update is called once per frame
    void Update()
    {
        if (trackedObject == null) return;
        transform.position = trackedObject.position;
    }
}
