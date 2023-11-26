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
        static void Main(string[] args)
        {
            //Person p = new Person("Janusz", "Kowalski", DateTime.Parse("2000-04-22"));
            Person p = new Person("Janusz", "Kowalski", new DateTime(2000, 4, 22));

            Console.WriteLine(p.getFullName());
            Console.WriteLine(p.Age);

            Person p_address = new Person("Anna", "Kowal", new DateTime(1999, 1, 23), new Address("Poznań", "Polna", "1c/2", "11-222"));

            Student s = new Student("Paweł", "Kowalski", DateTime.Parse("2000-04-22"), 12345);
            Console.WriteLine(s.getFullName());

            Student s1 = new Student("Paweł", "Kowalski", DateTime.Parse("2000-04-22"), new Address("Poznań", "Polna", "1c/2", "11-222"), 12334);

            Teacher t1 = new Teacher("Adam", "Kowalski", DateTime.Parse("2000-04-22"), new Address("Poznań", "Polna", "1c/2", "11-222"), new List<string>() {"Programowanie obiektowe", "Matematyka"});

        }
    }
}