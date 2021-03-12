//Declaration libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    //Declaration variables
    //This is lifetime value of the effect
    public float lifetime = 1f;

    //Start is called before the first frame update
    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        /*This method makes sure to destroy 
        the effect after the lifetime*/
        Destroy(gameObject, lifetime);
    }
}
