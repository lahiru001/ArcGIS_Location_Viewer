using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{

    public void MoveTheSunAccordingToTime(float time)
    {
        //To rotate(Sun) 1 degree, time should move 240 seconds ### (360/86400) = 1/240
        float gap = -90f;
        float movement = (1f / 240f) * time + gap;
        transform.rotation = Quaternion.Euler(movement, 0f, 0f);
        //transform.Rotate(movement, 0f, 0f, Space.Self);
        Debug.Log("MoveTheSunAccordingToTime time: "+ time + " movement "+ movement);
    }
}
