using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using static piece;
using static moves;
    public class Board {
        private piece [,] pieces = new piece[8,8];
        
        public Board(){
            for(int x=0; x<8; x++){
                for(int y=0; y<8; y++){
                    pieces[x,y] = new piece(x,y);
                    if(y==1 || y==6){
                         pieces[x,1] = new piece("white_pawn",x,1);    
                         pieces[x,6] = new piece("black_pawn",x,6);
                 }
                }
            }
                //rooks
                pieces[0,0]= new piece("white_rook",0,0) ;
                pieces[7,0]= new piece("white_rook",7,0) ; 
                pieces[0,7]= new piece("black_rook",0,7) ;
                pieces[7,7]= new piece("black_rook",7,7) ; 
                //hourses
                pieces[1,0]= new piece("white_hourse",1,0) ;
                pieces[6,0]= new piece("white_hourse",6,0) ; 
                pieces[1,7]= new piece("black_hourse",1,7) ;
                pieces[6,7]= new piece("black_hourse",6,7) ; 
                //bishops
                pieces[2,0]= new piece("white_bishop",2,0) ;
                pieces[5,0]= new piece("white_bishop",5,0) ; 
                pieces[2,7]= new piece("black_bishop",2,7) ;
                pieces[5,7]= new piece("black_bishop",5,7) ; 

                //kings
                pieces[4,0]= new piece("white_king",4,0);
                pieces[4,7]= new piece("black_king",4,7);
                //queens
                pieces[3,0]= new piece("white_queen",3,0);
                pieces[3,7]= new piece("black_queen",3,7);

        }

        public piece getPiece(int x,int y){
            return pieces[x,y];
        }

       

        public coordinates[] movePlate(piece p){
            if(p.getName() == "white_pawn"){
                return moves.movePawn(this,p.coordinates);
            }
            if(p.getName()== "black_pawn"){
                return moves.movePawn(this,p.coordinates);
            }
            return null;
        
        }
        public void move(coordinates previousCoordinate, coordinates newCoordinate, piece piece){           
            pieces[previousCoordinate.x,previousCoordinate.y] = new piece(previousCoordinate.x,previousCoordinate.y);
            pieces[newCoordinate.x,newCoordinate.y] = new piece(piece.getName(),newCoordinate.x,newCoordinate.y);
        }

        public bool insideBoard(coordinates coordinate){
            int x= coordinate.x;
            int y= coordinate.y;
            return x>=0 && x<8 && y<8 && y>=0;
        }
        
    }

