using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using static Coordinates;
public class Piece 
{
    private string name,color;
    public Coordinates coordinates;
    public bool hasMoved;
    public Piece (int x, int y){
        this.name= "null";
        this.color = "null";
        this.coordinates = new Coordinates(x,y);
        hasMoved=false;
    }

    public Piece (string name, int x, int y){
        this.name = name;
        this.color = name.Split("_")[0];
        this.coordinates= new Coordinates(x,y);
        hasMoved=false;
    }
    public string getName(){
       return name;
    } 

    public void setName(string name){
        this.name= name;
    }
   
   public string getColor(){
        return color;
   }

   public bool equals(Piece piece){
        return this == piece;
   }
  
}
