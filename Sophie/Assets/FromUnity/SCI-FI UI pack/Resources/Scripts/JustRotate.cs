using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustRotate : MonoBehaviour {

    public int speed; //allows user to adjust speed within unity editor

	void Update () {
		transform.Rotate(speed*Vector3.forward*Time.deltaTime);
	}
}
