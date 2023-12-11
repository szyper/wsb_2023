namespace _10_1_wyjatki
{
    class EngineFailureException : Exception
    {
        public EngineFailureException(string? message) : base(message)
        {
        }
    }

    interface IMovable
    {

    }

    class Car : IMovable
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public string Color { get; set; }
        public int Capacity { get; set; }
        public int Mileage { get; private set; }
        public Car(string brand, string model, string color, int capacity)
        {
            Brand = brand;
            Model = model;
            Color = color;
            Capacity = capacity;
            Mileage = 0;
        }

        public void Drive(int distance)
        {
            Mileage += distance;
            
            Random rand = new Random();
            int num = rand.Next(100);

            if (num < 10)
            {
                throw new EngineFailureException("Silnik się zepsuł");
            }
        }

        public event EventHandler<Car> Broken;

        public void OnBroken()
        {
            if (Broken != null)
            {
                Broken(this, this);
            }
        }

        public override string ToString()
        {
            return $"{Brand}, {Model}, {Color}, {Capacity}, {Mileage}";
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}