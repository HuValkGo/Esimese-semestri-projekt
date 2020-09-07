using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace EKSAM_OIGE
{
    public class BankB:BankA
    {
        internal int _minimalExchangeAmount;
        internal List<string> _currencyUsedInCountrys = new List<string>();
        internal List<string> empty = new List<string>();
        public BankB()
        {
            _bankFee = 2;
            _minimalExchangeAmount = 20;
            _montlyPercentage = 0.25;
            _intressRate = 1.021;
        }
        public override double ExchangeCurrency(double amount, string country)
        {
            if (amount >= _minimalExchangeAmount)
            {
                _exhange = _exhange - amount * 0.1;
                base.ExchangeCurrency(amount, country);                
                return _exhange;
            }
            Console.WriteLine("Not enought money to exhange currency!");
            return 0;
        }
        public bool FindCurrencies(string currencyNameInEstonian)
        {
            currencyNameInEstonian =currencyNameInEstonian.ToLower().Trim();
            for (int i = 0; i <= _currencyNamesInEstonian.Count() - 1; i++)
            {
                if (_currencyNamesInEstonian[i].Contains(currencyNameInEstonian))
                {
                    _currencyUsedInCountrys.Add(_countrys[i]+" "+_currencyNamesInEstonian[i]);
                }
            }
            if (_currencyUsedInCountrys.Count() != 0)
            {
                Console.Write("Currencies with name ''"+ currencyNameInEstonian+"' are: ");
                foreach (string country in _currencyUsedInCountrys)
                {
                    Console.Write(country + ", ");
                }
                Console.WriteLine();
                _currencyUsedInCountrys.Clear();
                return true;
            }
            Console.WriteLine("Invalid Name");
            return false;
        }
        public override double CalculateMaxLoan()
        {
            if (_age < 65)
            {
                _maximumLoanTime = 65 - _age;
                if (_maximumLoanTime >= 30)
                {
                    _maximumLoanTime = 30;
                }
                base.CalculateMaxLoan();
                return _maximumLoan;
            }
            return 0;
        }
    }
}
 
