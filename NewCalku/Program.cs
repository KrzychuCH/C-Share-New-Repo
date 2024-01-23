using System;
using System.Runtime.ExceptionServices;

namespace NewCalku
{
    internal class Program
    {

        public string FirstValue;
        public string LastValue;
        public string Action;
        public int Result;
        public void PobranieDane()  // pobranie danych i konwersja na int
        {
            Console.WriteLine("Podaj pierwszą wartość:");
            FirstValue = Console.ReadLine();
            Console.WriteLine("Podaj drugą wartość:");
            LastValue  = Console.ReadLine();
            Console.WriteLine("Podaj jakie działanie chcesz wykonać:");
            Action = Console.ReadLine();


        }

        public void Mnozenie()
        {

            int FirstValueInt = int.Parse(FirstValue);
            int LastValueInt = int.Parse(LastValue);

            Result = FirstValueInt * LastValueInt;
            Console.WriteLine("Wynik mnożenia to: " + Result);
        }
        public void Dzielenie()
        {

            int FirstValueInt = int.Parse(FirstValue);
            int LastValueInt = int.Parse(LastValue);


            Result = FirstValueInt / LastValueInt;
            Console.WriteLine("Wynik dzielenia to: " + Result);
        }
        public void Dodawanie()
        {

            int FirstValueInt = int.Parse(FirstValue);
            int LastValueInt = int.Parse(LastValue);

            Result = FirstValueInt + LastValueInt;
            Console.WriteLine("Wynik Dodawania to: " + Result);
        }
        public void Odejmowanie()
        {

            int FirstValueInt = int.Parse(FirstValue);
            int LastValueInt = int.Parse(LastValue);

            Result = FirstValueInt - LastValueInt;
            Console.WriteLine("Wynik odejmowania to: " + Result);
        }

        public static void Main()
        {
            // dzięki tworzeniu obkietów możemy odnosić się do metod i pól
            Program Calk = new Program();
            Calk.PobranieDane();

            if (Calk.Action == "+")
            {
                Calk.Dodawanie();
            } else if (Calk.Action == "-")
            {
                Calk.Odejmowanie();
            }else if (Calk.Action == "*")
            {
                Calk.Mnozenie();
            }else if (Calk.Action == "/")
            {
                Calk.Dzielenie();
            } else
                Console.WriteLine("Nieznane działanie");


        }
    }

}
