namespace _5_project_wyklad_2_1
{
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public Engine Engine { get; set; }

        public Car(string brand, string model, Engine engine)
        {
            Brand = brand;
            Model = model;
            Engine = engine;
        }

        public Car(string brand, string model, double capacity, double fuelAmount) 
        {
            Brand = brand;
            Model= model;
            Engine.Capacity = capacity;
            Engine.FuelAmount = fuelAmount;
        }

        public Car(string brand, string model, double capacity, double fuelAmount, double fuelTankCapacity)
        {
            Brand = brand;
            Model = model;
            Engine = new Engine(capacity, fuelAmount, fuelTankCapacity);
        }

        public void Drive(int distance)
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

        public void ShowCar()
        {
            Console.WriteLine($"\nMarka: {this.Brand}, model: {this.Model}\nPojemność: {this.Engine.Capacity}, ilość benzyny: {this.Engine.FuelAmount}, pojemność zbiornika: {this.Engine.fuelTankCapacity}\n\n");
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
            double fuelConsumption = (Capacity * 4 * distance) / 100;
            if (fuelConsumption <= FuelAmount)
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
            Console.WriteLine("Witamy w symulatorze jazdy samochodem\n\n");

            Console.Write("Podaj markę samochodu:");
            string brand = Console.ReadLine();

            Console.Write("Podaj model samochodu:");
            string model = Console.ReadLine();

            Console.Write("Podaj pojemność silnika (w litrach):");
            double capacity = double.Parse(Console.ReadLine());

            Console.Write("Podaj ilość paliwa w baku (w litrach):");
            double fuelAmount = double.Parse(Console.ReadLine());

            Console.Write("Podaj pojemność zbiornika na paliwo (w litrach):");
            double fuelTankCapacity = double.Parse(Console.ReadLine());

            Car c = new Car(brand, model, capacity, fuelAmount, fuelTankCapacity);
            //c.ShowCar();

            while (true)
            {
                Console.WriteLine("\n1: Jadę");
                Console.WriteLine("2: Tankuję");
                Console.WriteLine("3: Ile mam paliwa");
                Console.WriteLine("4: Dane mojego auta");
                Console.WriteLine("5: Wyjście z programu");

                Console.Write("\n\nWybierz opcję:");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("\nPodaj dystans do przejechania (w kilometrach):");
                        int distance = int.Parse(Console.ReadLine());
                        c.Drive(distance);
                        break;
                    case 2:
                        Console.Write("\nPodaj ilość paliwa do zatankowania (w litrach):");
                        double fuelToAdd = double.Parse(Console.ReadLine());
                        c.Refuel(fuelToAdd);
                        break;
                    case 3:
                        Console.WriteLine($"\nIlość paliwa w baku: {c.Engine.FuelAmount}\n");
                        break;
                    case 4:
                        Console.WriteLine("\nDane auta:");
                        c.ShowCar();
                        break;
                    case 5:
                        Console.WriteLine("\n\nKoniec programu\n\n");
                        return;
                    default:
                        Console.WriteLine("\n\nNieprawidłowy wybór\n\n");
                        break;
                }
            }




            /*Car c = new Car("Fiat", "126p", 1, 25, 40);
            Console.WriteLine($"Marka: {c.Brand}, model: {c.Model}\nPojemność: {c.Engine.Capacity}, ilość benzyny: {c.Engine.FuelAmount}, pojemność zbiornika: {c.Engine.fuelTankCapacity}");


            Console.WriteLine($"\n\nIlość paliwa: {c.Engine.FuelAmount}");
            c.Drive(100);
            Console.WriteLine($"\n\nIlość paliwa: {c.Engine.FuelAmount}");
            c.Refuel(10);
            Console.WriteLine($"\n\nIlość paliwa: {c.Engine.FuelAmount}");*/



            /*Engine e2 = new Engine(1.5, 33, 66);
            Console.WriteLine($"Pojemność silnika: {e2.Capacity}, ilość paliwa: {e2.FuelAmount}, pojemność zbiornika: {e2.fuelTankCapacity}");

            Engine e = new Engine(2, 33.5);
            Console.WriteLine($"Pojemność silnika: {e.Capacity}, ilość paliwa: {e.FuelAmount}, pojemność zbiornika: {e.fuelTankCapacity}");
            */

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