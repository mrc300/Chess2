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
        double prob = 1/(numAttackers+0.1);
        double res = random.NextDouble();
        return res<prob || prob<0;
    }

    public class Prioridades {


       public string name;
       public double prioridade;
        public Prioridades(string name, double prioridade){
            this.name= name;
            this.prioridade = prioridade;
        }
        
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
  
    
     static double GerarPosicaoGaussiana(double media, double desvioPadrao)
    {
        Random rand = new Random();
        double u = rand.NextDouble(); 
        double z = Math.Sqrt(-2.0 * Math.Log(u)) * Math.Cos(2.0 * Math.PI * rand.NextDouble());

        
        double posicao = media + desvioPadrao * z;

        return posicao;
    }
    

    

  public static (Piece, Coordinates) vaRevive(LinkedList<Piece> eatenPieces)
{
    Piece selectedPiece = theSelectedEatenPiece(eatenPieces);
    double a = GerarPosicaoGaussiana(50, 10);
    double b = GerarPosicaoGaussiana(50, 10);
    
    int x = (int) Math.Round((a*3)/50);
    int y = (int) Math.Round((b*3)/50);
    if(x>=8){
        x=8 ;
    }
    if(y>=8){
        y=8 ;
    }

    Coordinates posicao = new Coordinates(x, y);
    return (selectedPiece, posicao);

}






















}