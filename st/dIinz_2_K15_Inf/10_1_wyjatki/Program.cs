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

  class Mechanic
  {
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Mechanic(string fistName, string lastName)
    {
      FirstName = fistName;
      LastName = lastName;
    }

    public delegate bool Repair(Car c);

    public void PerformRepair(Car c, Repair r)
    {
      bool result = r(c);
      Console.WriteLine($"{FirstName} {LastName} naprawiał {c.Brand} {(result ? "skutecznie" : "nieskutecznie")}");
    }
    internal class Program
    {
      static void Main(string[] args)
      {
        //utworzyć 3 obiekty samochód, mechanik, naprawa
        Car c1 = new Car("Fiat", "126p", "czerwony", 650);
        Car c2 = new Car("Fiat", "Panda", "czerwony", 1000);
        Car c3 = new Car("Fiat", "126p", "zielony", 650);

        Mechanic m1 = new Mechanic("Jan", "Kowal");
        Mechanic m2 = new Mechanic("Anna", "Kowal");
        Mechanic m3 = new Mechanic("Paweł", "Nowak");

        Mechanic.Repair r1 = c => { c.Capacity += 100; return true; };
        Mechanic.Repair r2 = c => { c.Color = "biały"; return true; };
        Mechanic.Repair r3 = c => { return false; };

        List<Car> list = new List<Car>() { c1, c2, c3 };
        List<Mechanic> mechanics = new List<Mechanic>() { m1, m2, m3 };
        List<Mechanic.Repair> repairs = new List<Mechanic.Repair>() { r1, r2, r3 };

      }
    }
  }
}