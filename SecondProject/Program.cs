using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace SecondProject
{

    internal class Program
    {
        // pola
        public string FirstValue;
        public string LastValue;   

        // to jest metoda
        public void FirstTest()
        {
            FirstValue = Console.ReadLine();
            LastValue = Console.ReadLine();

        }

        // top jest druga metoda
        public void Genraltest()
        {
            if (FirstValue == "Test")
            {
                Console.WriteLine("Test zdany");
            } else { Console.WriteLine("test nie zdany"); }

            if (LastValue == "Test2") {
                Console.WriteLine("drugi test zdany");
            }else { Console.WriteLine("test 2 nie zdany"); }

}
        




        public static void Main(string[] args)
        {
            //obiekt z którego mogę odnieść się do wcześniejszych metod
            Program program = new Program();
            program.FirstTest();  // ta metoda wykonuje cały blok który był wcześniej zdefiniowany
            program.Genraltest(); // ta metoda wykonuje cały blok który był wcześniej zdefiniowany

            Console.WriteLine("test");

        }
    }

}


