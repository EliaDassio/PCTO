//Declaration libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Declaration variables
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;
    public static NoteObject instan;
    public GameObject idlenomo;
    public GameObject nomoblue;
    public GameObject nomogreen;
    public GameObject nomored;
    public GameObject nomoyellow;
    public GameObject nomomissed;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;
    public float tempo;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiText;
    public GameObject pressanykeytostarttext;

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    public GameObject resultsScreen;
    public Text percentHitText, normalsText, goodsText, perfectsText, missedText, rankText, finalScoreText;

    //Start is called before the first frame update
    void Start()
    {
        //The variable instance is an instance of the same class
        instance = this;

        scoreText.text = "Score: 0";
        currentMultiplier = 1;

        /*The variable totalNotes finds a length of a object of a class
        NoteObject*/
        totalNotes = FindObjectsOfType<NoteObject>().Length;
    }

    //Update is called once per frame
    void Update()
    {
        //This function is used for control the nomo animations
        controllo();

        /*If the boolean variable is equal to false, the game hasn't
        started yet*/
        if (!startPlaying)
        {
            /*If any key is pressed, we put the variable startPlaying is equal to true,
            the variable hasStarted is equal to true, the writing "press any key to 
            start text" disappear and the music starts to play*/
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;
                pressanykeytostarttext.SetActive(false);
                theMusic.Play();
            }
        }
        //Else
        else
        {
            /*If the music has been finish to play and the variable resultScreen
            is disactive yet*/
            if (!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                /*It equal to false all the animation excluded the idlenomo and
                it set active the variable resultScreen */
                resultsScreen.SetActive(true);
                idlenomo.SetActive(true);
                nomoblue.SetActive(false);
                nomogreen.SetActive(false);
                nomomissed.SetActive(false);
                nomoyellow.SetActive(false);
                nomored.SetActive(false);

                /*It prints the score of normalHits, the score of goodHits,
                the score of perfectHits, the score of missedHits*/
                normalsText.text = "" + normalHits;
                goodsText.text = "" + goodHits.ToString();
                perfectsText.text = "" + perfectHits.ToString();
                missedText.text = "" + missedHits;

                //Declaration of variables : totalHits and percentHits
                float totalHits = normalHits + goodHits + perfectHits;
                float percentHit = (totalHits / totalNotes) * 100f;

                //It prints the percent of accuracy of the hits
                percentHitText.text = percentHit.ToString("F1") + "%";

                //Declaration of a variable kind string 
                string rankVal = "F";

                /*Here there is the selection, which is used to 
                give a mark, we put 5 marks*/
                if (percentHit > 40)
                {
                    rankVal = "D";
                    if (percentHit > 55)
                    {
                        rankVal = "C";
                        if (percentHit > 70)
                        {
                            rankVal = "B";
                            if (percentHit > 85)
                            {
                                rankVal = "A";
                                if (percentHit > 95)
                                {
                                    rankVal = "S";
                                }
                            }
                        }
                    }
                }
                //the variable rankVal becomes a text
                rankText.text = rankVal;
                //the total score becomes a text by the method ToString()
                finalScoreText.text = currentScore.ToString();
            }
        }
    }
    //Function in case of NoteHit
    public void NoteHit()
    {
        Debug.Log("Hit On Time");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] < multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "Multiplier: x" + currentMultiplier;

        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
    }

    //Function in case of NormalHit
    public void NormalHit()
    {
        //It update the currentScore and it increases normalHits
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();

        normalHits++;
    }

    //Function in case of GoodHit
    public void GoodHit()
    {
        //It update the currentScore and it increases goodHits
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();

        goodHits++;
    }

    //Function in case of PerfectHit
    public void PerfectHit()
    {
        //It update the currentScore and it increases perfectHits
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();

        perfectHits++;
    }

    //Declaration of function controllo
    public void controllo()
    {
        /*If key A is pressed it disappear idlenomo animation
        and it appear the nomored animation, the variable tempo
        is equal to 0*/
        if (Input.GetKeyDown(KeyCode.A))
        {
            nomoblue.SetActive(false);
            nomogreen.SetActive(false);
            nomomissed.SetActive(false);
            nomoyellow.SetActive(false);
            idlenomo.SetActive(false);
            nomored.SetActive(true);
            tempo = 0;
        }
        //If any key is down nomored animation disappears
        else if (Input.anyKeyDown)
        {
            
            nomored.SetActive(false);
        }

        /*If key D is pressed it disappear idlenomo animation
        and it appear the nomoblue animation, the variable tempo
        is equal to 0*/
        if (Input.GetKeyDown(KeyCode.D))
        {
            nomogreen.SetActive(false);
            nomomissed.SetActive(false);
            nomoyellow.SetActive(false);
            nomored.SetActive(false);
            idlenomo.SetActive(false);
            nomoblue.SetActive(true);
            tempo = 0;
        }
        //If any key is down nomoblue animation disappears
        else if (Input.anyKeyDown)
        {
            nomoblue.SetActive(false);
        }

        /*If key W is pressed it disappear idlenomo animation
        and it appear the nomogreen animation, the variable tempo
        is equal to 0*/
        if (Input.GetKeyDown(KeyCode.W))
        {
            nomoblue.SetActive(false);
            nomomissed.SetActive(false);
            nomoyellow.SetActive(false);
            nomored.SetActive(false);
            idlenomo.SetActive(false);
            nomogreen.SetActive(true);
            tempo = 0;
        }
        //If any key is down nomogreen animation disappears
        else if (Input.anyKeyDown)
        {
            nomogreen.SetActive(false);
        }

        /*If key S is pressed it disappear idlenomo animation
        and it appear the nomoyellow animation, the variable tempo
        is equal to 0*/
        if (Input.GetKeyDown(KeyCode.S))
        {
            nomoblue.SetActive(false);
            nomogreen.SetActive(false);
            nomomissed.SetActive(false);
            nomored.SetActive(false);
            idlenomo.SetActive(false);
            nomoyellow.SetActive(true);
            tempo = 0;
        }
        //If any key is down nomoyellow animation disappears
        else if (Input.anyKeyDown)
        {
            nomoyellow.SetActive(false);
        }
        //The variable tempo is increased with parameter Time.deltaTime
        tempo += Time.deltaTime;
        //If the variable tempo is bigger than 1 second
        if (tempo > 1f)
        {
            /*All the animation excluded the idlenomo disappear
            and the variable tempo is set to 0*/
            idlenomo.SetActive(true);
            nomoblue.SetActive(false);
            nomogreen.SetActive(false);
            nomomissed.SetActive(false);
            nomoyellow.SetActive(false);
            nomored.SetActive(false);
            tempo = 0;
        }
    }
}