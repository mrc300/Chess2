using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Coordinates;
using static Board;
using static Piece;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using TMPro;
using static mainMenu;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
public class Game : MonoBehaviour
{
    public GameObject black_pawn, black_queen, black_king, black_night, black_rook, black_bishop, white_pawn, white_queen, white_king, white_night, white_rook, white_bishop,lightTile, brownTile,movePlate,Null,whiteReviveButton,blackReviveButton;
    public TextMeshProUGUI winnerText;
    public TextMeshProUGUI whiteTimerText;
    public TextMeshProUGUI blackTimerText;
    private Timer whiteTimer,blackTimer;

    public static bool multiplayer;
    public Board board;
    private Vector3 iBoard = new Vector3(-31.53f,-31.53f,0);
    private bool whiteRevive = false;
    private bool blackRevive = false;
    private Piece previousPiece = null;
    private StockFish stockFish;
    private List<Coordinates> previousValidMoves = new List<Coordinates>();
    private Vector3 previousUnityCoords;
    void Start()
    {   
        multiplayer = mainMenu.multiplayer;
        board = new Board(multiplayer);
        createBoard();
        if(multiplayer)stockFish = new StockFish();
        whiteTimer= new Timer(whiteTimerText);
        blackTimer= new Timer(blackTimerText);
        float minutes = mainMenu.input;   //em minutos!!!
        whiteTimer.setTime(minutes);
        blackTimer.setTime(minutes);   
        whiteTimerText.enabled = true;
        whiteTimer.setTimerText();
        blackTimerText.enabled = true;
        blackTimer.setTimerText();
        whiteReviveButton.SetActive(false);
        blackReviveButton.SetActive(false);
    }

    void Update(){
        if(board.whiteEatenPieces.Count >=3 && whiteRevive == false) {
        whiteReviveButton.SetActive(true);
        whiteRevive = true;
        }
        if(board.blackEatenPieces.Count >=3 && blackRevive == false && !multiplayer ){
        blackReviveButton.SetActive(true);
        blackRevive = true;
        }
       // board.showEatenPieces();
        if(board.turn == "white"){
            whiteTimer.run();
           //Debug.Log(RandomVariables.vaPromocao());
        }
        if(board.turn == "black"){
            blackTimer.run();
        }
        if(board.getWinner() == "null" && whiteTimer.running == true && blackTimer.running == true ){
            if(board.vsAi&& board.turn=="black"){
                board.aiMove();
                refresh();
            }
            if(Input.GetMouseButtonDown(0)) {
                var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseWorldPos.z = 0f; // zero z
                Coordinates offsetWorldPos = new Coordinates(mouseWorldPos);
                if(offsetWorldPos.insideBoard()){
                    //Debug.Log($"{(int)(offsetWorldPos.x)} , {(int)(offsetWorldPos.y)}");
                    Piece clickedPiece = board.getPiece(offsetWorldPos.x, offsetWorldPos.y);
                    if(clickedPiece.getName() != "null" || previousPiece != null){
                        if (previousPiece != null){
                            removeMovePlates();
                            if(offsetWorldPos.inVector(previousValidMoves)){
                                if(board.turn == "white")
                                    whiteTimer.increment();
                                else
                                    blackTimer.increment();
                                movePiece(previousPiece.coordinates,offsetWorldPos,previousPiece);
                                Debug.Log(stockFish.getBestMove(board.toFen()));
                            }
                            previousValidMoves = null;
                            previousPiece = null;
                        } else {
                            List<Coordinates> validMoves = board.movePlate(clickedPiece,false);
                            createmovePlate(validMoves, offsetWorldPos);
                            previousValidMoves = validMoves;
                            previousPiece = clickedPiece;
                        }             
                    }
                    previousUnityCoords= mouseWorldPos;
                }
            }
        }
        if(blackTimer.running == false) {
            winnerText.enabled = true;
            winnerText.SetText("white");
        }
         if(whiteTimer.running == false) {
             winnerText.enabled = true;
            winnerText.SetText("black");
        }
        if(board.getWinner() != "null") {
            Debug.Log(board.getWinner());
            winnerText.enabled = true;
            winnerText.SetText(board.getWinner());
            whiteTimer.stop();
            blackTimer.stop();
        }
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
                GameObject cur = getSprite(board.getPiece(x,y).getName());
                if(cur != null){
                   GameObject aux= Instantiate(cur, iBoard + new Vector3(x*(9.01f),y*(9.01f),-2), Quaternion.identity);
                   aux.tag="Piece";
                }
            }
        }
    }

    void createmovePlate(List<Coordinates> coordenadas,Coordinates current){
        removeMovePlates();
        if(coordenadas!=null){
        GameObject aux = Instantiate(movePlate, iBoard + new Vector3(current.x*(9.01f),current.y*(9.01f),-2), Quaternion.identity);
         aux.tag = "movePlate";
        for(int i=0; i<coordenadas.Count; i++){
             GameObject cur = getSprite("movePlate");
             GameObject movePlate = Instantiate(cur, iBoard + new Vector3(coordenadas[i].x*(9.01f),coordenadas[i].y*(9.01f),-2), Quaternion.identity);
             movePlate.tag = "movePlate";
            
        }
        }
    }

    void removeMovePlates() {
    foreach (GameObject movePlate in GameObject.FindGameObjectsWithTag("movePlate"))
    {    
        Destroy(movePlate);
    }
}


    void placePieces(){
        for(int x=0; x<8; x++){
            for(int y=0; y<8; y++){
                GameObject cur = getSprite(board.getPiece(x,y).getName());
                if(cur != null && board.getPiece(x,y).getName()!= "null"){
                    GameObject nObj = Instantiate(cur, iBoard + new Vector3(x*(9.01f),y*(9.01f),-2), Quaternion.identity);
                    nObj.tag = "Piece";
                }
            }
        }
    }
    void movePiece(Coordinates previousCoordinate,Coordinates newCoordinate, Piece Piece){
        board.move(previousCoordinate,newCoordinate);
        refresh();
    }





    public GameObject getSprite(string name){
            switch(name){
                case "white_pawn":
                    return white_pawn;
                case "white_bishop":
                    return white_bishop;
                case "white_night":
                    return white_night;
                case "white_rook":
                    return white_rook;
                case "white_queen":
                    return white_queen;
                case "white_king":
                    return white_king;
                case "black_pawn":
                    return black_pawn;
                case "black_bishop":
                    return black_bishop;
                case "black_night":
                    return black_night;
                case "black_rook":
                    return black_rook;
                case "black_queen":
                    return black_queen;
                case "black_king":
                    return black_king;
                case "movePlate":
                    return movePlate;
                case "null":
                    return Null;
            }
            return null;
        }



void removePieces()
{
    foreach (GameObject PieceObject in GameObject.FindGameObjectsWithTag("Piece"))
    {
        Destroy(PieceObject);
    }
}

void refresh(){
    removePieces();
    placePieces();
}


public void whiteReviveOnclick(){
    if(board.turn == "white" && !board.isCheck(board.getKing("white"))){
        board.whiteRevive();
        whiteReviveButton.SetActive(false);
    removePieces();
        for(int x=0; x<8; x++){
            for(int y=0; y<8; y++){
                GameObject cur = getSprite(board.getPiece(x,y).getName());
                if(cur != null && board.getPiece(x,y).getName()!= "null"){
                    GameObject nObj = Instantiate(cur, iBoard + new Vector3(x*(9.01f),y*(9.01f),-2), Quaternion.identity);
                    nObj.tag = "Piece";
                }
            }
        }
        }
    }
    public void blackReviveOnclick(){
        if(board.turn== "black" && !board.isCheck(board.getKing("black"))){
        board.blackRevive();
        blackReviveButton.SetActive(false);
        removePieces();
        for(int x=0; x<8; x++){
            for(int y=0; y<8; y++){
                GameObject cur = getSprite(board.getPiece(x,y).getName());
                if(cur != null && board.getPiece(x,y).getName()!= "null"){
                    GameObject nObj = Instantiate(cur, iBoard + new Vector3(x*(9.01f),y*(9.01f),-2), Quaternion.identity);
                    nObj.tag = "Piece";
                }
            }
        }
        }
    }







}


