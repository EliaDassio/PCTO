//Declaration libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    //Declaration variables
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;
    //Start is called before the first frame update
    void Start()
    {
        /*The variable theSR gets a component of 
        type SpriteRenderer*/
        theSR = GetComponent<SpriteRenderer>();
    }

    //Update is called once per frame
    void Update()
    {
        /*If a button is pressed and it is equal to the 
        variable named keyToPress the displayed image
        is the sprite pressedImage*/
        if (Input.GetKeyDown(keyToPress))
        {
            theSR.sprite = pressedImage;
        }
        /*When the keyToPress is released the sprite that
        is displayed becomes the sprite defaultImage*/
        if (Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultImage;
        }
    }
}
