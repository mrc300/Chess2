using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
  public GameObject controller;
  public GameObject movePlate;

  private string player;

  
  

  public void Activate() {
    controller = GameObject.FindGameObjectWithTag("GameController");

  }

}
