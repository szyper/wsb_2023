using System.Diagnostics.CodeAnalysis;

namespace _7_1_interfejsy
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

    public override string ToString()
    {
      return $"{title}, {author}, {yearOfPublication}, {price} zł";
    }

    public int CompareTo([AllowNull] Book other)
    {
      if (other == null)
      {
        return 1;
      }
      return price.CompareTo(other.price);
    }

  }
  internal class Program
  {
    static void Main(string[] args)
    {
      List<Book> books = new List<Book>();
      books.Add(new Book("Hobbit", "Nowak", 1937, 45.99));
      books.Add(new Book("Hobbit2", "Pawlak", 2000, 155.99));
      books.Add(new Book("Hobbit3", "Arbuz", 2000, 5.99));
      books.Add(new Book("Hobbit3", "Arbuz", 1948, 5.99));

      books.Sort();
      Console.WriteLine("Sortowanie według ceny:");
      foreach (Book book in books)
      {
        Console.WriteLine(book);
      }

      Console.WriteLine("\nSortowanie według daty publikacji:");
      var sortedByYear = books.OrderBy(b => b.yearOfPublication);
      foreach (Book book in sortedByYear)
      {
        Console.WriteLine(book);
      }

      Console.WriteLine("\nSortowanie według autora:");
      var sortedByAuthor = books.OrderByDescending(b => b.author);
      foreach (Book book in sortedByAuthor)
      {
        Console.WriteLine(book);
      }

      Console.WriteLine("\nSortowanie według ceny nierosnąco a następnie według roku od najstarszej książki:");
      var sortedByPriceAndYear = books.OrderByDescending(b => b.price).ThenBy(b => b.yearOfPublication);
      foreach (Book book in sortedByPriceAndYear)
      {
        Console.WriteLine(book);
      }
      
    }
  }
}