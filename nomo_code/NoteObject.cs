//Declaration libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    //Declaration variables
    public bool canBePressed;

    public KeyCode keyToPress;

    public GameObject hitEffect;
    public GameObject goodEffect;
    public GameObject perfectEffect;
    public GameObject missEffect;
    public float tempo;
    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        /*If the button keyToPress is pressed and the boolean
        variable canBePressed is equal to true, we check the 
        range of the collision of the arrows*/
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                /*And if it goes back in this ranges it is recalled 
                the function of the Hits in the estabilished range*/

                //Case Hit
                if (Mathf.Abs(transform.position.y) > 3.38 && Mathf.Abs(transform.position.y) < 3.56)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();   //This function is used to attribute the score in case of NormalHit
                    Instantiate(hitEffect);             //This method is used to instantiate the prefab hitEffect
                }
                //Case Good
                else if (Mathf.Abs(transform.position.y) > 3.56 && Mathf.Abs(transform.position.y) < 3.75)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();     //This function is used to attribute the score in case of GoodHit
                    Instantiate(goodEffect);            //This method is used to instantiate the prefab goodEffect
                }
                //Case Perfect
                else if (Mathf.Abs(transform.position.y) > 3.75 && Mathf.Abs(transform.position.y) < 4)
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();  //This function is used to attribute the score in case of PerfectHit
                    Instantiate(perfectEffect);         //This method is used to instantiate the prefab perfectEffect
                }
            }
        }
        //Case Missed
        else if (transform.position.y > 4)
        {
            NoteMissed();               //This function is used to advise the note has been missed
            Instantiate(missEffect);    //This method is used to instantiate the prefab missEffect
        }
    }

    //Function for enter in collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        /*If the collision tag is equal to activator, the arrow
        can be pressed*/
        if(other.tag == "activator")
        {
            canBePressed = true;
        }
    }

    //Function for exit from the collision
    private void OnTriggerExit2D(Collider2D other)
    {
        /*If the collision tag is equal to activator, the arrow
        can't be pressed*/
        if (other.tag == "activator")
        {
            canBePressed = false;
        }
    }
    //Function that is used when a note is missed
    public void NoteMissed()
    {
        /*When the note is missed destroy the arrow,
        update the counter of missedHits*/
        Destroy(gameObject);
        GameManager.instance.missedHits++;
        //Here we put currentMultiplier equal to 1
        GameManager.instance.currentMultiplier = 1;
        //Here multiplierTracker equal to 0
        GameManager.instance.multiplierTracker = 0;
        //This is multiplier text that appears in the game
        GameManager.instance.multiText.text = "Multiplier: x" + GameManager.instance.currentMultiplier;
        /*Now if there aren't buttons pressed, it appears 
        the sprite nomomissed, and it disappears the sprite 
        idlenomo*/
        GameManager.instance.nomomissed.SetActive(true);
        GameManager.instance.idlenomo.SetActive(false);
        GameManager.instance.nomoblue.SetActive(false);
        GameManager.instance.nomogreen.SetActive(false);
        GameManager.instance.nomoyellow.SetActive(false);
        GameManager.instance.nomored.SetActive(false);
    }
}