using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Board {
        private int [,] pieces = new int[8,8];
        
        public Board(){
            for(int i = 0;i<8;i++){
                pieces[i,1] = 1;
                pieces[i,6] = -1;
            }
            for(int i = 0; i < 4;i++){
                pieces[i,0] = 4-i;
                pieces[i,7] = -4+i;
                pieces[7-i,0] = 4-i;
                pieces[7-i,7] = -4+i;
            }
            pieces[3,0] = 5;
            pieces[3,7] = -5;
            pieces[4,0] = 6;
            pieces[4,7] = -6;
            
        }

        public int getPiece(int x,int y){
            return pieces[x,y];
        }

       

    }
