using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EKSAM_OIGE
{
    public class CurrencyExhance
    {
        internal List<string> _currencyNames = new List<string>();
        internal List<string> _countrys = new List<string>();
        internal List<string> _currencys = new List<string>();
        internal List<string> _currencyNamesInEstonian = new List<string>();
        internal double _amount;
        internal double _exhange;
        internal string _currencyName;
        internal string _currency;
        public CurrencyExhance()
        {
            ReadFromFile();
        }
        public bool GetExchangeRate(string country)
        {
            _amount = 1;            
            if (GetExhange(country))
            {
                Console.WriteLine(_amount + " EUR is " +_currency+ " " + _currencyName);
                return true;
            }
            return false;
        }
        internal bool GetExhange(string country)
        {
            country = country.ToUpper();
            for (int i = 0; i <= _currencyNames.Count() - 1; i++)
            {
                if (_currencyNames[i].Contains(country) || _countrys[i].ToUpper().Contains(country))
                {
                    _currencyName = _currencyNames[i];
                    _currency = _currencys[i];
                    return true;
                }
            }
            Console.WriteLine("Invalid currency name or country name!");
            return false;
        }
        public virtual bool CalculateCurrency(double amount,string country)
        {
            _amount = amount;
            if (GetExhange(country))
            {
                _exhange = double.Parse(_currency) * _amount;
                Console.WriteLine(_amount + " EUR is " + _exhange.ToString() + " " + _currencyName);
                return true;
            }
            return false;
        }
        private void ReadFromFile()
        {
            using(StreamReader reader = new StreamReader("currency.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] split = line.Split(" ");
                    string currencyName = split[0].ToUpper();
                    string country = split[1].ToUpper();
                    string currencyNameInEstonian = split[2].ToLower();
                    string currency = split[3];                  
                    _currencyNames.Add(currencyName);
                    _currencys.Add(currency);
                    _countrys.Add(country);
                    _currencyNamesInEstonian.Add(currencyNameInEstonian);
                }
            }
        }
    }
}
