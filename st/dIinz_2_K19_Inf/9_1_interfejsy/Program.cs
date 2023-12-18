using System.Diagnostics.CodeAnalysis;

namespace _9_1_interfejsy
{
    class Book : IComparable<Book>
    {
        string title;
        public string author;
        public int yearOfPublication;
        public double price;
        public Book(string title, string author, int yearOfPublication, double price)
        {
            this.title = title;
            this.author = author;
            this.yearOfPublication = yearOfPublication;
            this.price = price;
        }
        public int CompareTo([AllowNull] Book other)
        //public int CompareTo(Book? other)
        {
            if (other == null) return 1;
            //return author.CompareTo(other.author);
            return price.CompareTo(other.price);
        }

        public override string ToString()
        {
            return $"{title}, {author}, {yearOfPublication}, {price} zł";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();

            books.Add(new Book("Hobbit", "Nowak", 1937, 45.99));
            books.Add(new Book("Hobbit2", "Pawlak", 2000, 145.99));
            books.Add(new Book("Hobbit3", "Antosiak", 2000, 5.99));
            books.Add(new Book("Hobbit4", "Antosiak", 1948, 5.99));

            Console.WriteLine("Lista książek:");

            foreach (Book book in books)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();

            books.Sort();
            Console.WriteLine("Posortowana lista książek:");

            foreach (Book book in books)
            {
                //Console.WriteLine(book.ToString());
                Console.WriteLine(book);
            }
            Console.WriteLine();

            Console.WriteLine("Sortowanie według daty publikacji:");
            var sortedByYear = books.OrderBy(b => b.yearOfPublication);
            foreach (Book book in sortedByYear)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();

            Console.WriteLine("Sortowanie według autora:");
            var sortedByAuthorDesc = books.OrderByDescending(b => b.author);
            foreach (Book book in sortedByAuthorDesc)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();

            Console.WriteLine("Sortowanie według ceny nierosnąco a następnie według roku od najstarszej książki");

            var sortedByPriceDescAndYear = books.OrderByDescending(b => b.price).ThenBy(b => b.yearOfPublication);
            foreach (Book book in sortedByPriceDescAndYear)
            {
                Console.WriteLine(book);
            }
        }
    }
}