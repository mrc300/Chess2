using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
  public GameObject controller;
  public GameObject movePlate;

  private string player;

  public Sprite black_pawn, black_queen, black_king, black_hourse, black_rook, black_bishop;
  public Sprite white_pawn, white_queen, white_king, white_hourse, white_rook, white_bishop;
  

  public void Activate() {
        controller = GameObject.FindGameObjectWithTag("GameController"); 
  }
  
}
