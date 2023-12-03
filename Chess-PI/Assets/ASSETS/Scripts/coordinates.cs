using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinates {

    public int x;
    public int y; 


    public Coordinates(int x, int y) {   
        setCoordinates(x,y);
    }



    public Coordinates(Vector3 a) {
        Vector3 newCoordinates = (a+ new Vector3(36.04f,36.04f,0))/9;
        setCoordinates( (int)newCoordinates.x,(int)newCoordinates.y);
    }

    public void setCoordinates(int x,int y){
        this.x = x;
        this.y = y;
    }

    public double distance(Coordinates c){
        return Math.Sqrt(((x-c.x)*(x-c.x))+((y-c.y)*(y-c.y)));
    }

    public bool inVector(List<Coordinates> coordinates) {
            for(int i=0; i<coordinates.Count;i++){
                if(this.x== coordinates[i].x && this.y== coordinates[i].y){
                    return true;
                }
            }
        return false;
    }

    public bool insideBoard(){
            return x>=0 && x<8 && y<8 && y>=0;
    }

}