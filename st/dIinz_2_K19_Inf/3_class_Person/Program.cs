using _3_class_Person.classes;

namespace _3_class_Person
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Person person = new Person();
            person.firstName = "Janusz";
            person.lastName = "Nowak";
            person.height = 192;
            person.weight = 90.5F;

            Console.WriteLine("Dane użytkownika: " + person.getData());

            Person kowal = new Person();
            kowal.firstName = "Anna";
            kowal.lastName = "Kowal";
            kowal.height = 170;
            kowal.weight = 77F;

            Console.WriteLine("\nDane użytkownika: " + kowal.getData());
            */

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
            Console.Write($"\nPole prostokąta o bokach {a} oraz {b} wynosi: ");
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{r.CalculateRectangleArea()}cm²");
            Console.ResetColor();

        }
    }
}