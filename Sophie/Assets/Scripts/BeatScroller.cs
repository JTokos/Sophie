using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{

    public float beatTempo; //how fast arrows fall down
    public bool hasStarted; //Press a button to make things fall down the screen.
    public bool hasEnded; // Check if song has ended through any means.

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f; //setting how fast the scroll should be per second.
                                       // at 120bpm, you'll move at two units (beats) per second.
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            if(Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else if(!hasEnded)
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }
}
