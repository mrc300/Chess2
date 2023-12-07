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





    public static string vaPromocao()
    {
        double probRainha = 0.5;
        double probTorre = 0.3;
        double probCavalo = 0.1;
        double probBispo = 0.1;
        double escolha = new Random().NextDouble();
        if (escolha < probRainha)
            return "queen";
        else if (escolha < probRainha + probTorre)
            return "rook";
        else if (escolha < probRainha + probTorre + probCavalo)
            return "night";
        else 
            return "bishop";
    }



    public class Prioridades {


       public string name;
       public double prioridade;
        public Prioridades(string name, double prioridade){
            this.name= name;
            this.prioridade = prioridade;
        }
        
    }
    public static string vaRevive(LinkedList<Piece> eatenPieces){

        LinkedList<Prioridades> eaten= new LinkedList<Prioridades>();
        LinkedList<Prioridades> prioridades = new LinkedList<Prioridades>();
         prioridades.AddLast(new Prioridades("queen", 10));
         prioridades.AddLast(new Prioridades("night", 5));
         prioridades.AddLast(new Prioridades("bishop", 5));
         prioridades.AddLast(new Prioridades("rook", 8));
         prioridades.AddLast(new Prioridades("pawn", 8));
         foreach(Piece aux in eatenPieces){
            foreach(Prioridades aux2 in prioridades){
                if(aux.getName().Split("_")[1]== aux2.name){
                    eaten.AddLast(aux2);
                }
            }
         }
         double total= 0;
         foreach(Prioridades aux in prioridades){
            total += aux.prioridade;
         } 
        LinkedList<Prioridades> conversions= new LinkedList<Prioridades>();
         foreach(Prioridades aux in prioridades){
            double newPrioridade = aux.prioridade / total;
            Prioridades novo = new Prioridades(aux.name, newPrioridade);
            conversions.AddLast(novo);
         } 
             Random random = new Random();
        double randomValue = random.NextDouble();
        double cumulativeProbability = 0;

        foreach (Prioridades conversion in conversions)
        {
            cumulativeProbability += conversion.prioridade;

            if (randomValue <= cumulativeProbability)
            {
                return conversion.name;
            }
        }     
        return null;
    }
        
    


    







}