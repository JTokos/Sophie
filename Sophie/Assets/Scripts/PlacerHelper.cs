using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacerHelper : MonoBehaviour
{
    Rigidbody2D rb;
    public BeatScroller bs;
    public float speed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
    }
	
	// Update is called once per frame
	void Update () {
        //if (bs.hasStarted)
        //    rb.velocity = new Vector2(0, speed);
	}
}
