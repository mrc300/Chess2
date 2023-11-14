using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO.Pipes;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using static Piece;
using static Moves;
using static Coordinates;
    public class Board {
        private Piece [,] Pieces = new Piece[8,8];
        public string turn= "white";
        public Board(){
            for(int x=0; x<8; x++){
                for(int y=0; y<8; y++){
                    Pieces[x,y] = new Piece(x,y);
                    if(y==1 || y==6){
                         Pieces[x,1] = new Piece("white_pawn",x,1);    
                         Pieces[x,6] = new Piece("black_pawn",x,6);
                    }else{
                        Pieces[x,y]= new Piece(x,y);
                    }

                }
            }
                //rooks
                Pieces[0,0]= new Piece("white_rook",0,0) ;
                Pieces[7,0]= new Piece("white_rook",7,0) ; 
                Pieces[0,7]= new Piece("black_rook",0,7) ;
                Pieces[7,7]= new Piece("black_rook",7,7) ; 
                //hourses
                Pieces[1,0]= new Piece("white_hourse",1,0) ;
                Pieces[6,0]= new Piece("white_hourse",6,0) ; 
                Pieces[1,7]= new Piece("black_hourse",1,7) ;
                Pieces[6,7]= new Piece("black_hourse",6,7) ; 
                //bishops
                Pieces[2,0]= new Piece("white_bishop",2,0) ;
                Pieces[5,0]= new Piece("white_bishop",5,0) ; 
                Pieces[2,7]= new Piece("black_bishop",2,7) ;
                Pieces[5,7]= new Piece("black_bishop",5,7) ; 

                //kings
                Pieces[4,0]= new Piece("white_king",4,0);
                Pieces[4,7]= new Piece("black_king",4,7);
                //queens
                Pieces[3,0]= new Piece("white_queen",3,0);
                Pieces[3,7]= new Piece("black_queen",3,7);

        }

        public Piece getPiece(int x,int y){
            return Pieces[x,y];
        }

        public Piece getPiece(Coordinates c){
            return Pieces[c.x,c.y];
        }

        public List<Coordinates> movePlate(Piece p){
            if(p.getName() == "white_pawn"){
                return Moves.movePawn(this,p.coordinates,0);
            }
            if(p.getName()== "black_pawn"){
                return Moves.movePawn(this,p.coordinates,1);
            }
            if(p.getName() == "white_bishop" || p.getName() == "black_bishop"){
                return Moves.moveLine(this,p.coordinates,1,1,7)
                    .Concat(Moves.moveLine(this,p.coordinates,1,-1,7)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,-1,1,7)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,-1,-1,7)).ToList();
            }
            if(p.getName() == "white_rook" || p.getName() == "black_rook"){
                return Moves.moveLine(this,p.coordinates,1,0,7)
                    .Concat(Moves.moveLine(this,p.coordinates,0,-1,7)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,-0,1,7)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,-1,0,7)).ToList();
            }
            if(p.getName() == "white_queen" || p.getName() == "black_queen"){
                return Moves.moveLine(this,p.coordinates,1,0,7)
                    .Concat(Moves.moveLine(this,p.coordinates,0,-1,7)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,-0,1,7)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,-1,0,7)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,1,1,7)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,1,-1,7)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,-1,1,7)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,-1,-1,7)).ToList();
            }
            if(p.getName() == "white_king" || p.getName() == "black_king"){
                return Moves.moveLine(this,p.coordinates,1,0,1)
                    .Concat(Moves.moveLine(this,p.coordinates,0,-1,1)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,-0,1,1)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,-1,0,1)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,1,1,1)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,1,-1,1)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,-1,1,1)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,-1,-1,1)).ToList();
            }
            if(p.getName()=="white_hourse"|| p.getName()=="black_hourse"){
                 return Moves.moveLine(this,p.coordinates,2,1,1)
                    .Concat(Moves.moveLine(this,p.coordinates,2,-1,1)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,-2,1,1)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,-2,-1,1)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,1,2,1)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,-1,2,1)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,1,-2,1)).ToList()
                    .Concat(Moves.moveLine(this,p.coordinates,-1,-2,1)).ToList();
            }
            return null;
        
        }
        public void move(Coordinates previousCoordinate, Coordinates newCoordinate, Piece Piece){ 
            if(Piece.getColor()==turn){          
            Pieces[previousCoordinate.x,previousCoordinate.y] = new Piece(previousCoordinate.x,previousCoordinate.y);
            Pieces[newCoordinate.x,newCoordinate.y] = new Piece(Piece.getName(),newCoordinate.x,newCoordinate.y);
            Pieces[newCoordinate.x,newCoordinate.y].hasMoved = true;
             switchTurn();
            }
        }
        public void print(){
            for(int x=0; x<8; x++){
                string res = "";
                for(int y=0; y<8; y++){
                    res += $" {Pieces[y,x].getName()}"; 
                }
                Debug.Log(res + "\n");
            }
        }

        public void switchTurn(){
            if(turn=="white"){
                turn= "black";
            } else if(turn=="black"){
                turn= "white";
            }
        }
    }

