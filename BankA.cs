using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace EKSAM_OIGE
{
    public class BankA:CurrencyExhance
    {
        internal int _bankFee;
        internal string _name;
        internal int _age;
        internal int _monthlyIncome;
        internal int _currentMonthlyObligations;
        internal double _freeMoney;
        internal int _maximumLoanTime;
        internal double _montlyPercentage;
        internal double _maxMonthlyPayment;
        internal double _initialLoanCredit;
        internal double _intressRate;
        internal double _maximumLoan;
        internal List<string> _userInfo = new List<string>();
        public BankA()
        {
            _bankFee = 4;
            _maximumLoanTime = 30;
            _montlyPercentage = 0.3;
            _intressRate = 1.012;
            
        }
        public virtual double ExchangeCurrency(double amount, string country)
        {
            if(GetExhange(country))
            {
                if (_bankFee < amount)
                {
                    _amount = amount;
                    _exhange = Math.Round((_exhange+double.Parse(_currency) * _amount) - _bankFee,0,MidpointRounding.ToZero);
                    Console.WriteLine("Money exchanged! Service fee is " + _bankFee + ". " + _amount + " EUR gives you " + _exhange + " " + _currencyName + "(s)");
                    return _exhange;
                }
                Console.WriteLine("Not enought money to exhange currency!");
            }
            return 0;       
        }
        public bool AddCustomerData(string name, int age, int monthlyIncome,int currentMonthlyObligations)
        {
            if (name.Length >= 4)
            {
                _name = name;
                _age = age;
                _monthlyIncome = monthlyIncome;
                _currentMonthlyObligations = currentMonthlyObligations;
                _freeMoney = _monthlyIncome - _currentMonthlyObligations;
                return true;
            }
            Console.WriteLine("Invalid Name!");
            return false;
        }
        public virtual double CalculateMaxLoan()
        {
            if (CheckName())
            {
                _maxMonthlyPayment = _freeMoney * _montlyPercentage;
                _maximumLoan = _maxMonthlyPayment * 12 * _maximumLoanTime;
                return _maximumLoan;
            }
            return 0;
        }
        internal bool CheckName()
        {
            if (_name != null&&_name.Length>=4)
            {
                return true;
            }
            Console.WriteLine("Please enter your user information first with AddCustomerData method!");
            return false;
        }
        public bool CanGetLoan()
        {
            if (CheckName())
            {
                CalculateMaxLoan();
                if (_freeMoney - _maxMonthlyPayment > 200)
                {
                    return true;
                }
            }
            Console.WriteLine("You can not get Loan");
            return false;
        }
        public double GetLoan(double loanAmount)
        {
            if (CanGetLoan())
            {
                _initialLoanCredit += loanAmount;
                if (_initialLoanCredit <= _maximumLoan)
                {
                    _maximumLoan = Math.Round(_maximumLoan - _initialLoanCredit,2, MidpointRounding.ToEven);
                    Console.WriteLine("Gave loan in sum " + loanAmount + ", loan total is " + _initialLoanCredit);
                    Console.WriteLine("New max loan amount is: " + _maximumLoan);
                    return _maximumLoan;
                }
                _initialLoanCredit -= loanAmount;
                Console.WriteLine("Too big amount, maximum is " + Math.Round(_maximumLoan - _initialLoanCredit, 2, MidpointRounding.ToEven));
            }
            return 0;
        }
        public double FindSmallLoanAmount(double loanAmount,int years)
        {
            if (CheckName())
            {
                if (years <= 20)
                {
                    for (int i = 0; i < years; i++)
                    {
                        loanAmount = loanAmount * _intressRate;
                        loanAmount = Math.Round(loanAmount, 2, MidpointRounding.ToEven);
                    }
                    return loanAmount;
                }
            }
            return 0;
        }
        public void GetSmallLoan(double loanAmount,int years)
        {
            if (CheckName())
            {
                FindSmallLoanAmount(loanAmount, years);
                GetLoan(loanAmount);
            }
        }
        internal void CleanFile()
        {
            using (StreamWriter writer = new StreamWriter("BankInfo.txt",false))
            {
            }
        }
        public void WriteInfoToFile()
        {
            if (CheckName())
            {
                using (StreamWriter writer = new StreamWriter("BankInfo.txt", true))
                {
                    writer.WriteLine("Name: " + _name.ToUpper() + " / " + "Age: " + _age + " / " + "Monthly income: " + _monthlyIncome + " / " + "Monthly payments: " + _currentMonthlyObligations +
                            " / " + "Total loan sum: " + _initialLoanCredit + " ");
                }
            }
        }
        public void ReadFromFile(string name)
        {
            using(StreamReader reader= new StreamReader("BankInfo.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    _userInfo.Add(line);       
                }
                if (!CheckFile(name))
                {
                    Console.WriteLine("No such user!");
                }
            }
        }
        internal bool CheckFile(string name)
        {
            for (int i = 0; i <= _userInfo.Count() - 1; i++)
            {
                name = name.ToUpper();
                if (_userInfo[i].Contains(name))
                {
                    Console.WriteLine(_userInfo[i]);
                    return true;
                }
            }
            return false;
        }
    }
}
