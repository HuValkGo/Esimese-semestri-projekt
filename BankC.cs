using System;
namespace EKSAM_OIGE
{
    public class BankC:BankB
    {
        internal double _exhange2;
        internal string _currencyName1;
        internal string _currencyName2;
        internal DayOfWeek day = DateTime.Now.DayOfWeek;
        public BankC()
        {
        }
        public bool CalculateCurrencyToAnotherCurrency(double amount, string countryA, string countryB)
        {
            if (CalulatorForCurrencyToCurrency(amount,countryA,countryB))
            {
                Console.WriteLine(_amount + " " + _currencyName1 + " is " + _exhange2 + " " + _currencyName2);
                return true;
            }
            return false; 
        }
        internal bool CalulatorForCurrencyToCurrency(double amount, string countryA, string countryB)
        {
            if (GetExhange(countryA))
            {
                _amount = amount;
                _exhange = _exhange+(_amount / double.Parse(_currency));
                _currencyName1 = _currencyName;
                if (GetExhange(countryB))
                {
                    _currencyName2 = _currencyName;
                    _exhange2 = Math.Round(_exhange * double.Parse(_currency), 0, MidpointRounding.ToZero);
                    return true;
                }
            }
            return false;
        }
        public double ExchangeCurrencyFromAToB(double amount, string countryA,string countryB)
        {
            if (day == DayOfWeek.Tuesday)
            {
                _bankFee = 0;
            }
            else
            {
                _exhange = _exhange - amount * 0.1;
            }
            if (CalulatorForCurrencyToCurrency(amount, countryA, countryB))
            {
                _exhange -= _bankFee;
                _exhange2 = Math.Round(_exhange * double.Parse(_currency), 0, MidpointRounding.ToZero);
                if (_exhange2 > 0)
                {
                    Console.WriteLine("Money exchanged! Service fee is " + _bankFee + "euros. " + amount + " " + _currencyName1 + " gives you " + _exhange2 + " " + _currencyName2 + "(s)");
                    return _exhange2;
                }
                else
                {
                    Console.WriteLine("Can not exhange");
                    return 0;
                }
            }
            return 0;
        }
    }
}
