using System;
using System.Collections.Generic;
using Unity.VisualScripting;


public static class RandomVariables{
    public static double randomNormal(Random random ,double mean,double sd, double min, double max) {
        double u1 = random.NextDouble();
        double u2 = random.NextDouble();
        double res = mean+(sd *Math.Sqrt(-2*Math.Log(u1))*Math.Cos(2*Math.PI * u2));
        if (res > max || res < min) return randomNormal(random,mean,sd,min,max);
        return res;
    }
    
    public static string vaPromocao(Random random)
    {
        double probRainha = 0.5;
        double probTorre = 0.3;
        double probCavalo = 0.1;
        double escolha = random.NextDouble();
        if (escolha < probRainha)
            return "queen";
        else if (escolha < probRainha + probTorre)
            return "rook";
        else if (escolha < probRainha + probTorre + probCavalo)
            return "night";
        else 
            return "bishop";
    }

    public static bool willMove(Random random,int numAttackers){
        double prob = 2/(numAttackers+1.01);
        double res = random.NextDouble();
        return res<prob || prob<0;
    }

    
    public static Piece theSelectedEatenPiece(LinkedList<Piece> eatenPieces){
    if (eatenPieces.Count == 0){
        throw new InvalidOperationException("The list is empty.");
    }

    Random random = new Random();
    int randomIndex = random.Next(0, eatenPieces.Count);

    LinkedListNode<Piece> currentNode = eatenPieces.First;
    for (int i = 0; i < randomIndex; i++){
        currentNode = currentNode.Next;
    }
    Piece selectedPiece = currentNode.Value;
    eatenPieces.Remove(currentNode);

    return selectedPiece;
}      

  public static (Piece, Coordinates) vaRevive(LinkedList<Piece> eatenPieces,Board board)
{
    Piece selectedPiece = theSelectedEatenPiece(eatenPieces);
    List<Piece> empty = new List<Piece>();
    for(int x= 0 ; x< 8; x++){
        for(int y= 0 ; y< 8; y++){
            if(board.getPiece(x,y).getName() == "null")empty.Add(board.getPiece(x,y));
        }
    }
    Random random = new Random();
    Coordinates posicao = empty[random.Next(empty.Count-1)].getCoordinates();

    return (selectedPiece, posicao);

}

    public static bool convertPiece(Random random,Piece piece){
        double prob = 0.0;
        switch(piece.getName().Split("_")[1]){
            case "queen":
                prob = 0.1;
                break;
            case "rook":
                prob = 0.2;
                break;
            case "night":
                prob = 0.3;
                break;
            case "bishop":
                prob = 0.3;
                break;
            case "pawn":
                prob = 0.4;
                break;
        }
        return random.NextDouble() < prob;
    }
}