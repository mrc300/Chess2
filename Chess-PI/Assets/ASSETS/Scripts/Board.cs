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
using UnityEngine.UIElements;
public class Board {
<<<<<<< HEAD
        private Piece [,] Pieces = new Piece[8,8];
=======
        

        private Piece [,] pieces = new Piece[8,8];
        private bool isCloned = false;
        private string winner = "null";
>>>>>>> parent of 3f2d89d (Revert "merda")
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

<<<<<<< HEAD
        public List<Coordinates> movePlate(Piece p){
            if(p.getName() == "white_pawn"){
                return Moves.movePawn(this,p);
=======
        public List<Coordinates> movePlate(Piece p,bool bothColors){
            if(p.getColor() == turn || bothColors || true){
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
                if(p.getName()=="white_hourse"|| p.getName()=="black_hourse"){
                    return Moves.moveLine(this,p,2,1,1)
                        .Concat(Moves.moveLine(this,p,2,-1,1)).ToList()
                        .Concat(Moves.moveLine(this,p,-2,1,1)).ToList()
                        .Concat(Moves.moveLine(this,p,-2,-1,1)).ToList()
                        .Concat(Moves.moveLine(this,p,1,2,1)).ToList()
                        .Concat(Moves.moveLine(this,p,-1,2,1)).ToList()
                        .Concat(Moves.moveLine(this,p,1,-2,1)).ToList()
                        .Concat(Moves.moveLine(this,p,-1,-2,1)).ToList();
                }
>>>>>>> parent of 3f2d89d (Revert "merda")
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
            if(p.getName()=="white_hourse"|| p.getName()=="black_hourse"){
                 return Moves.moveLine(this,p,2,1,1)
                    .Concat(Moves.moveLine(this,p,2,-1,1)).ToList()
                    .Concat(Moves.moveLine(this,p,-2,1,1)).ToList()
                    .Concat(Moves.moveLine(this,p,-2,-1,1)).ToList()
                    .Concat(Moves.moveLine(this,p,1,2,1)).ToList()
                    .Concat(Moves.moveLine(this,p,-1,2,1)).ToList()
                    .Concat(Moves.moveLine(this,p,1,-2,1)).ToList()
                    .Concat(Moves.moveLine(this,p,-1,-2,1)).ToList();
            }
            return null;
        
        }
        public void move(Coordinates previousCoordinate, Coordinates newCoordinate, Piece Piece){ 
            if(Piece.getColor()==turn){   
<<<<<<< HEAD
            if((Piece.getName()  == "white_king" && getPiece(newCoordinate).getName() == "white_rook")||
             (Piece.getName()  == "black_king" && getPiece(newCoordinate).getName() == "black_rook"))  {
                 castle(Piece, newCoordinate);
            } else {    
            Pieces[previousCoordinate.x,previousCoordinate.y] = new Piece(previousCoordinate.x,previousCoordinate.y);
            Pieces[newCoordinate.x,newCoordinate.y] = new Piece(Piece.getName(),newCoordinate.x,newCoordinate.y);
            Pieces[newCoordinate.x,newCoordinate.y].hasMoved = true;
              switchTurn();
            }
           
=======
                if((Piece.getName()  == "white_king" && getPiece(newCoordinate).getName() == "white_rook")||
                (Piece.getName()  == "black_king" && getPiece(newCoordinate).getName() == "black_rook"))  {
                    castle(Piece, newCoordinate);
                } else {    
                    pieces[previousCoordinate.x,previousCoordinate.y] = new Piece(previousCoordinate.x,previousCoordinate.y);
                    pieces[newCoordinate.x,newCoordinate.y] = new Piece(Piece.getName(),newCoordinate.x,newCoordinate.y);
                    pieces[newCoordinate.x,newCoordinate.y].hasMoved = true;
                    switchTurn();
                    Piece king = getKing(turn);
                    if(!isCloned){
                        Debug.Log(king.getName()+" "+ king.coordinates.x + " " + king.coordinates.y +" isChek:"+isCheck(king));
                        if(isCheck(king) && movePlate(king,false).Count == 0){
                            switchTurn();
                            winner=turn;
                        }
                    }
                }
>>>>>>> parent of 3f2d89d (Revert "merda")
            }
        }

        public void castle(Piece king, Coordinates rook){
            if(king.getColor() == "white"){
                if(rook.x==7 && rook.y==0){
                Pieces[4,0]=  new Piece(4,0);
                Pieces[7,0]= new Piece(7,0);
                Pieces[6,0]= new Piece("white_king",6,0);
                Pieces[5,0]=  new Piece("white_rook",5,0);
                Pieces[6,0].hasMoved = true;
                Pieces[5,0].hasMoved= true;
                 switchTurn();
                }
                if(rook.x==0 && rook.y==0){
                Pieces[4,0]=  new Piece(4,0);
                Pieces[0,0]= new Piece(0,0);
                Pieces[2,0]= new Piece("white_king",2,0);
                Pieces[3,0]=  new Piece("white_rook",3,0);
                Pieces[2,0].hasMoved = true;
                Pieces[3,0].hasMoved= true;
                switchTurn();
                }
            } 
            if(king.getColor() == "black"){
                if(rook.x==7 && rook.y==7){
                Pieces[4,7]=  new Piece(4,7);
                Pieces[7,7]= new Piece(7,7);
                Pieces[6,7]= new Piece("black_king",6,7);
                Pieces[5,7]=  new Piece("black_rook",5,7);
                Pieces[6,7].hasMoved = true;
                Pieces[5,7].hasMoved= true;
                 switchTurn();
                }
                if(rook.x==0 && rook.y==7){
                Pieces[4,7]=  new Piece(4,7);
                Pieces[0,7]= new Piece(0,7);
                Pieces[2,7]= new Piece("black_king",2,7);
                Pieces[3,7]=  new Piece("black_rook",3,7);
                Pieces[2,7].hasMoved = true;
                Pieces[3,7].hasMoved= true;
                switchTurn();
                }
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


<<<<<<< HEAD
public bool inCheck (Piece piece){
        List<Coordinates> validMoves;
        Coordinates piecePosition = piece.coordinates;
            for(int x=0; x<8; x++){
            for(int y=0; y<8; y++){
                if(!(getPiece(x,y).equals(piece))){
                validMoves = movePlate(getPiece(x,y));
=======
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
                if(getPiece(x,y).getName() != "null")validMoves = movePlate(getPiece(x,y),false);
>>>>>>> parent of 3f2d89d (Revert "merda")
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

    public string getWinner(){
        return winner;
    }




}    

