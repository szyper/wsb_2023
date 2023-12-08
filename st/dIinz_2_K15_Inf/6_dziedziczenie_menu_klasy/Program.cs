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
            int option = 0;

            while (option != 8)
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
                        AddStudent();
                        break;
                    case 4:
                        DisplayStudents();
                        break;
                    case 5:
                        AddTeacher();
                        break;
                    case 6:
                        DisplayTeachers();
                        break;
                    case 7:
                        users.Clear();
                        Console.WriteLine("Wszyscy użytkownicy zostali usunięci");
                        break;
                    case 8:
                        Console.WriteLine("Dziękujemy za skorzystanie z programu");
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie");
                        break;
                }
            }


        }




        public static int DisplayMenu()
        {
            Console.WriteLine("Program do zarządzania użytkownikami\n");
            Console.WriteLine("1. Dodaj użytkownika");
            Console.WriteLine("2. Wyświetl użytkowników");
            Console.WriteLine("3. Dodaj studenta");
            Console.WriteLine("4. Wyświetl studentów");
            Console.WriteLine("5. Dodaj nauczyciela");
            Console.WriteLine("6. Wyświetl nauczycieli");
            Console.WriteLine("7. Usuń wszystkich użytkowników");
            Console.WriteLine("8. Wyjdź z programu");

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


        public static void AddStudent()
        {
            Console.Write("Podaj imię studenta:");
            string name = Console.ReadLine();
            Console.Write("Podaj nazwisko studenta:");
            string surname = Console.ReadLine();
            Console.Write("Podaj datę urodzenia studenta (RRRR-MM-DD):");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Podaj numer indeksu studenta:");
            int studentNumber = int.Parse(Console.ReadLine());

            Student student = new Student(name, surname, dateOfBirth, studentNumber);
            users.Add(student);
            Console.WriteLine($"\nUżytkownik {name} {surname} został dodany\n");
        }


        public static void DisplayStudents()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("\nBrak sudentów do wyświetlenia\n");
            }
            else
            {
                Console.Clear();
                int count = 0;
                foreach (Person student in users)
                {
                    if (student is Student)
                    {
                        count++;
                        if (count == 1)
                        {
                            Console.WriteLine("\n\nLista studentów:\n");
                        }
                        Console.WriteLine("Imię i nazwisko: {0} {1}, data urodzenia: {2}", student.Name, student.Surname, student.DateOfBirth.ToShortDateString());
                        Console.WriteLine("Numer indeksu: {0}", ((Student)student).StudentNumber);
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("\nBrak studentów do wyświetlenia\n");
                }
            }
        }

        public static void AddTeacher()
        {
            Console.Write("Podaj imię nauczyciel:");
            string name = Console.ReadLine();
            Console.Write("Podaj nazwisko nauczyciela:");
            string surname = Console.ReadLine();
            Console.Write("Podaj datę urodzenia nauczyciela (RRRR-MM-DD):");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Podaj liczbę przdmiotów nauczyciela:");
            int subjectCount = int.Parse(Console.ReadLine());
            List<string> subjects = new List<string>();

            for (int i = 0; i < subjectCount; i++)
            {
                Console.Write($"Podaj nazwę przedmiotu {i + 1}:");
                string subject = Console.ReadLine();
                subjects.Add(subject);
            }

            Teacher teacher = new Teacher(name, surname, dateOfBirth, subjects);
            users.Add(teacher);
            Console.WriteLine($"\nNauczyciel {name} {surname} został dodany\n");
        }

        public static void DisplayTeachers()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("\nBrak nauczycieli do wyświetlenia\n");
            }
            else
            {
                Console.Clear();
                int count = 0;
                foreach (Person teacher in users)
                {
                    if (teacher is Teacher)
                    {
                        count++;
                        if (count == 1)
                        {
                            Console.WriteLine("\n\nLista nauczycieli:\n");
                        }
                        Console.WriteLine("Imię i nazwisko: {0} {1}, data urodzenia: {2}", teacher.Name, teacher.Surname, teacher.DateOfBirth.ToShortDateString());
                        Console.WriteLine("Przedmioty: {0}\n", string.Join(",", ((Teacher)teacher).Subjects));
                    }
                }

                if (count == 0)
                {
                    Console.WriteLine("\nBrak nauczycieli do wyświetlenia\n");
                }
            }
        }
    }
}