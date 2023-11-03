namespace _5_project_wyklad_2
{
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public Engine Engine { get; set; }

        public void Drive(int distance)
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
            this.fuelTankCapacity = 40.0;
        }

        public Engine(double capacity, double fuelAmount, double fuelTankCapacity) : this(capacity, fuelAmount)
        {
            this.fuelTankCapacity = fuelTankCapacity;
        }

        public static double ConvertLiteresPer100KmToMilesPerGallon(double litersPer100km)
        {
            return 235.214583 / litersPer100km;
        }

        public static double ConvertMilesPerGallonToLiteresPer100Km(double milesPerGallon)
        {
            return 235.214583 / milesPerGallon;
        }

        public void Work(int distance)
        {
            double fuelConsumption = Capacity * 4 * (distance / 100);
            if (fuelConsumption > FuelAmount)
            {
                FuelAmount -= fuelConsumption;
                Console.WriteLine("Jestem");
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
            Engine e2 = new Engine(1.5, 33, 66);
            Console.WriteLine($"Pojemność silnika: {e2.Capacity}, ilość paliwa: {e2.FuelAmount}, pojemność zbiornika: {e2.fuelTankCapacity}");

            Engine e = new Engine(2, 33.5);
            Console.WriteLine($"Pojemność silnika: {e.Capacity}, ilość paliwa: {e.FuelAmount}, pojemność zbiornika: {e.fuelTankCapacity}");

            /*
            Console.WriteLine("Przeliczenie z l/100km na mile/galon");
            double literesPer100Km = 7.5;
            double milesPerGallon = Engine.ConvertLiteresPer100KmToMilesPerGallon(literesPer100Km);
            Console.WriteLine($"{literesPer100Km}l/100km jest równe {milesPerGallon:F4}mpg");

            Console.WriteLine("Przeliczenie z mile/galon na l/100km");
            double milesPerGallon2 = 31.3619;
            double literesPer100Km2 = Engine.ConvertMilesPerGallonToLiteresPer100Km(milesPerGallon2);
            Console.WriteLine($"{milesPerGallon2}mpg jest równe {literesPer100Km2:F4}l/100km");
            */
        }
    }
}