using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using static Board;
using static Coordinates;
public class Moves 
{
      public static List<Coordinates> movePawn(Board board,  Coordinates coordinates, int color){
            List<Coordinates> result = new List<Coordinates>();
            if(color==0){
                  Coordinates newCoordinates = new Coordinates(coordinates.x, coordinates.y + 1);
                  result.Add(newCoordinates);
            } else {
                  Coordinates newCoordinates = new Coordinates(coordinates.x, coordinates.y - 1);
                  result.Add(newCoordinates);
            }
            return result;
      }

      public static List<Coordinates> moveLine(Board board,  Coordinates coordinates, int dx, int dy,int range){
            List<Coordinates> result = new List<Coordinates>();
            board.print();
            for(int i = 1;i<=range;i++){
                  Coordinates nCoordinates = new Coordinates(coordinates.x+dx*i, coordinates.y+dy*i);
                  if(!nCoordinates.insideBoard()) break;
                  else if(board.getPiece(nCoordinates).getName() != "null"){
                        if(board.getPiece(nCoordinates).getColor() != board.getPiece(coordinates).getColor())result.Add(nCoordinates);
                        break;
                  } 
                  else{
                        Debug.Log($"{nCoordinates.x}, {nCoordinates.y}");
                        result.Add(nCoordinates);
                  }
            }
            return result;
      }
}