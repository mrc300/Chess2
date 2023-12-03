﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RndVars
{
    public static class RandomVariables{
        public static double randomNormal(Random random ,double mean,double sd, double min, double max) {
            double u1 = random.NextDouble();
            double u2 = random.NextDouble();
            double res = mean+(sd*Math.Sqrt(-2 * Math.Log(u1))*Math.Cos(2*Math.PI*u2));
            if (res > max || res < min) return randomNormal(random,mean,sd,min,max);
            return res;
        }

        public static double normalArea(double mean, double sd, double val)
        {
            return 0.5*(1+Erf((val-mean)/(sd*Math.Sqrt(2))));
        }


        static double Erf(double x)
        {
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return sign * y;
        }

    }
}
