//Declaration libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    //Declaration variables
    public float beatTempo;

    public bool hasStarted;

    //Start is called before the first frame update
    void Start()
    {
        //The variable beatTempo is used to set arrows speed
        beatTempo = beatTempo / 60f;
    }

    //Update is called once per frame
    void Update()
    {
        /*When boolean variable hasStarted is equal to false,
        we're going to check if a button was been pressed and 
        if it has been pressed the variable hasStarted becomes 
        true to start of the game*/
        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        /*Else if the variable hasStarted is equal to true we make
        go up or down the arrow, based on the value of the variable
        named beatTempo*/
        else
        {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }
}
