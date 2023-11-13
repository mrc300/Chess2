using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEditorInternal;
using UnityEngine;
using static coordinates;
public class piece 
{
    private string name;
    public coordinates coordinates;

    
    public piece (int x, int y){
        this.name= "null";
        this.coordinates = new coordinates(x,y);
    }
    public piece (string name, int x, int y){
        this.name = name;
        this.coordinates= new coordinates(x,y);
    }
    public string getName(){
       return name;
    } 

    public void setName(string name){
        this.name= name;
    }
   

   public bool equals(piece piece){
        return this.name.Equals(piece.getName()) && this.coordinates.x == piece.coordinates.x &&
            this.coordinates.y == piece.coordinates.y; 
   }
  
}
