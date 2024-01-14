using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace _8_wyjatki
{
  class EngineFailureException : Exception
  {
    public EngineFailureException(string message) : base(message) { }
  }

  interface IMovable
  {
    void Drive(int distance);
    event EventHandler<Car> Broken;
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
      Broken += (sender, args) => Console.WriteLine("Samochód jest uszkodzony!");
    }

    public void Drive(int distance)
    {
      Mileage += distance;

      Random rand = new Random();
      int num = rand.Next(100);

      if (num < 10)
      {
        throw new EngineFailureException("Zepsuty silnik");
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
    public string Name { get; private set; }
    public string Surname { get; private set; }

    public Mechanic(string name, string surname)
    {
      Name = name;
      Surname = surname;
    }

    public delegate bool Repair(Car c);

    public void PerformRepair(Car c, Repair r)
    {
      bool result = r(c);
      Console.WriteLine($"{Name} {Surname} naprawiał {c.Brand} {c.Model} {(result ? "skutecznie" : "nieskutecznie")}");
    }

  }
  internal class Program
  {
    static void Main(string[] args)
    {
      Car c1 = new Car("Fiat", "126p", "Czerwony", 650);
      Car c2 = new Car("Fiat", "Panda", "Czerwony", 1650);
      Car c3 = new Car("Ferrari", "F460", "Czerwony", 4650);

      Mechanic m1 = new Mechanic("Janusz", "Kowalski");
      Mechanic m2 = new Mechanic("Anna", "Kowalska");
      Mechanic m3 = new Mechanic("Anna", "Pawlak");

      Mechanic.Repair r1 = c => { c.Capacity += 100; return true; };
      Mechanic.Repair r2 = c => { c.Color = "Zielony"; return true; };
      Mechanic.Repair r3 = c => { return false; };

      List<Car> cars = new List<Car>() { c1, c2, c3 };
      List<Mechanic> mechanics = new List<Mechanic>() { m1, m2, m3 };
      List<Mechanic.Repair> repairs = new List<Mechanic.Repair>() { r1, r2, r3 };

      foreach (Car c in cars)
      {
        c.Broken += (sender, e) => Console.WriteLine($"Zepsuł się samochód {e.Brand} {e.Model} z przebiegiem {e.Mileage}");
      }

      for (int i = 0; i < 10; i++)
      {
        Random rand = new Random();
        Car c = cars[rand.Next(cars.Count)];
        Mechanic m = mechanics[rand.Next(mechanics.Count)];
        Mechanic.Repair r = repairs[rand.Next(repairs.Count)];

        try
        {
          int distance = rand.Next(1, 100);
          c.Drive(distance);
          Console.WriteLine($"Samochód {c.Brand} {c.Model} przejechał dystans {distance} km");
        }
        catch (EngineFailureException ex)
        {
          Console.WriteLine(ex.Message);
          c.OnBroken();
          m.PerformRepair(c, r);
        }
      }

      Console.WriteLine();
      foreach (Car c in cars)
      {
        Console.WriteLine(c);
      }

      Console.ReadKey();
    }
  }
}
