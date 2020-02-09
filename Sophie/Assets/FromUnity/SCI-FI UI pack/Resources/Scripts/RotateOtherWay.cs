using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOtherWay : MonoBehaviour
{

    public int speed;

    void Update()
    {
        transform.Rotate(speed * Vector3.back * Time.deltaTime);
    }
}
