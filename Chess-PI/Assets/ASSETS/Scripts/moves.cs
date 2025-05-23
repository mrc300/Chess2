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
            if(piece.getColor()=="white") {     
                  Coordinates newCoordinates =new Coordinates(coordinates.x, coordinates.y + 1);
                  Coordinates right= new Coordinates(newCoordinates.x+1,newCoordinates.y);
                  Coordinates left= new Coordinates(newCoordinates.x-1,newCoordinates.y);
                  if((left.insideBoard() && (board.getPiece(left).getColor() =="black"|| (board.getPiece(left.x,coordinates.y).getColor()=="black"&&board.getPiece(left.x,coordinates.y).enPassent))) && !board.willCheck(coordinates,left)){
                        result.Add(left);
                  }
                  if((right.insideBoard() && (board.getPiece(right).getColor() =="black"|| (board.getPiece(right.x,coordinates.y).getColor()=="black" &&board.getPiece(right.x,coordinates.y).enPassent))) && !board.willCheck(coordinates,right)){
                        result.Add(right);
                  }
                  if(newCoordinates.insideBoard() &&board.getPiece(newCoordinates).getName() == "null"){
                        if(!board.willCheck(coordinates,newCoordinates))result.Add(newCoordinates);
                        if(piece.hasMoved == false){
                              newCoordinates =new Coordinates(coordinates.x, coordinates.y + 2);
                              if(newCoordinates.insideBoard() &&board.getPiece(newCoordinates).getName() == "null" && !board.willCheck(coordinates,newCoordinates)){
                                    result.Add(newCoordinates);
                              }
                        }
                  } 
                  
            } else {
                  Coordinates newCoordinates =new Coordinates(coordinates.x, coordinates.y - 1);
                  Coordinates right= new Coordinates(newCoordinates.x+1,newCoordinates.y);
                  Coordinates left= new Coordinates(newCoordinates.x-1,newCoordinates.y);
                  if((left.insideBoard() && (board.getPiece(left).getColor() =="white"|| (board.getPiece(left.x,coordinates.y).getColor()=="white"&&board.getPiece(left.x,coordinates.y).enPassent))) && !board.willCheck(coordinates,left)){
                        result.Add(left);
                  }
                  if((right.insideBoard() && (board.getPiece(right).getColor() =="white"|| (board.getPiece(right.x,coordinates.y).getColor()=="white" &&board.getPiece(right.x,coordinates.y).enPassent))) && !board.willCheck(coordinates,right)){
                        result.Add(right);
                  }
                  if(newCoordinates.insideBoard() && board.getPiece(newCoordinates).getName() == "null" ){
                        if(!board.willCheck(coordinates,newCoordinates))result.Add(newCoordinates);
                        if(piece.hasMoved == false ){
                              newCoordinates =new Coordinates(coordinates.x, coordinates.y - 2);
                              if(newCoordinates.insideBoard() &&board.getPiece(newCoordinates).getName() == "null" && !board.willCheck(coordinates,newCoordinates)){
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
            
            for(int i = 1;i<=range;i++) {
                  Coordinates nCoordinates = new Coordinates(coordinates.x+dx*i, coordinates.y+dy*i);
                  if(!nCoordinates.insideBoard()) break;
                  else if(board.getPiece(nCoordinates).getName() != "null"){
                        if(board.getPiece(nCoordinates).getColor()!=board.getPiece(coordinates).getColor() && !board.willCheck(coordinates,nCoordinates))
                              result.Add(nCoordinates);
                        break;
                  } 
                  else{
                        if(!board.willCheck(coordinates,nCoordinates))
                              result.Add(nCoordinates);
                  }
            }
          
            return result;
      }


      public static List<Coordinates> castle(Board b, Piece king){
            List<Coordinates> result = new List<Coordinates>();
            if(king.getColor()==b.turn){
            if(king.getColor() == "white" && king.hasMoved == false){
                  if(b.getPiece(7,0).getName()== "white_rook" && b.getPiece(7,0).hasMoved == false
                  && b.getPiece(6,0).getName()== "null" && b.getPiece(5,0).getName()== "null" && !b.willCheck(new Coordinates(4,0),new Coordinates(7,0))) {
                        result.Add(new Coordinates(7,0));
                  }   
                  if(b.getPiece(0,0).getName()== "white_rook" && b.getPiece(0,0).hasMoved == false
                  && b.getPiece(1,0).getName()== "null" && b.getPiece(2,0).getName()== "null" && b.getPiece(3,0).getName()== "null" &&!b.willCheck(new Coordinates(4,0),new Coordinates(0,0))) {
                        result.Add(new Coordinates(0,0));
                  }        
            }   
              if(king.getColor() == "black" && king.hasMoved == false){
                  if(b.getPiece(7,7).getName()== "black_rook" && b.getPiece(7,7).hasMoved == false
                  && b.getPiece(6,7).getName()== "null" && b.getPiece(5,7).getName()== "null" && !b.willCheck(new Coordinates(4,7),new Coordinates(7,7))) {
                        result.Add(new Coordinates(7,7));
                  }   
                  if(b.getPiece(0,7).getName()== "black_rook" && b.getPiece(0,7).hasMoved == false
                  && b.getPiece(1,7).getName()== "null" && b.getPiece(2,7).getName()== "null" && b.getPiece(3,7).getName()== "null"  &&!b.willCheck(new Coordinates(4,7),new Coordinates(0,7))) {
                        result.Add(new Coordinates(0,7));
                  }        
            }   
            }
            return result;  
      }
}