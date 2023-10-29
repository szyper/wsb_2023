using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3_class_Person.classes;

namespace _3_class_Person
{
    internal class new_Main
    {
        static void Main(string[] args)
        {
            Console.Write("Podaj długość boku a:");
            double a;
            while (!double.TryParse(Console.ReadLine(), out a) || a <= 0)
            {
                Console.Write("Nieprawidłowe dane. Podaj liczbę większą od zera:");
            }

            Console.Write("Podaj długość boku b:");
            double b;
            while (!double.TryParse(Console.ReadLine(), out b) || b <= 0)
            {
                Console.Write("Nieprawidłowe dane. Podaj liczbę większą od zera:");
            }

            Rectangle r = new Rectangle(a, b);
            Console.Write("Pole prostokąta o bokach {0} i {1} wynosi: ", a, b);
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0:F2}cm\u00B2", r.CalculateRectangleArea());
            Console.OutputEncoding = System.Text.Encoding.Default;
            Console.ResetColor();
        }
    }
}
