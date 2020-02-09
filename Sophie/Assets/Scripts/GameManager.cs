using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //Accessing UI

public class GameManager : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    public double health = 0.1;
    

    public AudioSource theMusic; //Music File

    public bool startPlaying; //Starts the music

    public BeatScroller theBS; //Controls the starting of the scrolling of the music.

    public static GameManager instance; // Instance of the game manager, static.

    public int currentScore; //Holder for current score.
    public int scorePerNote = 1000;
    public int scorePerGoodNote = 1200;
    public int scorePerPerfectNote = 1500;
    public int currentMultiplier;
    public int multiplierTracker;
    public int numberOfNotes;
    public int trackID;
    public int[] scoreThresholds = new int[5];
    public int[] multiplierThresholds; //Making it harder for being able to reach the next multiplier.

    public KeyCode escapeKey;
    public Text scoreText, multiplierText;
    public Text percentHitText, normalHitText, goodHitText, perfectHitText, missesHitText, rankText, finalScoreText;

    public float totalNotes, normalHits, goodHits, perfectHits, missedHits;
    public float time = 3f;
    public GameObject resultsScreen;
    public GameObject failedScreen;
    
    // Start is called before the first frame update
    void Start()
    {
       // healthBar.setSize((float) health);

        
        GameManager.instance = this; //Only one game manager. If multiple scripts, only one instance.

        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        totalNotes = FindObjectsOfType<NoteObject>().Length;
        numberOfNotes = (int)totalNotes;
        switch(numberOfNotes)
        {
            case 201:
                trackID = 2;
                break;
            default:
                trackID = 1;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(escapeKey))
        {
            SceneManager.LoadScene("song_selection");
            resultsScreen.SetActive(true);
            theMusic.Stop();
            theBS.hasEnded = true;
        }
        
        if (time > 0)
            time -= Time.deltaTime;
        else if (!theMusic.isPlaying && time != 0)
        {
            time = 0;
            theMusic.Play();
            startPlaying = true;
        }

        //  if (health <= 0)
        //      health = 0;
        //   healthBar.setSize((float)health);
        /*if(//(health == 0 || health <= 0))//missedHits > (totalNotes/2) || 
        {
            theBS.hasEnded = true;
            theMusic.Stop();
            if(!failedScreen.activeInHierarchy)
            {
                failedScreen.SetActive(true);
            }

        }
        
        if (!startPlaying) //If music hasn't started
        {
            /*
            if (Input.anyKeyDown) // if user has press something
            {
                startPlaying = true;// Music has started, notes start falling.
                theBS.hasStarted = true;

                theMusic.Play(); // Start the music.
            }
            */
        //  }
        if(!startPlaying)
        {

        }
        else
        {
            if (!theMusic.isPlaying && !resultsScreen.activeInHierarchy && !failedScreen.activeInHierarchy)
            {
                theBS.hasEnded = true;
                resultsScreen.SetActive(true);

                normalHitText.text = normalHits.ToString();
                goodHitText.text = goodHits.ToString();
                perfectHitText.text = perfectHits.ToString();
                missesHitText.text = missedHits.ToString();

                float totalHits = normalHits + goodHits + perfectHits;
                float totalHitPercentage = (totalHits / totalNotes) * 100;

                percentHitText.text = totalHitPercentage.ToString("F2") + "%";
                switch(trackID)
                {
                    case 1:
                        scoreThresholds = new int[] { 250000, 301500, 506400, 759600, 1012800 };
                        break;
                    case 2:
                        scoreThresholds = new int[] { 250000,301500, 506400, 759600, 1012800 };
                        break;
                    default:
                        break;
                }
               
                char rankVal = 'S';
                if(currentScore < scoreThresholds[3])
                {
                    rankVal = 'A';
                    if (currentScore < scoreThresholds[2])
                    {
                        rankVal = 'B';
                        if (currentScore < scoreThresholds[1])
                        {
                            rankVal = 'C';
                            if (currentScore < scoreThresholds[0])
                            {
                                rankVal = 'F';
                            }
                        }
                    }
                }
                
                /*
                char rankVal = 'F';
                if (totalHitPercentage > 40f)
                {
                    rankVal = 'D';
                    if (totalHitPercentage > 55f)
                    {
                        rankVal = 'C';
                        if (totalHitPercentage > 70)
                        {
                            rankVal = 'B';
                            if (totalHitPercentage > 85f)
                            {
                                rankVal = 'A';
                                if (totalHitPercentage > 95f)
                                {
                                    rankVal = 'S';
                                }
                            }
                        }
                    }
                }
                */
                rankText.text = rankVal.ToString();
                
                finalScoreText.text = currentScore.ToString();

            }
        }
    }

    public void NoteHit() // Function to call when note was hit.
    {
       // Debug.Log("Hit on Time");
        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
       // theMusic.Stop(); //DEBUG
        multiplierText.text = "Multiplier: X" + currentMultiplier;
        /*
        currentScore += scorePerNote * currentMultiplier;
        */
        scoreText.text = "Score: " + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();
        if(health <= .95)
        {
            health += .05;
            healthBar.setSize((float)health);
        }
        else if(health > .95 && health != 1)
        {
            health = 1;
            healthBar.setSize((float)health);
        }
        normalHits++;
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();
        if (health <= .90)
        {
            health += .1;
        }
        else if (health > .90 && health != 1)
        {
            health = 1;
        }
        goodHits++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();
        if (health <= .85)
        {
            health += .15;
        }
        else if (health > .85 && health != 1)
        {
            health = 1;
        }
        perfectHits++;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");
        currentMultiplier = 1;
        multiplierTracker = 0;        
        //health = health - .05;
        multiplierText.text = "Multiplier: X" + currentMultiplier;
        missedHits++;
    }
}
