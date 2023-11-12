using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Board;

public class Game : MonoBehaviour
{
    public GameObject black_pawn, black_queen, black_king, black_hourse, black_rook, black_bishop, white_pawn, white_queen, white_king, white_hourse, white_rook, white_bishop,lightTile, brownTile;

    public GameObject [,] squares = new GameObject[8,8];
   
    public Board board = new Board();
    private Vector3 iBoard = new Vector3(-31.53f,-31.53f,0);

    void Start()
    {
        createBoard();
    }

    void Update(){
        
    }

    void createBoard(){
        
        for(int x=0; x<8; x++){
            for(int y=0; y<8; y++){
                if((x+y)%2== 0) {
                    Instantiate(lightTile,iBoard + new Vector3(x*(9.01f),y*(9.01f),-1), Quaternion.identity);
                } else {
                    Instantiate(brownTile,iBoard + new Vector3(x*(9.01f),y*(9.01f),-1), Quaternion.identity);
                }
            }
        }
        for(int x=0; x<8; x++){
            for(int y=0; y<8; y++){
                GameObject cur = getSprite(board.getPiece(x,y));
                if(cur != null)
                    Instantiate(cur, iBoard + new Vector3(x*(9.01f),y*(9.01f),-2), Quaternion.identity);
            }
        }
    }

    public GameObject getSprite(int i){
            switch(i){
                case 1:
                    return white_pawn;
                case 2:
                    return white_bishop;
                case 3:
                    return white_hourse;
                case 4:
                    return white_rook;
                case 5:
                    return white_queen;
                case 6:
                    return white_king;
                case -1:
                    return black_pawn;
                case -2:
                    return black_bishop;
                case -3:
                    return black_hourse;
                case -4:
                    return black_rook;
                case -5:
                    return black_queen;
                case -6:
                    return black_king;
            }
            return null;
        }
}
