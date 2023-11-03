using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace project_3
{
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public Engine Engine { get; set; }

        public Car(string brand, string model, Engine engine)
        {

            this.Brand = brand;
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string brand, string model, double capacity, double fuelAmount)
        {
            this.Brand = brand;
            this.Model = model;
            this.Engine.Capacity = capacity;
            this.Engine.FuelAmount = fuelAmount;
        }

        public Car(string brand, string model, double capacity, double fuelAmount, double fuelTankCapacity)
        {
            this.Brand = brand;
            this.Model= model;
            this.Engine = new Engine(capacity, fuelAmount, fuelTankCapacity);
        }

        public void Go(int distance)
        {
            Console.WriteLine("Jadę");

            int time = distance * 100;
            Thread.Sleep(time);

            Engine.Work(distance);
        }

        public void Refuel(double fuelAmount)
        {
            if (Engine.FuelAmount + fuelAmount > Engine.fuelTankCapacity)
                throw new Exception("Chcesz zatankować za dużo paliwa");

            Engine.FuelAmount += fuelAmount;
        }

        public void showCar()
        {
            Console.WriteLine($"Marka: {this.Brand}, model: {this.Model}\nPojemność: {this.Engine.Capacity}, ilość benzyny: {this.Engine.FuelAmount}, pojemność zbiornika: {this.Engine.fuelTankCapacity}");
        }
    }

    class Engine
    {
        public double Capacity { get; set; }
        public double FuelAmount { get; set; }
        public double fuelTankCapacity { get; } = 50.0;

        public Engine(double capacity, double fuelAmount)
        {
            this.Capacity = capacity;
            this.FuelAmount = fuelAmount;
            this.fuelTankCapacity = 50.0;
        }

        public Engine(double capacity, double fuelAmount, double fuelTankCapacity) : this(capacity, fuelAmount)
        {
            this.fuelTankCapacity = fuelTankCapacity;
        }

        public static double ConvertLitersPer100KmToMilesPerGallon(double litersPer100Km)
        {
            return 235.214583 / litersPer100Km;
        }

        public static double ConvertMilesPerGallonToLitersPer100Km(double milesPerGallon)
        {
            return 235.214583 / milesPerGallon;
        }

        public void Work(int distance)
        {
            double fuelConsumption = (Capacity * distance * 4) / 100;

            if (FuelAmount < fuelConsumption)
                throw new Exception("Brak paliwa");

            FuelAmount -= fuelConsumption;
            Console.WriteLine("\nJestem\n");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Przeliczenie z l/100km na mile/galon");
            double litersPer100Km = 7.5;
            double milesPerGallon = Engine.ConvertLitersPer100KmToMilesPerGallon(litersPer100Km);
            Console.WriteLine($"{litersPer100Km}l/100km jest równe {milesPerGallon:F2}mpg");

            Console.WriteLine("Przeliczenie z mile/galon na l/100km");
            double milesPerGallon2 = 31.36;
            double litersPer100Km2 = Engine.ConvertLitersPer100KmToMilesPerGallon(milesPerGallon2);
            Console.WriteLine($"{milesPerGallon2}mpg jest równe {litersPer100Km2:F2}l/100km");

            //Engine e = new Engine();
            //Console.WriteLine(e.fuelTankCapacity);
            //e.fuelTankCapacity = 10;

            Engine e = new Engine(3000, 20);
            Console.WriteLine($"Pojemność silnika {e.Capacity}, ilość paliwa: {e.FuelAmount}, pojemność zbiornika: {e.fuelTankCapacity}\n");

            Engine e2 = new Engine(2000, 23, 77);
            Console.WriteLine($"Pojemność silnika {e2.Capacity}, ilość paliwa: {e2.FuelAmount}, pojemność zbiornika: {e2.fuelTankCapacity}\n");

            Car car = new Car("Fiat", "126p", 0.65, 25, 42);
            Console.WriteLine($"Marka: {car.Brand}, model: {car.Model}\nPojemność: {car.Engine.Capacity}, ilość benzyny: {car.Engine.FuelAmount}, pojemność zbiornika: {car.Engine.fuelTankCapacity}");

            Console.WriteLine($"\n\nIlość paliwa: {car.Engine.FuelAmount}");
            car.Go(25);
            Console.WriteLine($"Ilość paliwa: {car.Engine.FuelAmount}");
            car.Refuel(10);
            Console.WriteLine($"Ilość paliwa: {car.Engine.FuelAmount}");

            Console.Clear();

            Console.WriteLine("Witamy w symulatorze jazdy samochodem");

            Console.Write("Podaj markę samochodu:");
            string brand = Console.ReadLine();

            Console.Write("Podaj model samochodu:");
            string model = Console.ReadLine();

            Console.Write("Podaj pojemność silnika (w litrach):");
            double capacity = double.Parse(Console.ReadLine());

            Console.Write("Podaj ilość paliwa w baku (w litrach):");
            double fuelAmount = double.Parse(Console.ReadLine());

            Console.Write("Podaj pojemność baku paliwa (w litrach):");
            double fuelTankCapacity = double.Parse(Console.ReadLine());

            Car c = new Car(brand, model, capacity, fuelAmount, fuelTankCapacity);

            while (true)
            {
                Console.WriteLine("\n\n1: Jadę");
                Console.WriteLine("2: Tankuję");
                Console.WriteLine("3: Ile mam paliwa");
                Console.WriteLine("4: Dane mojego auta");
                Console.WriteLine("5: Wyjście z programu");
                Console.Write("\nWybierz opcję:");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Podaj dystans do przejechania (w kilometrach):");
                        int distance = int.Parse(Console.ReadLine());
                        c.Go(distance);
                        break;
                    case 2:
                        Console.Write("Podaj ilość paliwa do zatankowania (w litrach):");
                        double fuelToAdd = double.Parse(Console.ReadLine());
                        c.Refuel(fuelToAdd);
                        break;
                    case 3:
                        Console.WriteLine($"ilość paliwa w baku: {c.Engine.FuelAmount}");
                        break;
                    case 4:
                        Console.WriteLine("\nDane auta:\n");
                        c.showCar();
                        break;
                    case 5:
                        Console.WriteLine("\n\nKoniec programu\n\n");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór");
                        break;
                }
            }
        }
    }
}