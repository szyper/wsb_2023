namespace _5_1_delegaty
{
    public delegate int Operation(int x, int y);
    internal class Program
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static int Substract(int x, int y)
        {
            return x - y;
        }

        public static int Multiply(int x, int y)
        {
            return x * y;
        }

        public static int Divide(int x, int y)
        {
            return x / y;
        }

        public static void DisplayResult(Operation op, int x, int y)
        {
            int result;

            if (op.Method.Name == "Divide" && y == 0)
            {
                Console.WriteLine("\nBłąd: dzielenie przez 0");
                result = 0;
            }
            else
            {
                result = op(x, y);
                Console.WriteLine("Wynik operacji {0} na liczbach {1} i {2} to {3}", op.Method.Name, x, y, result);
            }
        }

        public static int GetIntFromUser(string prompt)
        {
            Console.Write(prompt);
            int number;
            string? input = Console.ReadLine();
            bool isValid = int.TryParse(input, out number) && number > 0;

            while(!isValid)
            {
                Console.Write("Nieprawidłowe dane. Podaj liczbę całkowitą nieujemną:");
                input = Console.ReadLine();
                isValid = int.TryParse(input, out number) && number > 0;
            }
            return number;
        }
        static void Main(string[] args)
        {
            int a = GetIntFromUser("Podaj pierwszą liczbę:");
            int b = GetIntFromUser("Podaj drugą liczbę:");

            Operation adding = new Operation(Add);
            Operation substracting = new Operation(Substract);
            Operation multiplying = new Operation(Multiply);
            Operation dividing = new Operation(Divide);
            Console.WriteLine();

            DisplayResult(adding, a, b);
            DisplayResult(substracting, a, b);
            DisplayResult(multiplying, a, b);
            DisplayResult(dividing, a, b);
        }
    }
}