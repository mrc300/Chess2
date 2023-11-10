using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
   
    public GameObject lightTile;
    public GameObject brownTile;
   
    void Start()
    {
        createBoard();
    }




    void createBoard(){
        Vector3 newVector = new Vector3(-31.53f,-31.53f,0);
        for(int x=0; x<8; x++){
            for(int y=0; y<8; y++){
             if((x+y)%2== 0) {
             Instantiate(lightTile,newVector + new Vector3(x*(9.01f),y*(9.01f),-1), Quaternion.identity);
            } else {
             Instantiate(brownTile,newVector + new Vector3(x*(9.01f),y*(9.01f),-1), Quaternion.identity);
            }
            
        }
    }
    }
}
