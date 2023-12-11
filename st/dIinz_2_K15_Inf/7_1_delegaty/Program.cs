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
            Operation adding = new Operation(Add);
            Operation substracting = new Operation(Substract);
            Operation multiplying = new Operation(Multiply);
            Operation dividing = new Operation(Divide);

            DisplayResult(adding, 2, 5);
            DisplayResult(substracting, 2, 5);
            DisplayResult(multiplying, 2, 5);
            DisplayResult(dividing, 2, 5);
            DisplayResult(dividing, 2, 0);

            //dokończyć, zdefiniować metodę GetIntFromUser
        }

        public static void DisplayResult(Operation op, int x, int y)
        {
            int result;
            if (op.Method.Name == "Divide" && y == 0)
            {
                Console.WriteLine("\nDzielenie przez 0\n");
                result = 0;
            }
            else{
                result = op(x, y);
                Console.WriteLine("\nWynik operacji {0} na liczbach {1} i {2} wynosi: {3}", op.Method.Name, x, y, result);
            }
        }
    }
}