using System.Xml.Linq;

namespace _6_dziedziczenie
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
            Address = address;
        }

        public string getFullName()
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

        public Student(string name, string surname, DateTime dateOfBirth, Address address, int studentNumber) : base(name, surname, dateOfBirth, address)
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

        public Teacher(string name, string surname, DateTime dateOfBirth, Address address, List<string> subjects) : base(name, surname, dateOfBirth, address)
        {
            Subjects = subjects;
        }
    }

    internal class Program
    {
        public static List<Person> users = new List<Person>();
        static void Main(string[] args)
        {
            //Console.WriteLine(DisplayMenu()); 
            //AddUser();
            //DisplayUsers();

            int option = 0;

            while(option != 4)
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
                        Console.WriteLine("Wszyscy użytkownicy zostali usunięci");
                    break;
                    case 4:
                        Console.WriteLine("Dziękujemy za skorzystanie z programu");
                    break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie");
                    break;
                }
            }

            //Person p = new Person("Janusz", "Kowalski", DateTime.Parse("2000-04-22"));
            /*Person p = new Person("Janusz", "Kowalski", new DateTime(2000, 4, 22));

            Console.WriteLine(p.getFullName());
            Console.WriteLine(p.Age);

            Person p_address = new Person("Anna", "Kowal", new DateTime(1999, 1, 23), new Address("Poznań", "Polna", "1c/2", "11-222"));

            Student s = new Student("Paweł", "Kowalski", DateTime.Parse("2000-04-22"), 12345);
            Console.WriteLine(s.getFullName());

            Student s1 = new Student("Paweł", "Kowalski", DateTime.Parse("2000-04-22"), new Address("Poznań", "Polna", "1c/2", "11-222"), 12334);

            Teacher t1 = new Teacher("Adam", "Kowalski", DateTime.Parse("2000-04-22"), new Address("Poznań", "Polna", "1c/2", "11-222"), new List<string>() { "Programowanie obiektowe", "Matematyka" });*/

        }

        public static int DisplayMenu()
        {
            Console.WriteLine("Program do zarządzania użytkownikami\n");
            Console.WriteLine("1. Dodaj użytkownika");
            Console.WriteLine("2. Wyświetl użytkowników");
            Console.WriteLine("3. Usuń wszystkich użytkowników");
            Console.WriteLine("4. Wyjdź z programu");

            Console.Write("\nWybierz opcję:");
            return int.Parse(Console.ReadLine());
        }

        public static void AddUser()
        {
            Console.Write("Podaj imię użytkownika:");
            string name = Console.ReadLine();
            Console.Write("Podaj nazwisko użytkownika:");
            string surname = Console.ReadLine();
            Console.Write("Podaj datę urodzenia użytkownika (RRRR-MM-DD):");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            Person user = new Person(name, surname, dateOfBirth);
            users.Add(user);

            Console.WriteLine("Użytkownik {0} {1} został dodany", name, surname);
        }

        public static void DisplayUsers()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("Brak użytkowników do wyświetlenia");
            }
            else
            {
                Console.WriteLine("\n\nLista użytkowników:\n");
                foreach (Person user in users)
                {
                    Console.WriteLine("Imię i nazwisko: {0} {1}, data urodzenia: {2}\n", user.Name, user.Surname, user.DateOfBirth.ToShortDateString());
                }
            }
        }
    }
}