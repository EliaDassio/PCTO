//Declaration libraries
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class on_click_option : MonoBehaviour
{
    /*Depending on the button pressed it calls
    one of these function*/
    public void PlaySong1()
    {
        //This is the scene of level 1
        SceneManager.LoadScene(2);
    }
    public void PlaySong2()
    {
        //This is the scene of level 2
        SceneManager.LoadScene(3);
    }
    public void PlaySong3()
    {
        //This is the scene of level 3
        SceneManager.LoadScene(4);
    }
    public void BackToMenu()
    {
        //This is the scene of songselection
        SceneManager.LoadScene(1);
    }
}
