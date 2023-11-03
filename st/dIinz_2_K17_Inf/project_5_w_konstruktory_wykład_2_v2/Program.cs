namespace project_5_w_konstruktory
{
    internal class Program
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
                this.Model = model;
                this.Engine = new Engine(capacity, fuelAmount, fuelTankCapacity);
            }


            public void Drive(int distance)
            {
                Console.WriteLine("\nJadę\n");
                int time = distance * 100;
                Thread.Sleep(time);
                Engine.Work(distance);
            }

            public void Refuel(double fuelAmount)
            {
                if (Engine.FuelAmount + fuelAmount > Engine.FuelTankCapacity)
                    throw new Exception("Chcesz zatankować za dużo paliwa");

                Engine.FuelAmount += fuelAmount;
            }

            public void ShowCar()
            {
                Console.WriteLine($"Marka: {this.Brand}, model: {this.Model}\nPojemność: {this.Engine.Capacity}, ilość benzyny: {this.Engine.FuelAmount}, Pojemność zbiornika paliwa: {this.Engine.FuelTankCapacity}");
            }
        }

        class Engine
        {
            public double Capacity { get; set; }
            public double FuelAmount { get; set; }
            public double FuelTankCapacity { get; } = 50.0;

            public Engine(double capacity, double fuelAmount)
            {
                this.Capacity = capacity;
                this.FuelAmount = fuelAmount;
                this.FuelTankCapacity = 40.0;
            }

            public Engine(double capacity, double fuelAmount, double fuelTankCapacity) : this(capacity, fuelAmount)
            {
                this.FuelTankCapacity = fuelTankCapacity;
            }

            public static double ConvertLitersPer100KmToMilesPerGallon(double literesPer100Km)
            {
                return 235.214583 / literesPer100Km;
            }

            public static double ConvertMilesPerGallonToLiteresPer100Km(double milesPerGallon)
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

        static void Main(string[] args)
        {
            /*
            Console.WriteLine(Engine.ConvertLitersPer100KmToMilesPerGallon(8)); //29,401822875 
            Console.WriteLine(Engine.ConvertMilesPerGallonToLiteresPer100Km(29.401822875)); //8

            Engine e = new Engine(2000, 25.5);
            Console.WriteLine(e.FuelTankCapacity); //40

            Engine e2 = new Engine(1500, 20, 30);
            Console.WriteLine(e2.FuelTankCapacity); //30

            Console.WriteLine("\n#########################\n\n");
            */


            Car c = new Car("Fiat", "126p", 0.65, 25, 42);
            Console.WriteLine($"Marka: {c.Brand}, model: {c.Model}\nPojemność: {c.Engine.Capacity}, ilość benzyny: {c.Engine.FuelAmount}, Pojemność zbiornika paliwa: {c.Engine.FuelTankCapacity}");

            Console.WriteLine("\n#################################\n");

            Console.WriteLine($"Ilość paliwa: {c.Engine.FuelAmount}");
            c.Drive(25);
            Console.WriteLine($"Ilość paliwa: {c.Engine.FuelAmount}");
            //c.Refuel(25);
            c.Refuel(10);
            Console.WriteLine($"Ilość paliwa: {c.Engine.FuelAmount}");

            Console.Clear();
            Console.WriteLine("Witamy w symulatorze jazdy samochodem");

            Console.Write("Podaj markę samochodu: ");
            string brand = Console.ReadLine();

            Console.Write("Podaj model samochodu: ");
            string model = Console.ReadLine();

            Console.Write("Podaj pojemność silnika (w litrach): ");
            double capacity = double.Parse(Console.ReadLine());

            Console.Write("Podaj ilość paliwa w baku (w litrach): ");
            double fuelAmount = double.Parse(Console.ReadLine());

            Console.Write("Podaj pojemność baku paliwa (w litrach): ");
            double fuelTankCapacity = double.Parse(Console.ReadLine());

            Car car = new Car(brand, model, capacity, fuelAmount, fuelTankCapacity);
            
            //Console.WriteLine($"Marka: {car.Brand}, model: {car.Model}\nPojemność: {car.Engine.Capacity}, ilość benzyny: {car.Engine.FuelAmount}, Pojemność zbiornika paliwa: {car.Engine.FuelTankCapacity}");

            while (true)
            {
                Console.WriteLine("\n1: Jadę");
                Console.WriteLine("2: Tankuję");
                Console.WriteLine("3: Ile mam paliwa");
                Console.WriteLine("4: Dane mojego auta");
                Console.WriteLine("5: Wyjście z programu");
                Console.Write("\n1: Wybierz opcję:");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("\nPodaj dystans do przejechania (w kilometrach):");
                        int distance = int.Parse(Console.ReadLine());
                        car.Drive(distance);
                        break;
                    case 2:
                        Console.Write("\nPodaj ilość paliwa do zatankowania (w litrach):");
                        double fuelToAdd = double.Parse(Console.ReadLine());
                        car.Refuel(fuelToAdd);
                        break;
                    case 3:
                        Console.Write($"\nIlość paliwa w baku {car.Engine.FuelAmount}");
                        break;
                    case 4:
                        Console.Write("\nDane auta");
                        car.ShowCar();
                        break;
                    case 5:
                        Console.Write("\n\nKoniec programu\n\n");
                        return;
                    default:
                        Console.WriteLine("\nNieprawidłowy wybór\n");
                        break;
                }
            }
        }
    }
}