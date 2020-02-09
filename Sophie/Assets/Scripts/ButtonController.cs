using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;

    public bool createMode;
    public GameObject theNote;

    public GameObject missedEffect;
    public bool somethingInside;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (createMode && Input.GetKeyDown(keyToPress)) // Testing create mode.
        {
            Instantiate(theNote, transform.position, Quaternion.identity);
        }
        else
        {
            if (Input.GetKeyDown(keyToPress))
            {
                theSR.sprite = pressedImage;
                if (!somethingInside)
                {
                    Vector3 temp = new Vector3(transform.position.x, transform.position.y + 2);
                    Instantiate(missedEffect, temp, missedEffect.transform.rotation);
                    GameManager.instance.NoteMissed();
                }

            }

            if (Input.GetKeyUp(keyToPress))
            {
                theSR.sprite = defaultImage;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        somethingInside = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        somethingInside = false;
    }
}
