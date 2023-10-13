using project_1.classes;

namespace project_1
{

    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Person person = new Person();

            person.firstName = "Janusz";
            person.lastName = "Nowak";
            person.height = 190;
            person.weight = 95.5F;

            Console.WriteLine("Dane użytkownika: " + person.getData());

            Person nowak = new Person();

            nowak.firstName = "Anna";
            nowak.lastName = "Nowak";
            nowak.height = 170;
            nowak.weight = 66.5F;
            Console.WriteLine("Dane drugiego użytkownika: " + nowak.getData());

            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Rectangle p = new Rectangle(a, b);
            Console.WriteLine($"Pole prostokąta o bokach a = {a} oraz b = {b} wynosi: {p.CalculateArea()}cm\u00B2");

            Console.OutputEncoding = System.Text.Encoding.Default;
            */

            double a=0, b=0;
            
            bool validInput = false;

            do 
            {
                Console.Write("Podaj boka a:");
                string inputA = Console.ReadLine();

                Console.Write("Podaj boka b:");
                string inputB = Console.ReadLine();

                if (double.TryParse(inputA, out a) && double.TryParse(inputB, out b))
                {
                    validInput = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Błędne dane podane z klawiatury. Podaj prawidłowo długość boków");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            } while(!validInput);

            try
            {
                Rectangle prostokat = new Rectangle(a , b);
                Console.Write($"Pole prostokąta o bokach {a} oraz {b} wynosi: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.WriteLine(prostokat.CalculateArea() + "cm\u00B2");
                Console.ResetColor();
            } catch (ArgumentException e) 
            {
                Console.WriteLine(e.Message); 
            }
            
        }
    }
}