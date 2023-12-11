namespace _7_2_delegaty
{
    delegate bool Logic(bool a, bool b);
    internal class Program
    {
        static bool And(bool a, bool b)
        {
            return a && b;
        }
        static bool Or(bool a, bool b)
        {
            return a || b;
        }
        static bool Xor(bool a, bool b)
        {
            return a ^ b;
        }
        static bool Not(bool a, bool b)
        {
            return !a;
        }
        static void Main(string[] args)
        {
            bool x = GetBoolFromUser();
            bool y = GetBoolFromUser();
            Console.WriteLine();

            DisplayResult(new Logic(And), x, y);
            DisplayResult(new Logic(Or), x, y);
            DisplayResult(new Logic(Xor), x, y);
            DisplayResult(new Logic(Not), x, y);
        }

        static void DisplayResult(Logic logic, bool a, bool b)
        {
            try
            {
                bool result = logic(a, b);
                Console.WriteLine($"Wynik {logic.Method.Name} {a} i {b} wynosi {result}");
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static bool GetBoolFromUser()
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
                    Console.Write("Błędne dane. Wprowadź wartość boolowską (true/false):");
                }
            }
        }
    }
}