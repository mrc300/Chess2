using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO.Pipes;
using Unity.VisualScripting;
using UnityEngine;
using static Piece;
using static Moves;
using static Coordinates;
using UnityEngine.UIElements;
public class Board {
        

        private Piece [,] pieces = new Piece[8,8];
        private bool isCloned = false;
        private string winner = "null";
        public string turn= "white";
        
        public object Clone()
    {
        Board newBoard = new Board();
        Piece[,] newPieces = new Piece[8,8]; 
        for(int x=0; x<8; x++){
                for(int y=0; y<8; y++){
                    newPieces[x,y] = pieces[x,y];
                }
        }
        return new Board(newPieces,turn,true);
    }
        
        public Board(){
            for(int x=0; x<8; x++){
                for(int y=0; y<8; y++){
                    pieces[x,y] = new Piece(x,y);
                    if(y==1 || y==6){
                         pieces[x,1] = new Piece("white_pawn",x,1);    
                         pieces[x,6] = new Piece("black_pawn",x,6);
                    }else{
                        pieces[x,y]= new Piece(x,y);
                    }

                }
            }
                //rooks
                pieces[0,0]= new Piece("white_rook",0,0) ;
                pieces[7,0]= new Piece("white_rook",7,0) ; 
                pieces[0,7]= new Piece("black_rook",0,7) ;
                pieces[7,7]= new Piece("black_rook",7,7) ; 
                //nights
                pieces[1,0]= new Piece("white_night",1,0) ;
                pieces[6,0]= new Piece("white_night",6,0) ; 
                pieces[1,7]= new Piece("black_night",1,7) ;
                pieces[6,7]= new Piece("black_night",6,7) ; 
                //bishops
                pieces[2,0]= new Piece("white_bishop",2,0) ;
                pieces[5,0]= new Piece("white_bishop",5,0) ; 
                pieces[2,7]= new Piece("black_bishop",2,7) ;
                pieces[5,7]= new Piece("black_bishop",5,7) ; 

                //kings
                pieces[4,0]= new Piece("white_king",4,0);
                pieces[4,7]= new Piece("black_king",4,7);
                //queens
                pieces[3,0]= new Piece("white_queen",3,0);
                pieces[3,7]= new Piece("black_queen",3,7);

        }

        public Board(Piece[,] pieces, string turn,bool isCloned){
            this.pieces = pieces;
            this.isCloned = isCloned;
            this.turn = turn;
        }

        public Piece getPiece(int x,int y){
            return pieces[x,y];
        }

        public Piece getPiece(Coordinates c){
            return pieces[c.x,c.y];
        }

        public List<Coordinates> movePlate(Piece p,bool bothColors){
            if(winner == "null" && (p.getColor() == turn || bothColors)){
                if(p.getName() == "white_pawn"){
                    return Moves.movePawn(this,p);
                }
                if(p.getName()== "black_pawn"){
                    return Moves.movePawn(this,p);
                }
                if(p.getName() == "white_bishop" || p.getName() == "black_bishop"){
                    return Moves.moveLine(this,p,1,1,7)
                        .Concat(Moves.moveLine(this,p,1,-1,7)).ToList()
                        .Concat(Moves.moveLine(this,p,-1,1,7)).ToList()
                        .Concat(Moves.moveLine(this,p,-1,-1,7)).ToList();
                }
                if(p.getName() == "white_rook" || p.getName() == "black_rook"){
                    return Moves.moveLine(this,p,1,0,7)
                        .Concat(Moves.moveLine(this,p,0,-1,7)).ToList()
                        .Concat(Moves.moveLine(this,p,-0,1,7)).ToList()
                        .Concat(Moves.moveLine(this,p,-1,0,7)).ToList();
                }
                if(p.getName() == "white_queen" || p.getName() == "black_queen"){
                    return Moves.moveLine(this,p,1,0,7)
                        .Concat(Moves.moveLine(this,p,0,-1,7)).ToList()
                        .Concat(Moves.moveLine(this,p,-0,1,7)).ToList()
                        .Concat(Moves.moveLine(this,p,-1,0,7)).ToList()
                        .Concat(Moves.moveLine(this,p,1,1,7)).ToList()
                        .Concat(Moves.moveLine(this,p,1,-1,7)).ToList()
                        .Concat(Moves.moveLine(this,p,-1,1,7)).ToList()
                        .Concat(Moves.moveLine(this,p,-1,-1,7)).ToList();
                }
                if(p.getName() == "white_king" || p.getName() == "black_king"){
                    return Moves.moveLine(this,p,1,0,1)
                        .Concat(Moves.moveLine(this,p,0,-1,1)).ToList()
                        .Concat(Moves.moveLine(this,p,-0,1,1)).ToList()
                        .Concat(Moves.moveLine(this,p,-1,0,1)).ToList()
                        .Concat(Moves.moveLine(this,p,1,1,1)).ToList()
                        .Concat(Moves.moveLine(this,p,1,-1,1)).ToList()
                        .Concat(Moves.moveLine(this,p,-1,1,1)).ToList()
                        .Concat(Moves.moveLine(this,p,-1,-1,1)).ToList()
                        .Concat(Moves.castle(this,p)).ToList();
                }
                if(p.getName()=="white_night"|| p.getName()=="black_night"){
                    return Moves.moveLine(this,p,2,1,1)
                        .Concat(Moves.moveLine(this,p,2,-1,1)).ToList()
                        .Concat(Moves.moveLine(this,p,-2,1,1)).ToList()
                        .Concat(Moves.moveLine(this,p,-2,-1,1)).ToList()
                        .Concat(Moves.moveLine(this,p,1,2,1)).ToList()
                        .Concat(Moves.moveLine(this,p,-1,2,1)).ToList()
                        .Concat(Moves.moveLine(this,p,1,-2,1)).ToList()
                        .Concat(Moves.moveLine(this,p,-1,-2,1)).ToList();
                }
            }
            return new List<Coordinates>();
        
        }
        public void move(Coordinates previousCoordinate, Coordinates newCoordinate){
            Piece Piece = getPiece(previousCoordinate); 
            if(Piece.getColor()==turn){   
                if((Piece.getName()  == "white_king" && getPiece(newCoordinate).getName() == "white_rook")||
                (Piece.getName()  == "black_king" && getPiece(newCoordinate).getName() == "black_rook"))  {
                    castle(Piece, newCoordinate);
                } else {    
                    pieces[previousCoordinate.x,previousCoordinate.y] = new Piece(previousCoordinate.x,previousCoordinate.y);
                    pieces[newCoordinate.x,newCoordinate.y] = new Piece(Piece.getName(),newCoordinate.x,newCoordinate.y);
                    pieces[newCoordinate.x,newCoordinate.y].hasMoved = true;
                    switchTurn();
                    if(!isCloned){
                        winner = checkWinner(turn);
                    }
                }
            }
        }

        public void castle(Piece king, Coordinates rook){
            if(king.getColor() == "white"){
                if(rook.x==7 && rook.y==0){
                pieces[4,0]=  new Piece(4,0);
                pieces[7,0]= new Piece(7,0);
                pieces[6,0]= new Piece("white_king",6,0);
                pieces[5,0]=  new Piece("white_rook",5,0);
                pieces[6,0].hasMoved = true;
                pieces[5,0].hasMoved= true;
                 switchTurn();
                }
                if(rook.x==0 && rook.y==0){
                pieces[4,0]=  new Piece(4,0);
                pieces[0,0]= new Piece(0,0);
                pieces[2,0]= new Piece("white_king",2,0);
                pieces[3,0]=  new Piece("white_rook",3,0);
                pieces[2,0].hasMoved = true;
                pieces[3,0].hasMoved= true;
                switchTurn();
                }
            } 
            if(king.getColor() == "black"){
                if(rook.x==7 && rook.y==7){
                pieces[4,7]=  new Piece(4,7);
                pieces[7,7]= new Piece(7,7);
                pieces[6,7]= new Piece("black_king",6,7);
                pieces[5,7]=  new Piece("black_rook",5,7);
                pieces[6,7].hasMoved = true;
                pieces[5,7].hasMoved= true;
                 switchTurn();
                }
                if(rook.x==0 && rook.y==7){
                pieces[4,7]=  new Piece(4,7);
                pieces[0,7]= new Piece(0,7);
                pieces[2,7]= new Piece("black_king",2,7);
                pieces[3,7]=  new Piece("black_rook",3,7);
                pieces[2,7].hasMoved = true;
                pieces[3,7].hasMoved= true;
                switchTurn();
                }
            }
        }
        
        public void print(){
            for(int x=0; x<8; x++){
                string res = "";
                for(int y=0; y<8; y++){
                    res += $" {pieces[y,x].getName()}"; 
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


public bool willCheck(Coordinates previousCoordinate, Coordinates newCoordinate){
    if(!isCloned){  
        Board newBoard = (Board)this.Clone();
        newBoard.move(previousCoordinate,newCoordinate);
        for(int x= 0 ; x< 8; x++){
            for(int y= 0 ; y< 8; y++){
                if((newBoard.getPiece(x,y).getName() == "white_king"||newBoard.getPiece(x,y).getName() == "black_king") && newBoard.getPiece(x,y).getColor() == turn){
                    newBoard.turn = turn;
                    return newBoard.isCheck(newBoard.getPiece(x,y));
                }
            }
        }
    }
    return false;
}


public bool isCheck (Piece piece){
    List<Coordinates> validMoves = new List<Coordinates>();
    Coordinates piecePosition = piece.coordinates;
    for(int x=0; x<8; x++){
        for(int y=0; y<8; y++){
            if(!(getPiece(x,y).equals(piece))){
                isCloned = true;
                if(getPiece(x,y).getName() != "null")validMoves = movePlate(getPiece(x,y),true);
                isCloned=false;
                foreach(Coordinates c in validMoves){
                    if(c.x== piecePosition.x && c.y== piecePosition.y){
                        return true;
                    }
                }
            }
        }
    }
    return false;
}

public string checkWinner(string color){
    if(isCheck(getKing(color))){
        for(int x=0; x<8; x++){
            for(int y= 0 ; y< 8; y++){
                if(getPiece(x,y).getColor() == color && getPiece(x,y).getName() != null){
                    if(movePlate(getPiece(x,y),false).Count>0)
                        return "null";
                }
            }
        }
        switchTurn();
        string res = color;
        switchTurn();
        return res;
    }
    return "null";
}

    public Piece getKing(string color){
        for(int x=0; x<8; x++){
            for(int y= 0 ; y< 8; y++){
                if(getPiece(x,y).getColor() == color &&(getPiece(x,y).getName() == "white_king"|| getPiece(x,y).getName() == "black_king")){
                    return getPiece(x,y);
                }
            }
        }
        return null;

    }

    public string toFen(){
        string res = "";
        int acc = 0;
        for(int y = 7;y>=0;y--){
            for(int x = 0;x<8;x++){
                if(getPiece(x,y).getName() != "null"){
                    if(acc>0){
                        res +=acc;
                        acc = 0;
                    }
                    char initial =getPiece(x,y).getName().Split("_")[1][0];
                    if(getPiece(x,y).getColor() == "white"){
                        res += (char)(initial-0x20);
                    }else{
                        res += initial;
                    }    
                } else{
                    acc++;
                }
            }
            if(acc>0)
                res+=acc;
            res+="/";
            acc = 0;
        }
        res += " " + turn[0];
        return res;
    }


    public string getWinner(){
        return winner;
    }
}    

