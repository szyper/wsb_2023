using _3_class.classes;

namespace _3_class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Person person = new Person();
            person.firstName = "Janusz";
            person.lastName = "Nowak";
            person.weight = 90.5F;
            person.height = 192;
            Console.WriteLine($"Dane użytkownika: {person.getData()}");

            Person kowal = new Person();
            kowal.firstName = "Janusz";
            kowal.lastName = "Kowal";
            kowal.weight = 70.5F;
            kowal.height = 192;
            Console.WriteLine($"\nDane użytkownika: {kowal.getData()}");
            */

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

            Rectangle r = new Rectangle(a, b);
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.Write($"\nPole trójkąta o bokach {a}, {b} wynosi: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{r.CalculateRectangleArea():F5}cm²");
            Console.ResetColor();
            Console.OutputEncoding = System.Text.Encoding.Default;
            //zdefiniować metodę rysującą prostokąt
            r.DrawRectangle();
        }
    }
}