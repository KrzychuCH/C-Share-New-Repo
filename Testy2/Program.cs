namespace Testy2
{
    internal class Program
    {

        public string FirstName;
        public string LastName;

        private DateTime dateOfBirth;

        // poniżej metoda. public void nic nie zwraca. W nawiasie mamy parametry metody
        public void SetDateOfBirth(DateTime date)
        {
            if (date > DateTime.Now) {
                Console.WriteLine("Invalid Date of Birth");
            } else
            {
                dateOfBirth = date;
            }
        }
        public DateTime GetDateOfBirth()   //  => dateOfBirth;
        {
            return dateOfBirth;  // dwa zapisy. Klasyczny i tak jak powyzej uproszczony. 
        }
    }
}
// to są metody które powinny byc wywołane z metody main. 