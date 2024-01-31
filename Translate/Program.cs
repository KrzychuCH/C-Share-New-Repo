using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.IO;

namespace Translate
{
    internal class Program
    {
        string plWord;
        string enWord;
        int flagPl = 0;
        int flagEn = 0;
        Dictionary<string, string> PL = new Dictionary<string, string>();
        Dictionary<string, string> EN = new Dictionary<string, string>();
        public void GetDatePl()
        {
            Console.WriteLine("Podaj Polskie słowo:");
            plWord = Console.ReadLine();

            Regex regexPl = new Regex(@"[\W\d\s]");
            bool ismatch = regexPl.IsMatch(plWord);
            if (ismatch == true)
            {
                Console.WriteLine("Słowo nie powinno zawierać cyfr,biłaych znaków lub znaków specjalnych jak np. (+,@,#)");
                flagPl = 1;
                return;
            }
            else
            {
                plWord = plWord.ToUpper();
            }
          

        }

        public void GetDateEn()
        {
            Console.WriteLine("Podaj Angielskie słowo:");
            enWord = Console.ReadLine();

            

            Regex regexEN = new Regex(@"[\W\d\s]");
            bool ismatch = regexEN.IsMatch(enWord);
            if (ismatch == true)
            {
                Console.WriteLine("Słowo nie powinno zawierać cyfr,biłaych znaków lub znaków specjalnych jak np. (+,@,#)");
                flagEn = 1;
                return;
            }
            else
            {
                enWord = enWord.ToUpper();
            }
            
        }

        public void Dict()
        {

            if (!PL.ContainsKey(plWord))
                PL.Add(plWord, enWord);
            if (!EN.ContainsKey(enWord))
                EN.Add(enWord, plWord);

        }
        private void LoadData()
        {
            if (File.Exists("dictionary.json"))
            {
                string json = File.ReadAllText("dictionary.json");
                var data = JsonConvert.DeserializeObject<Dictionary<string, string>[]>(json);
                PL = data[0];
                EN = data[1];
            }
        }
        private void SaveData()
        {
            var data = new Dictionary<string, string>[] { PL, EN };
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText("dictionary.json", json);
        }

        static void Main(string[] args)
        {

            Program translate = new Program();

            translate.LoadData(); // Wczytujemy dane z pliku JSON przed operacjami użytkownika

            translate.GetDatePl();
            if (translate.flagPl == 1)
            {
                Console.WriteLine("Podana błędna wartość - zacznij od nowa");
                return; // Kończymy działanie metody, gdy jest błąd
            }

            translate.GetDateEn();
            if (translate.flagEn == 1)
            {
                Console.WriteLine("Podana błędna wartość - zacznij od nowa");
                return; // Kończymy działanie metody, gdy jest błąd
            }

            if (translate.flagPl == 0 && translate.flagEn == 0)
            {
                translate.Dict();
                translate.SaveData();
                Console.WriteLine("Podane wartości zostały zapisane w słowniku");
            }

            Console.WriteLine("Podaj słowo do tłumaczenia:");
            string getWord = Console.ReadLine().ToUpper();
            string translatePl = translate.PL.ContainsKey(getWord) ? translate.PL[getWord] : "Brak tłumaczenia";
            Console.WriteLine(translatePl);

        }
    }
}
