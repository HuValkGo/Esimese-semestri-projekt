using System;

namespace EKSAM_OIGE
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrencyExhance ex = new CurrencyExhance();
            BankB b = new BankB();
            b.CleanFile();
            ex.GetExchangeRate("AUD");
            ex.GetExchangeRate("USD");
            ex.CalculateCurrency(5, "aud");
            b.ExchangeCurrency(5, "usd");
            b.FindCurrencies("peeso");
            b.ExchangeCurrency(20, "usd");
            b.GetLoan(10);
            b.FindSmallLoanAmount(2,2);
            b.GetSmallLoan(2, 2);
            b.CanGetLoan();
            b.CalculateMaxLoan();
            BankA a = new BankA();
            BankC c = new BankC();
            Console.WriteLine();
            c.ExchangeCurrencyFromAToB(100, "aud", "usd");
            a.AddCustomerData("Hugo", 19, 1000, 500);
            a.GetLoan(1000);
            a.GetLoan(20000);
            Console.WriteLine();
            b.AddCustomerData("Seedu", 64, 500, 350);
            b.CanGetLoan();
            b.GetLoan(10);          
            Console.WriteLine();
            a.ExchangeCurrency(5, "aud");          
            b.AddCustomerData("piret", 30, 2000, 100);
            b.AddCustomerData("piret", 30, 2000, 120);
            a.WriteInfoToFile();
            b.WriteInfoToFile();
            a.ReadFromFile("hhugo");
            a.ReadFromFile("hugo");
            b.ReadFromFile("piret");
            a.CanGetLoan();
             

            //b.WriteInfoToFile();
            /*
            c.CalculateCurrencyToAnotherCurrency(10, "aud", "try");
            c.ExchangeCurrencyFromAToB(10, "aud","usd");
            a.ReadFromFile("hugo");
            */
        }       
    }
}
