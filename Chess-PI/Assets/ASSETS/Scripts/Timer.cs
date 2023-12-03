using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer 
{
   
    public TextMeshProUGUI timerText;
    public float currentTime;
    
    public float limit;
    public bool running;

    public Timer(TextMeshProUGUI timerText){
            this.timerText = timerText;
            running =true;
            currentTime = limit;
    }

//em minutos!
    public void setTime(float minutes){
        limit = minutes*60;
        currentTime = limit;
    }
    public void stop(){
        running = false;
    }
    public void turnOn(){
        running = true;
    }

    public void setTimerText(){
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);    
    }



    public void run(){
        if(running){
        currentTime -= Time.deltaTime;
        setTimerText();
        if (currentTime <= 0.01f)  {
             running = false;
            currentTime = 0f;
            timerText.color = Color.red;
           setTimerText();
        }
        }
    }


    
}
