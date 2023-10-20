namespace _4_wyklad_1_Osoba_Adres
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person nowak = new Person();

            /*
            nowak.FirstName = "Janusz";
            nowak.LastName = "Nowak";

            //Console.WriteLine($"Nazywam się {nowak.FirstName} {nowak.LastName}");
            Console.WriteLine(nowak.Introduce());
            */

            /*
            nowak.SetData("Paweł", "Nowak");
            Console.WriteLine(nowak.Introduce());
            */

            Address nowakAddress = new Address()
            {
                Street = "Polna",
                BuildingNumber = "10a",
                ApartmentNumber = "4",
                PostalCode = "12-345",
                City = "Poznań",
                Country = "Polska"
            };

            nowak.SetData("Franek", "Kowalski", nowakAddress);
            Console.WriteLine(nowak.Introduce());
            Console.WriteLine();
            Console.WriteLine(nowak.FullAddress);

        }
    }
}