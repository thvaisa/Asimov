using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackObject : MonoBehaviour
{
    public Transform trackedObject;

    // Update is called once per frame
    void Update()
    {
        transform.position = trackedObject.position;
    }
}
