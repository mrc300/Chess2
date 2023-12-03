using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{

    public void play(){
        SceneManager.LoadSceneAsync(1);
    }

    public void quit(){
        Application.Quit();
    }
}
