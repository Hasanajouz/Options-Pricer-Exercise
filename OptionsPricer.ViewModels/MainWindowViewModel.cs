using OptionsPricer.Helpers;
using OptionsPricer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace OptionsPricer.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            Title = "Options Pricer Exercise";
        }

        #region Properties
        double _s;
        public double S
        {
            get { return _s; }
            set { SetProperty(ref _s, value); }
        }

        double _k;
        public double K
        {
            get { return _k; }
            set { SetProperty(ref _k, value); }
        }

        double _t;
        public double t
        {
            get { return _t; }
            set { SetProperty(ref _t, value); }
        }

        double _sigma;
        public double sigma
        {
            get { return _sigma; }
            set { SetProperty(ref _sigma, value); }
        }

        double _r;
        public double r
        {
            get { return _r; }
            set { SetProperty(ref _r, value); }
        }

        double _callPrice;
        public double CallPrice
        {
            get { return _callPrice; }
            set { SetProperty(ref _callPrice, value); }
        }

        double _putPrice;
        public double PutPrice
        {
            get { return _putPrice; }
            set { SetProperty(ref _putPrice, value); }
        }

        string _errorMsg;
        public string ErrorMsg
        {
            get { return _errorMsg; }
            set { SetProperty(ref _errorMsg, value); }
        }

        public ICommand CalculatePricesCommand
        {
            get { return new DelegateCommand(CalculatePrices); }
        }
        #endregion

        #region Commands
        private void CalculatePrices()
        {
            if (S <= 0 || K <= 0 || r <= 0 || t <= 0 || sigma <= 0)
            {
                ErrorMsg = "Please, fill all fields with values >0";
                return;
            }
            else
            {
                ErrorMsg = "";
                try
                {
                    var bc = new BlacksCholes { S = S, K = K, r = r, sigma = sigma, t = t };
                    BlacksCholesCalculator.CalculatePremium(ref bc);
                    CallPrice = bc.Call;
                    PutPrice = bc.Put;
                }
                catch (DivideByZeroException ex)
                {
                    ErrorMsg = "if you use / make sure to add .0 to the end of the number for example 180/365.0";
                    return;
                }
                catch (Exception ex)
                {
                    ErrorMsg = ex.Message;
                    return;
                }

            }
        } 
        #endregion
    }
}
