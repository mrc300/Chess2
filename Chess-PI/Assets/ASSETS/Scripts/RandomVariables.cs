using System;


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
}