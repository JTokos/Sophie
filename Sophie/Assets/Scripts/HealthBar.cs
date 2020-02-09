using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    private Transform bar;
	// Use this for initialization
	void Start () {
        bar = transform.Find("Bar");
        bar.localScale = new Vector3(.4f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
}
