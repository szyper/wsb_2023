using System.Security.Cryptography.X509Certificates;

namespace Program
{
    //7.1 delegaty
    public delegate bool Logic(bool x, bool y);
    internal class Program
    {
        public static bool And(bool x, bool y)
        {
            return x && y;
        }
        public static bool Or(bool x, bool y)
        {
            return x || y;
        }
        public static bool Xor(bool x, bool y)
        {
            return x ^ y;
        }
        public static bool Not(bool x, bool y)
        {
            return !x;
        }
        static void Main(string[] args)
        {
            bool x = getBoolFromUser();
            bool y = getBoolFromUser();

            Logic and = new Logic(And);
            DisplayResult(and, x, y);

            DisplayResult(new Logic(Or), x, y);
            DisplayResult(new Logic(Xor), x, y);
            DisplayResult(new Logic(Not), x, y);
        }
        public static void DisplayResult(Logic logic, bool x, bool y)
        {
            try
            {
                bool result = logic(x, y);
                Console.WriteLine("\nWynik operacji {0} na liczbach {1} i {2} wynosi {3}", logic.Method.Name, x, y, result);

            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Wystąpił błąd: {0}", e.Message);
            }
        }

        public static bool getBoolFromUser()
        {
            while(true)
            {
                Console.Write("Wprowadź wartość boolowską (true/false):");
                string input = Console.ReadLine();

                bool value;
                if (bool.TryParse(input, out value))
                {
                    return value;
                }
                else
                {
                    Console.Write("Błędne dane. ");
                }
            }
        }
    }
}