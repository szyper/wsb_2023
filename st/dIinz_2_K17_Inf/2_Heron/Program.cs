using System;

namespace _2_Heron
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool isCorrect = false;
            do
            {
                Console.Write("Podaj długość pierwszego boku:");
                double a;
                while (!double.TryParse(Console.ReadLine(), out a) || a <= 0)
                {
                    Console.Write("Nieprawidłowe dane:");
                }

                Console.Write("Podaj długość drugiego boku:");
                double b;
                while (!double.TryParse(Console.ReadLine(), out b) || b <= 0)
                {
                    Console.Write("Nieprawidłowe dane:");
                }

                Console.Write("Podaj długość trzeciego boku:");
                double c;
                while (!double.TryParse(Console.ReadLine(), out c) || c <= 0)
                {
                    Console.Write("Nieprawidłowe dane:");
                }

                if (IsTriangle(a, b, c))
                {
                    double area = CalculateTriangleArea(a, b, c);
                    Console.OutputEncoding = System.Text.Encoding.Unicode;
                    Console.Write($"\nPole trójkąta o bokach {a}, {b}, {c} wynosi: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{area:F5}cm²");
                    Console.ResetColor();
                    isCorrect = true;
                    Console.OutputEncoding = System.Text.Encoding.Default;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPodane długości boków nie utworzą trójkąta");
                    Console.ResetColor();
                    Thread.Sleep(1700);
                    Console.Clear();
                }
                
            } while (!isCorrect);
        }

        static bool IsTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        static double CalculateTriangleArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

    }
}