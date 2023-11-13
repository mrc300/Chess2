using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Board;
using static coordinates;
public class moves 
{
   public static coordinates[] movePawn(Board board,  coordinates coordinates){
            coordinates newCoordinates = new coordinates(coordinates.x, coordinates.y + 1);
            coordinates[] result = {newCoordinates};
            return result;
   }
}