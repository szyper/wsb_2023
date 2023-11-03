namespace _6_project_dziedziczenie
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

        public Address (string city, string street, string houseNumber, string postalCode)
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
            this.StudentNumber = studentNumber;
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
        static void Main(string[] args)
        {
            Person p1 = new Person("Janusz", "Nowak", new DateTime(2000, 1, 10), new Address("Poznań", "Polna", "10", "12-345"));

            Student s1 = new Student("Jan", "Kowalski", new DateTime(2001, 2, 13), 12345);

            Teacher t1 = new Teacher("Anna", "Nowak", new DateTime(1998, 10, 5), new List<string>() {"Matematyka", "Programowanie obiektowe"});

            Console.WriteLine($"\nOSOBA:\nImię: {p1.Name}, nazwisko: {p1.Surname}, Data urodzenia: {p1.DateOfBirth.ToShortDateString()} r., adres: {p1.Address.City}, ulica: {p1.Address.Street} {p1.Address.HouseNumber}, {p1.Address.PostalCode}");

            Console.WriteLine($"\nSTUDENT:\nImię: {s1.Name}, nazwisko: {s1.Surname}, Data urodzenia: {s1.DateOfBirth.ToShortDateString()} r., indeks: {s1.StudentNumber}");

            Console.WriteLine($"\nNAUCZYCIEL:\nImię: {t1.Name}, nazwisko: {t1.Surname}, Data urodzenia: {t1.DateOfBirth.ToShortDateString()} r., nauczane przedmioty: {string.Join(", ", t1.Subjects)}");
        }
    }
}