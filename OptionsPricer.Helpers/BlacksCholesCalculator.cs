using OptionsPricer.Models;
using System;
namespace OptionsPricer.Helpers
{
    public class BlacksCholesCalculator
    {
        #region Private Functions
        //Calculate the value of d1
        static double Calculate_d1(BlacksCholes b)
        {
            try
            {
                double d1 = ((Math.Log(b.S / b.K) + (b.r + Math.Pow(b.sigma, 2) / 2.0) * b.t)) / (b.sigma * Math.Sqrt(b.t));
                if (double.IsInfinity(d1))
                {
                    throw new DivideByZeroException();
                }
                return d1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Calculate the value of d2
        static double Calculate_d2( BlacksCholes b)
        {
            return b.d1 - b.sigma * Math.Sqrt(b.t);
        }

        //Calculate the value of Call price
        static double CalculateCallPrice( BlacksCholes b)
        {
            return b.S * NormalDistributionHelper.ND(b.d1) - b.K * Math.Exp(-b.r * b.t) * NormalDistributionHelper.ND(b.d2);
        }

        //Calculate the value of Put price
        static double CalculatePutPrice(BlacksCholes b)
        {
            return b.K * Math.Exp(-b.r * b.t) * NormalDistributionHelper.ND(-b.d2) - b.S * NormalDistributionHelper.ND(-b.d1);
        }
        #endregion

        #region Public Functions
        public static void CalculatePremium(ref BlacksCholes b)
        {
            b.d1 = Calculate_d1(b);
            b.d2 = Calculate_d2(b);
            b.Call = CalculateCallPrice(b);
            b.Put = CalculatePutPrice(b);
        }
        #endregion


    }
}
