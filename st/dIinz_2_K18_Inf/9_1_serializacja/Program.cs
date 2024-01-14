using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace _9_1_serializacja
{
  public class Program
  {
    public class Person
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public int Age { get; set; }
    }
    static void Main(string[] args)
    {
      Person p = new Person { FirstName = "Janusz", LastName = "Nowak", Age = 20 };
      XmlSerializer xs = new XmlSerializer(typeof(Person));
      using (FileStream s = File.Create("osoba.xml"))
      {
        xs.Serialize(s, p);
        //s.Close();
      }
    }
  }
}