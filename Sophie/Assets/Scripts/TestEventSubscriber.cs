using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class TestEventSubscriber : MonoBehaviour
{
    public string EventID;
    public delegate void KoreographyEventCallback(KoreographyEvent koreoEvent);
    public delegate void KoreographyEventCallbackWithTime(KoreographyEvent koreoEvent, int sampleTime, int sampleData, DeltaSlice deltaSlice);
	// Use this for initialization
	void Start ()
    {
        Koreographer.Instance.RegisterForEvents(EventID, FireEventDebugLog);	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void FireEventDebugLog(KoreographyEvent koreoEvent)
    {
        Debug.Log("Koreography event fired.");
        Koreographer.Instance.RegisterForEvents(EventID, CallLogABitch);
    }

    void CallLogABitch(KoreographyEvent koreoEvent)
    {
        Debug.Log("Yous a B");
    }
}
