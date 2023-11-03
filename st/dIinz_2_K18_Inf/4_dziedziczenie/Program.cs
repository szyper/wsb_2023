namespace _4_dziedziczenie
{
    internal class Program
    {
        class Vehicle
        {
            public string Brand;
            public string Model;
            public short MaxSpeed;
            public byte numberOfWheels;
            public void honk()
            {
                Console.WriteLine("TiTi");
            }
        }

        class Car : Vehicle
        {
            public string Vin;
        }

        class Motorcicle : Vehicle
        {
            public bool wheelieControl; //funkcja zapobiegająca podnoszeniu przedniego koła podczas przyspieszenia
        }

        static void Main(string[] args)
        {
            
        }
    }
}