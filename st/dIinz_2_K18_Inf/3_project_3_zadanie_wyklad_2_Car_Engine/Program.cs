  using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace project_3
{
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public Engine Engine { get; set; }

        public Car (string brand, string model, Engine engine)
        {

            this.Brand = brand;
            this.Model = model;
            this.Engine = engine;
        }

        public Car (string brand, string model, double capacity, double fuelAmount)
        {
            this.Brand = brand;
            this.Model = model;
            this.Engine.Capacity = capacity;
            this.Engine.FuelAmount = fuelAmount;
        }

        public Car(string brand, string model, double capacity, double fuelAmount, double fuelTankCapacity) :this(brand, model, capacity, fuelAmount)
        {
           this.Engine.fuelTankCapacity = fuelTankCapacity;
        }

        public void Go(int distance)
        {
            Console.WriteLine("Jadę");
            
            int time = distance * 100;
            Thread.Sleep(time);
            
            Engine.Work(distance);
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

        public Engine(double capacity, double fuelAmount, double fuelTankCapacity):this(capacity, fuelAmount)
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
            double fuelConsumption = Capacity * 4 / 100;
            if (fuelConsumption * distance >= FuelAmount)
            {
                FuelAmount -= fuelConsumption * distance;
            }
            else
            {
                Console.WriteLine("Brak paliwa na dojazd do celu");
            }
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

            Car car = new Car();

        }
    }
}