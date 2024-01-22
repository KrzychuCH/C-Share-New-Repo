using System;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;

namespace Testy
{
    internal class Program
    {
        public int FirstNumber = 10;
        public int SecondNumber = 20;
        public int SumNumber;
        public string Znak = "*";
        

      /*  public DoIt(int firstNumber, int secondNumber , int sumNumber)
        {
        FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            SumNumber = sumNumber;
            }*/
        public int Dodawanie()
        {

            SumNumber = FirstNumber + SecondNumber;
            return SumNumber;
        }
        public int Odejmowanie()
        {

            SumNumber = FirstNumber - SecondNumber;
            return SumNumber;
        }
        public int Mnożenie()
        {

            SumNumber = FirstNumber * SecondNumber;
            return SumNumber;
        }
        public int Dzielenie()
        {

            SumNumber = FirstNumber / SecondNumber;
            return SumNumber;
        }

        class Program2
        {
            static void Main()
            {
                Program dzialanie = new Program();

                int dodawanie = dzialanie.Dodawanie();
                int odejmowanie = dzialanie.Odejmowanie();
                int dzielenie = dzialanie.Dzielenie();
                int mnożenie = dzialanie.Mnożenie();
                string znak = dzialanie.Znak;

                if (znak == "+")
                {
                    Console.WriteLine(dodawanie);
                } else if (znak == "-")
                {
                    Console.WriteLine(odejmowanie);
                }
                else if (znak == "/")
                {
                    Console.WriteLine(dzielenie);
                }else if (znak == "*")
                {
                    Console.WriteLine(mnożenie);
                }

            }
        }

       



    }
}
