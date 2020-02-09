using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public BeatScroller bs;
    Rigidbody2D rb;
    public float speed;

    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject normalEffect, goodEffect, perfectEffect, missEffect;
    // Start is called before the first frame update

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
    }
    void Start()
    {
        //GameManager.Instantiate();
       // rb.velocity = new Vector2(0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (bs.hasStarted)
        {
            rb.velocity = new Vector2(0, -speed);
        }
        
        if (!bs.hasEnded)
        {
        */
            if (Input.GetKeyDown(keyToPress))
            {
                if (canBePressed)
                {
                    gameObject.SetActive(false);
                    if(Mathf.Abs(transform.position.y) > 1.8f || transform.position.y < .5f )
                    {
                        GameManager.instance.NormalHit();
                        Instantiate(normalEffect, transform.position, normalEffect.transform.rotation);
                        Debug.Log("Normal Hit");
                    }
                    else if (transform.position.y > 1.15f || transform.position.y < .75f)
                    {
                        Debug.Log("Good Hit");
                        Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                        GameManager.instance.GoodHit();
                    }
                    else
                    {
                        Debug.Log("PERFECT!!!");
                        Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                        GameManager.instance.PerfectHit();
                    }

                    // GameManager.instance.NoteHit(); //If pressed (correct timing), you hit correctly.
                }
            }
       // }
       /*
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
        */
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;   
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
            GameManager.instance.NoteMissed(); //Missed the note.
        }
    }
}
