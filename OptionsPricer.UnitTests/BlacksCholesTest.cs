using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptionsPricer.Helpers;
using OptionsPricer.Models;

namespace OptionsPricer.UnitTests
{
    [TestClass]
    public class BlacksCholesTest
    {
        [TestMethod]
        [DataRow(50, 55, 1, 0.2, 0.09, 3.8617)]
        [DataRow(64,60, 180 / 365.0,0.27,0.045, 7.7661)]
        public void CalculateCallPrice(double S,double K,double t, double sigma,double r,double callPrice)
        {
            //Arrange
            var blacksCholes = new BlacksCholes { S = S, K = K, t = t, sigma = sigma, r = r };

            //Act
            BlacksCholesCalculator.CalculatePremium(ref blacksCholes);

            //Assert
            Assert.AreEqual(callPrice, Math.Round(blacksCholes.Call,4));

        }


        [TestMethod]
        [DataRow(50, 55, 1, 0.2, 0.09, 4.1279)]
        [DataRow(64, 60, 180 / 365.0, 0.27, 0.045, 2.4493)]
        public void CalculatePutPrice(double S, double K, double t, double sigma, double r, double putPrice)
        {
            //Arrange
            var blacksCholes = new BlacksCholes { S = S, K = K, t = t, sigma = sigma, r = r };

            //Act
            BlacksCholesCalculator.CalculatePremium(ref blacksCholes);

            //Assert
            Assert.AreEqual(putPrice, Math.Round(blacksCholes.Put, 4));

        }

        [TestMethod]
        [DataRow(50, 55, 1, 0.2, 0.09, 0.0734)]
        [DataRow(64, 60, 180 / 365.0, 0.27, 0.045, 0.5522)]
        public void Calculate_d1(double S, double K, double t, double sigma, double r, double d1)
        {
            //Arrange
            var blacksCholes = new BlacksCholes { S = S, K = K, t = t, sigma = sigma, r = r };

            //Act
            BlacksCholesCalculator.CalculatePremium(ref blacksCholes);

            //Assert
            Assert.AreEqual(d1, Math.Round(blacksCholes.d1, 4));

        }

        [TestMethod]
        [DataRow(50, 55, 1, 0.2, 0.09, -0.1266)]
        [DataRow(64, 60, 180 / 365.0, 0.27, 0.045, 0.3626)]
        public void Calculate_d2(double S, double K, double t, double sigma, double r, double d2)
        {
            //Arrange
            var blacksCholes = new BlacksCholes { S = S, K = K, t = t, sigma = sigma, r = r };

            //Act
            BlacksCholesCalculator.CalculatePremium(ref blacksCholes);

            //Assert
            Assert.AreEqual(d2, Math.Round(blacksCholes.d2, 4));

        }

    }
}
