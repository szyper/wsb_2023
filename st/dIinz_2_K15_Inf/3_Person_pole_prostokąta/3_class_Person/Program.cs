using _3_class_Person.classes;

namespace _3_class_Person
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.firstName = "Janusz";
            person.lastName = "Nowak";
            person.height = 192;
            person.weight = 100;

            Console.WriteLine("Dane użytkownika: " + person.getData());

            Person kowal = new Person();
            kowal.firstName = "Janusz";
            kowal.lastName = "Kowal";
            kowal.height = 170;
            kowal.weight = 100;

            Console.WriteLine("\nDane użytkownika: " + kowal.getData());


        }
    }
}