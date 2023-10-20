namespace project_4_zad_1_wyklad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Osoba osoba = new Osoba();
            //osoba.Imie = "Franek";
            //osoba.Nazwisko = "Nowak";

            //Console.WriteLine("Nazywam się: {0} {1}", osoba.Imie, osoba.Nazwisko);
            //Console.WriteLine(osoba.PrzedstawSie());

            //osoba.UstawDane("Janusz", "Kowalski");
            //Console.WriteLine(osoba.PrzedstawSie());

            //osoba.Imie = "Franek";
            //osoba.Nazwisko = "Pawlak";
            //Console.WriteLine(osoba.Imie);

            //Console.WriteLine(osoba.PrzedstawSie());

            Adres adres = new Adres 
            {
                Ulica = "Polna",
                NumerDomu = "10",
                NumerMieszkania = "2",
                KodPocztowy = "12-345",
                Miasto = "Poznań",
                Panstwo = "Polska"
            };

            Osoba nowak = new Osoba("Franek", "Kowalski", adres);
            Console.WriteLine(nowak.PrzedstawSie());
        }
    }
}