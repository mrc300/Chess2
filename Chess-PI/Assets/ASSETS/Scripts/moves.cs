using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using static Board;
using static coordinates;
public class moves 
{
   public static coordinates[] movePawn(Board board,  coordinates coordinates, int color){
      if(color==0){
            coordinates newCoordinates = new coordinates(coordinates.x, coordinates.y + 1);
            coordinates[] result = {newCoordinates};
            return result;
      } else {
            coordinates newCoordinates = new coordinates(coordinates.x, coordinates.y - 1);
            coordinates[] result = {newCoordinates};
            return result;
      }
      
   }


   

}