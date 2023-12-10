using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using static Coordinates;
public class Piece 
{
    private string name,color;
    public Coordinates coordinates;
    public bool hasMoved;
    public bool enPassent;
    public Piece (int x, int y){
        this.name= "null";
        this.color = "null";
        this.coordinates = new Coordinates(x,y);
        enPassent=false;
        hasMoved=false;
    }

    public Piece (string name, int x, int y){
        this.name = name;
        this.color = name.Split("_")[0];
        this.coordinates= new Coordinates(x,y);
        enPassent=false;
        hasMoved=false;
    }

    public void switchColor(){
        if(name.Split("_")[1] != "king"){
            if(color=="black"){
                this.name = "white_"+name.Split("_")[1];
                this.color="white";
            } else if(color == "white"){
                this.name = "black_"+name.Split("_")[1];
                this.color = "black";
            }
        }
    }

    public Coordinates getCoordinates(){
        return coordinates;
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
