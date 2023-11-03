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
                Console.WriteLine("Jadę");
                int time = distance * 100;
                Thread.Sleep(time);
                Engine.Work(distance);
            }

            public void Refuel(double fuelAmount)
            {
                if (Engine.FuelAmount + fuelAmount > Engine.FuelTankCapacity)
                    throw new Exception("Za dużo paliwa");

                Engine.FuelAmount += fuelAmount;
            }

            public void ShowCar()
            {
                Console.WriteLine($"Marka: {Brand}, model: {Model}\nPojemność silnika: {Engine.Capacity}, ilość paliwa: {Engine.FuelAmount}, Pojemność baku: {Engine.FuelTankCapacity}\n\n");
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
                Console.WriteLine("Jestem");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Engine.ConvertLitersPer100KmToMilesPerGallon(8)); //29,401822875 
            Console.WriteLine(Engine.ConvertMilesPerGallonToLiteresPer100Km(29.401822875)); //8

            Engine e = new Engine(2, 25.5);
            Console.WriteLine(e.FuelTankCapacity); //40

            Engine e2 = new Engine(1, 20, 30);
            Console.WriteLine(e2.FuelTankCapacity); //30

            Console.WriteLine("\n#########################\n\n");

            Car car = new Car("Fiat", "126p", 1, 20, 40);
            Console.WriteLine($"Marka: {car.Brand}, model: {car.Model}\nPojemność silnika: {car.Engine.Capacity}, ilość paliwa: {car.Engine.FuelAmount}, Pojemność baku: {car.Engine.FuelTankCapacity}\n\n");

            car.Drive(100);

            Console.WriteLine($"\nIlość paliwa: {car.Engine.FuelAmount}\n\n");

            //car.Refuel(100);
            car.Refuel(7);
            Console.WriteLine($"\nIlość paliwa: {car.Engine.FuelAmount}\n\n");

            Console.Clear();
            Console.WriteLine("Witamy w symulatorze jazdy samochodem");

            Console.Write("Podaj markę samochodu:");
            string brand = Console.ReadLine();

            Console.Write("Podaj model samochodu:");
            string model = Console.ReadLine();

            Console.Write("Podaj pojemność samochodu (w litrach):");
            double capacity = double.Parse(Console.ReadLine());
            Console.Write("Podaj ilość paliwa samochodu (w litrach):");
            double fuelAmount = double.Parse(Console.ReadLine());

            Console.Write("Podaj pojemność baku samochodu (w litrach):");
            double fuelTankCapacity = double.Parse(Console.ReadLine());

            Car c = new Car(brand, model, capacity, fuelAmount, fuelTankCapacity);

            Thread.Sleep(2000);
            Console.Clear();

            while (true)
            {
                Console.WriteLine("1: Jadę");
                Console.WriteLine("2: Tankuję");
                Console.WriteLine("3: Ile mam paliwa");
                Console.WriteLine("4: Dane mojego auta");
                Console.WriteLine("5: Wyjście z programu");

                Console.Write("\n\nWybierz opcję:");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Podaj dystans do przejechania (w kilometrach):");
                        int distance = int.Parse(Console.ReadLine());
                        c.Drive(distance);
                        break;
                    case 2:
                        Console.Write("Podaj ilość paliwa do zatankowania (w litrach):");
                        double fuelToAdd = double.Parse(Console.ReadLine());
                        c.Refuel(fuelToAdd);
                        break;
                    case 3:
                        Console.WriteLine($"Ilość paliwa w zbiorniku (w litrach): {c.Engine.FuelAmount}");
                        break;
                    case 4:
                        Console.WriteLine("Dane auta");
                        c.ShowCar();
                        break;
                    case 5:
                        Console.WriteLine("Koniec programu");
                        return;
                    default:
                        Console.WriteLine("nieprawidłowy wybór");
                        break;
                }
            }
        }
    }
}