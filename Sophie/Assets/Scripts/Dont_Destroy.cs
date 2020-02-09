using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_Destroy : MonoBehaviour {

    //To be able to go through a scene without the music restarting or interuppting the music
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
}
