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
        public Teacher (string name, string surname, DateTime dateOfBirth,  List<string> subjects) :base(name, surname, dateOfBirth)
        {
            Subjects = subjects;
        } 
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Janusz", "Nowak", new DateTime(2000, 02, 10), new Address("Poznań", "Polna", "10c", "12-345"));
            Console.WriteLine($"\nOSOBA:\nImię: {p1.Name}, nazwisko: {p1.Surname}, data urodzenia: {p1.DateOfBirth.ToShortDateString()} r., adres: {p1.Address.City}, ulica: {p1.Address.Street} {p1.Address.HouseNumber}, {p1.Address.PostalCode}");

            Student s1 = new Student("Anna", "Nowak", new DateTime(2002, 01, 10), 22334);
            Console.WriteLine($"\nSTUDENT:\nImię: {s1.Name}, nazwisko: {s1.Surname}, data urodzenia: {s1.DateOfBirth.ToShortDateString()} r., indeks: {s1.StudentNumber}");

            Teacher t1 = new Teacher($"Anna", "Nowak", new DateTime(2002, 01, 10), new List<string>() { "matematyka", "programowanie obiektowe"});
            Console.WriteLine($"\nNAUCZYCIEL:\nImię: {s1.Name}, nazwisko: {s1.Surname}, data urodzenia: {s1.DateOfBirth.ToShortDateString()} r., nauczane przedmioty: {string.Join(", ", t1.Subjects)}");

            /*
             * Dziedziczenie – zadanie 1
    •	Napisz program w języku C#, który ilustruje pojęcia programowania obiektowego, takie jak klasy, dziedziczenie, właściwości i metody.
    •	Zdefiniuj klasę bazową Person, która ma pola name, surname i dateOfBirth oraz konstruktor przyjmujący te wartości jako parametry.
    •	Dodaj do klasy Person metodę GetFullName, która zwraca pełne imię i nazwisko osoby, 
            oraz właściwość Age, która oblicza wiek osoby na podstawie daty urodzenia.
    •	Zdefiniuj klasę Address, która ma pola city, street, houseNumber i postalCode jako właściwości oraz konstruktor przyjmujący te wartości jako parametry.
    •	Dodaj do klasy Person pole address typu Address i zmodyfikuj konstruktor klasy Person, aby przyjmował obiekt klasy Address jako parametr.
    •	Zdefiniuj klasę pochodną Student, która dziedziczy po klasie Person i ma dodatkowe pole studentNumber oraz konstruktor przyjmujący te wartości jako parametry.
    •	Zdefiniuj klasę pochodną Teacher, która dziedziczy po klasie Person i ma dodatkowe pole subjects typu List<string> oraz konstruktor przyjmujący te wartości jako parametry.
    •	Utwórz obiekty każdej klasy, używając słowa kluczowego new i podając odpowiednie wartości w konstruktorach.
    •	Wyświetl dane utworzonych obiektów, używając metody Console.WriteLine i właściwości obiektów. 
            */
        }
    }
}