using System.Diagnostics;

namespace _6_project_dziedziczenie_zad_menu_student_nauczyciel
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
        public static List<Person> users = new List<Person>();
        static void Main(string[] args)
        {
            int option = 0;

            while (option != 8)
            {
                option = DisplayMenu();
                //Console.WriteLine(option);

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
                        Console.WriteLine("\nWszyscy użytkownicy zostali usunięci\n");
                        break;
                    case 8:
                        Console.WriteLine("\nDziękujemy za skorzystanie z programu.\n");
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie");
                        break;
                }
            }

            /*Person p1 = new Person("Janusz", "Nowak", new DateTime(2000, 1, 10), new Address("Poznań", "Polna", "10", "12-345"));

            Student s1 = new Student("Jan", "Kowalski", new DateTime(2001, 2, 13), 12345);

            Teacher t1 = new Teacher("Anna", "Nowak", new DateTime(1998, 10, 5), new List<string>() { "Matematyka", "Programowanie obiektowe" });

            Console.WriteLine($"\nOSOBA:\nImię: {p1.Name}, nazwisko: {p1.Surname}, Data urodzenia: {p1.DateOfBirth.ToShortDateString()} r., adres: {p1.Address.City}, ulica: {p1.Address.Street} {p1.Address.HouseNumber}, {p1.Address.PostalCode}");

            Console.WriteLine($"\nSTUDENT:\nImię: {s1.Name}, nazwisko: {s1.Surname}, Data urodzenia: {s1.DateOfBirth.ToShortDateString()} r., indeks: {s1.StudentNumber}");

            Console.WriteLine($"\nNAUCZYCIEL:\nImię: {t1.Name}, nazwisko: {t1.Surname}, Data urodzenia: {t1.DateOfBirth.ToShortDateString()} r., nauczane przedmioty: {string.Join(", ", t1.Subjects)}");*/
        }

        public static int DisplayMenu()
        {
            Console.WriteLine("Program do zarządzania użytkownikami\n");
            Console.WriteLine("1: Dodaj użytkownika");
            Console.WriteLine("2: Wyświetl użytkowników");
            Console.WriteLine("3: Dodaj studenta");
            Console.WriteLine("4: Wyświetl studentów");
            Console.WriteLine("5: Dodaj nauczyciela");
            Console.WriteLine("6: Wyświetl nauczycieli");
            Console.WriteLine("7: Usuń wszystkich użytkowników");
            Console.WriteLine("8: Wyjdź z programu");

            Console.Write("\nWybierz opcję:");
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
                Console.WriteLine("\nLista użytkowników:\n");
                foreach (Person user in users)
                {
                    Console.WriteLine($"Użytkownik {count}:");
                    Console.WriteLine($"Imię i nazwisko: {user.Name} {user.Surname}\nData urodzenia: {user.DateOfBirth.ToShortDateString()}\n");
                    count++;
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
                Console.WriteLine("\nNie ma żadnych studentów\n");
            }
            else
            {
                Console.Clear();
                int count = 1;
                Console.WriteLine("\nLista studentów:\n");
                foreach (Person user in users)
                {
                    if (user is Student)
                    {
                        Console.WriteLine($"Student {count}:");
                        Console.WriteLine($"Imię i nazwisko: {user.Name} {user.Surname}\nData urodzenia: {user.DateOfBirth.ToShortDateString()}\nNumer indeksu: {((Student)user).StudentNumber}");
                    }
                    
                    count++;
                }
            }
        }

        public static void AddTeacher()
        {
            Console.Write("Podaj imię nauczyciela:");
            string name = Console.ReadLine();
            Console.Write("Podaj nazwisko nauczyciela:");
            string surname = Console.ReadLine();
            Console.Write("Podaj datę urodzenia nauczyciela (RRRR-MM-DD):");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
            Console.Write("Podaj liczbę przedmiotów nauczyciela:");
            int subjectCount = int.Parse(Console.ReadLine());
            List<string> subjects = new List<string>();
            for (int i = 0; i < subjectCount; i++)
            {
                Console.Write($"Podaj nazwę przedmiot {i + 1}:");
                string subject = Console.ReadLine();
                subjects.Add(subject);
            }

            Teacher teacher = new Teacher(name, surname, dateOfBirth, subjects);
            users.Add(teacher);
            Console.WriteLine($"\nUżytkownik {name} {surname} został dodany\n");
        }

        public static void DisplayTeachers()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("\nNie ma żadnych nauczycieli\n");
            }
            else
            {
                Console.Clear();
                int count = 1;
                Console.WriteLine("\nLista nauczycieli:\n");
                foreach (Person user in users)
                {
                    if (user is Teacher)
                    {
                        Console.WriteLine($"Nauczyciel {count}:");
                        Console.WriteLine($"Imię i nazwisko: {user.Name} {user.Surname}\nData urodzenia: {user.DateOfBirth.ToShortDateString()}\nPrzedmioty: {string.Join(", ", ((Teacher)user).Subjects)}\n");
                    }

                    count++;
                }
            }
        }
    }
}
