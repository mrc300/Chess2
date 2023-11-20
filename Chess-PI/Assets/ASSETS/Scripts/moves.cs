using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using static Board;
using static Coordinates;
public class Moves 
{
      public static List<Coordinates> movePawn(Board board,  Piece piece){
            List<Coordinates> result = new List<Coordinates>();
            Coordinates coordinates = piece.coordinates;
            if(piece.getColor()==board.turn){
                  if(piece.getColor()=="white") {     
                        Coordinates newCoordinates =new Coordinates(coordinates.x, coordinates.y + 1);
                        Coordinates right= new Coordinates(newCoordinates.x+1,newCoordinates.y);
                              Coordinates left= new Coordinates(newCoordinates.x-1,newCoordinates.y);
                              if((left.insideBoard() && board.getPiece(left).getColor() =="black")){
                                    result.Add(left);
                              }
                              if((right.insideBoard() && board.getPiece(right).getColor() =="black")){
                                    result.Add(right);
                              }
                        if(board.getPiece(newCoordinates).getName() == "null"){
                              result.Add(newCoordinates);
                        
                        } else {
                              return result;
                        }
                        if(piece.hasMoved == false){
                              newCoordinates =new Coordinates(coordinates.x, coordinates.y + 2);
                              if(board.getPiece(newCoordinates).getName() == "null"){
                                    result.Add(newCoordinates);
                              }
                        }
                  } else {
                        Coordinates newCoordinates =new Coordinates(coordinates.x, coordinates.y - 1);
                        Coordinates right= new Coordinates(newCoordinates.x+1,newCoordinates.y);
                        Coordinates left= new Coordinates(newCoordinates.x-1,newCoordinates.y);

                              if((left.insideBoard() && board.getPiece(left).getColor() =="white")){
                                    result.Add(left);
                              }
                              if((right.insideBoard() && board.getPiece(right).getColor() =="white")){
                                    result.Add(right);
                              }
                        if(board.getPiece(newCoordinates).getName() == "null"){
                              result.Add(newCoordinates);
                        } else {
                              return result;
                        }
                        if(piece.hasMoved == false){
                              newCoordinates =new Coordinates(coordinates.x, coordinates.y - 2);
                              if(board.getPiece(newCoordinates).getName() == "null"){
                                    result.Add(newCoordinates);
                              }
                        }
                  }
            }
            return result;
      }

      public static List<Coordinates> moveLine(Board board,  Piece piece, int dx, int dy,int range){
            Coordinates coordinates = piece.coordinates;
            List<Coordinates> result = new List<Coordinates>();
            if(piece.getColor()==board.turn){
                  for(int i = 1;i<=range;i++) {
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
            }
            return result;
      }
}