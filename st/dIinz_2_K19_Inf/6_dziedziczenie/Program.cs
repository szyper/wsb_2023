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
            this.Name = name;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
        }

        public Person(string name, string surname, DateTime dateOfBirth, Address address) : this (name, surname, dateOfBirth)
        {
            this.Address = address;
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

        public Address (string city, string street, string houseNumber, string postalCode)
        {
            this.City = city;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.PostalCode = postalCode;
        }
    }

    class Student : Person
    {
        public string StudentNumber { get; set; }
        public Student(string name, string surname, DateTime dateOfBirth, string studentNumber) : base(name, surname, dateOfBirth)
        {
            this.StudentNumber = studentNumber;
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