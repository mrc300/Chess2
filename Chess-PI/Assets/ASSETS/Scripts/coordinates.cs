using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coordinates {



    public int x;
    public int y; 


    public coordinates(int x, int y)
{   
    this.x =x;
    this.y=y;
}
 public coordinates(){

 }


   public coordinates setBoardCoordinates(Vector3 a){
        Vector3 newCoordinates = (a+ new Vector3(36.04f,36.04f,0))/9;
        this.x = (int)newCoordinates.x;
        this.y = (int)newCoordinates.y;
        return this;
   }

    public void setCoordinates(int x,int y){
        this.x =x;
        this.y=y;
    }
    public bool inVector (coordinates[] coordinates){
            for(int i=0; i<coordinates.Length;i++){
                if(this.x== coordinates[i].x && this.y== coordinates[i].y){
                    return true;
                }
            }
        return false;
    }

}