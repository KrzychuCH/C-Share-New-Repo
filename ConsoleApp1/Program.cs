namespace ConsoleApp1
{
    internal class Program
    {
        public string FirstName;
        public string LastName;
        public string YearOfBirth;
        public string MonthOfBirth;
        public string DayOfBirth;
        public TimeSpan CurrentAge;

        public void GetData()
        {
            Console.WriteLine("Podaj swoje Imię");
            FirstName = Console.ReadLine();
            Console.WriteLine("Podaj swoje Nazwisko");
            LastName = Console.ReadLine();
            Console.WriteLine("Podaj swój rok urodzenia");
            YearOfBirth = Console.ReadLine();
            Console.WriteLine("Podaj swój miesiąc urodzenia");
            MonthOfBirth = Console.ReadLine();
            Console.WriteLine("Podaj swój mdzień urodzenia");
            DayOfBirth = Console.ReadLine();


        }
        
        public void CalculateAge()
        {
            DateTime currentDate = DateTime.Now;
            DateTime dateOfBirth = new DateTime(int.Parse(YearOfBirth), int.Parse(MonthOfBirth), int.Parse(DayOfBirth));

            CurrentAge = currentDate - dateOfBirth;
        }

        public void DisplayAgeInYears()
        {
            int totalDays = (int)CurrentAge.TotalDays;
            int totalYears = totalDays / 365;

            Console.WriteLine("Twój wiek to: " + totalYears + " lat.");
        }


        static void Main(string[] args)
        {
            Program program = new Program();
            program.GetData();
            program.CalculateAge();
            program.DisplayAgeInYears();

        }
    }
}
