namespace _7_1_delegaty
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
        static void Main(string[] args)
        {
            int a = GetIntFromUser("Podaj pierwszą liczbę:");
            int b = GetIntFromUser("Podaj drugą liczbę:");

            Operation adding = new Operation(Add);

            DisplayResult(adding, a, b);
            DisplayResult(new Operation(Substract), a, b);
            DisplayResult(new Operation(Multiply), a, b);
            DisplayResult(new Operation(Divide), a, b);
        }

        public static void DisplayResult(Operation op, int x, int y)
        {
            int result;
            if (op.Method.Name == "Divide" && y == 0)
            {
                Console.WriteLine("Dzielenie przez 0!\n\n");
                result = 0;
            }
            else
            {
                result = op(x, y);
                Console.WriteLine("Wynik operacji {0} na liczbach {1} i {2} wynosi: {3}", op.Method.Name, x, y, result);
            }
        }

        public static int GetIntFromUser(string prompt)
        {
            Console.Write(prompt);
            int number;
            string? input = Console.ReadLine();
            bool isValid = int.TryParse(input, out number) && number >= 0;

            while(!isValid)
            {
                Console.Write("\nNieprawidowe dane. Podaj liczbę całkowitą nieujemną:");
                input = Console.ReadLine();
                isValid = int.TryParse(input, out number) && number > 0;
            }
            return number;
        }
    }
}