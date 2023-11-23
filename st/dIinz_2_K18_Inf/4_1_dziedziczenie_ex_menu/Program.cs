namespace _4_1_dziedziczenie_ex_1
{
  class Person
  {
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }

    public Address Address { get; set; }

    public Person(string name, string surname, DateTime dateOfBirth)
    {
      Name = name;
      Surname = surname;
      DateOfBirth = dateOfBirth;
    }

    public Person(string name, string surname, DateTime dateOfBirth, Address address) : this(name, surname, dateOfBirth)
    {
      this.Address = address;
    }

    public string GetFullName()
    {
      return Name + " " + Surname;
    }

    public int Age
    {
      get
      {
        TimeSpan difference = DateTime.Now - DateOfBirth;
        return (int)(difference.Days / 365.25);
      }
    }

  }

  class Address
  {
    public string City { get; set; }
    public string Street { get; set; }
    public string HouseNumber { get; set; }
    public string PostalCode { get; set; }

    public Address(string city, string street, string houseNumber, string postalCode)
    {
      City = city;
      Street = street;
      HouseNumber = houseNumber;
      PostalCode = postalCode;
    }
  }

  class Student : Person
  {
    public int StudentNumber { get; set; }
    public Student(string name, string surname, DateTime dateOfBirth, int studentNumber) : base(name, surname, dateOfBirth)
    {
      StudentNumber = studentNumber;
    }
  }

  class Teacher : Person
  {
    public List<string> Subjects { get; set; }
    public Teacher(string name, string surname, DateTime dateOfBirth, List<string> subjects) : base(name, surname, dateOfBirth)
    {
      Subjects = subjects;
    }
  }

  internal class Program
  {
    public static List<Person> users = new List<Person>();
    static void Main(string[] args)
    {
      /*
      Person p1 = new Person("Janusz", "Nowak", new DateTime(2000, 02, 10), new Address("Poznań", "Polna", "10c", "12-345"));
      Console.WriteLine($"\nOSOBA:\nImię: {p1.Name}, nazwisko: {p1.Surname}, data urodzenia: {p1.DateOfBirth.ToShortDateString()} r., adres: {p1.Address.City}, ulica: {p1.Address.Street} {p1.Address.HouseNumber}, {p1.Address.PostalCode}");

      Student s1 = new Student("Anna", "Nowak", new DateTime(2002, 01, 10), 22334);
      Console.WriteLine($"\nSTUDENT:\nImię: {s1.Name}, nazwisko: {s1.Surname}, data urodzenia: {s1.DateOfBirth.ToShortDateString()} r., indeks: {s1.StudentNumber}");

      Teacher t1 = new Teacher($"Anna", "Nowak", new DateTime(2002, 01, 10), new List<string>() { "matematyka", "programowanie obiektowe"});
      Console.WriteLine($"\nNAUCZYCIEL:\nImię: {s1.Name}, nazwisko: {s1.Surname}, data urodzenia: {s1.DateOfBirth.ToShortDateString()} r., nauczane przedmioty: {string.Join(", ", t1.Subjects)}");
      */

      //Console.WriteLine(DisplayMenu());

      int option = 0;

      while (option != 4)
      {
        option = DisplayMenu();

        switch (option)
        {
          case 1:
            AddUser();
            break;
          case 2:
            DisplayUsers();
            break;
          case 3:
            users.Clear();
            Console.WriteLine("\nWszyscy użytkownicy zostali usunięci\n");
            break;
          case 4:
            Console.WriteLine("\nDziękujemy za skorzystanie z programu\n");
            break;
          default:
            Console.WriteLine("\nNieprawidłowa opcja. Spróbuj ponownie\n");
            break;
        }
      }

    }

    public static int DisplayMenu()
    {
      Console.WriteLine("Program do zarządzania użytkownikami\n");
      Console.WriteLine("1: Dodaj użytkownika");
      Console.WriteLine("2: Wyświetl użytkowników");
      Console.WriteLine("3: Usuń wszystkich użytkowników");
      Console.WriteLine("4: Wyjdź z programu");

      Console.Write("\nPodaj opcję:");
      return int.Parse(Console.ReadLine());
    }

    public static void AddUser()
    {
      Console.Write("Podaj imię:");
      string name = Console.ReadLine();
      Console.Write("Podaj nazwisko:");
      string surname = Console.ReadLine();
      Console.Write("Podaj datę urodzenia użytkownika (RRRR-MM-DD):");
      DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

      Person user = new Person(name, surname, dateOfBirth);
      users.Add(user);

      Console.WriteLine($"\nUżytkownik {name} {surname} został dodany\n");
    }

    public static void DisplayUsers()
    {
      if (users.Count == 0)
      {
        Console.WriteLine("\nNie ma żadnych użytkowników\n");
      }
      else
      {
        Console.Clear();
        int count = 1;
        Console.WriteLine("Lista użytkowników:\n");
        foreach (Person user in users)
        {
          Console.WriteLine($"Użytkownik {count}:");
          Console.WriteLine($"Imię i nazwisko: {user.Name} {user.Surname}");
          Console.WriteLine($"Data urodzenia: {user.DateOfBirth.ToShortDateString()}\n");
          count++;
        }
      }
    }

  }
}