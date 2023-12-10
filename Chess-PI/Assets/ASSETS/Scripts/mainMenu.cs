using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using static Game;
public class mainMenu : MonoBehaviour 
{
    
    public static float input;
    public static bool multiplayer;
    public void play(){
        SceneManager.LoadScene(1);
    }

    public void menu(){
        SceneManager.LoadScene(0);
    }
    public void quit(){
        Application.Quit();
    }


    public  void getFloatFromInput(string s) {
       // Debug.Log(s);
    if (float.TryParse(s, out float result))
    {
        input = result;
    }
    else
    {  
        Debug.LogWarning("Input is not a valid float: " + s);
        input = 1; //default value
    }
}

    public void setMultiplayer(){
        multiplayer = false;
        play();
    }    
    public void setComputer(){
        multiplayer = true;
        play();
    }

    public void resetMultiPlayer(){
        multiplayer = false;
    }

}
