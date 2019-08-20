using System;
using System.Collections.Generic;
using System.Text;

namespace OptionsPricer.Helpers
{
    public static class NormalDistributionHelper
    {
        //Calculate Normal Distribution
        public static double ND(double x)
        {
            return .5 * (1.0 + erf(x / Math.Sqrt(2.0)));
        }

        #region Private Props
        static int ITMAX = 100;
        static double EPS = 3.0e-7;
        #endregion

        #region Private helper Functions
        static double gammln(double xx)
        {
            double[] cof = { 76.18009173, -86.50532033, 24.01409822, -1.231739516, 0.120858003e-2, -0.536382e-5 };
            int j;
            double x = xx - 1.0;
            double tmp = x + 5.5;
            tmp -= (x + 0.5) * Math.Log(tmp);
            double ser = 1.0;
            for (j = 0; j <= 5; j++)
            {
                x += 1.0;
                ser += cof[j] / x;
            }
            return -tmp + Math.Log(2.50662827465 * ser);
        }

        static public void gser(ref double gamser, double a, double x, ref double gln)
        {
            int n;
            double sum, del, ap;
            gln = gammln(a);
            if (x <= 0.0)
            {
                gamser = 0.0;
                return;
            }
            else
            {
                ap = a;
                sum = 1.0 / a;
                del = sum;
                for (n = 1; n <= ITMAX; n++)
                {
                    ap += 1.0;
                    del *= x / ap;
                    sum += del;
                    if (Math.Abs(del) < (Math.Abs(sum) * EPS))
                    {
                        gamser = sum * Math.Exp(-x + a * (Math.Log(x)) - gln);
                        return;
                    }
                }
                return;
            }
        }
        static public void gcf(ref double gammcf, double a, double x, ref double gln)
        {
            int n;
            double gold = 0.0, g, fac = 1.0, b1 = 1.0;
            double b0 = 0.0, anf, ana, an, a1, a0 = 1.0;
            gln = gammln(a);
            a1 = x;
            for (n = 1; n <= ITMAX; n++)
            {
                an = (double)n;
                ana = an - a;
                a0 = (a1 + a0 * ana) * fac;
                b0 = (b1 + b0 * ana) * fac;
                anf = an * fac;
                a1 = x * a0 + anf * a1;
                b1 = x * b0 + anf * b1;
                if (a1 > 0.0 || a1 < 0.0)
                {
                    fac = 1.0 / a1;
                    g = b1 * fac;
                    if (Math.Abs((g - gold) / g) < EPS)
                    {
                        gammcf = Math.Exp(-x + a * Math.Log(x) - (gln)) * g;
                        return;
                    }
                    gold = g;
                }
            }
        }

        static double gammp(double a, double x)
        {
            double gamser = 0.0;
            double gammcf = 0.0;
            double gln = 0.0;
            if (x < 0.0 || a <= 0.0) return 0.0;
            if (x < (a + 1.0))
            {
                gser(ref gamser, a, x, ref gln);
                return gamser;
            }
            else
            {
                gcf(ref gammcf, a, x, ref gln);
                return 1.0 - gammcf;
            }
        }

        static double erf(double x)
        {
            return x < 0.0 ? -gammp(0.5, x * x) : gammp(0.5, x * x);
        } 
        #endregion

    }
}
