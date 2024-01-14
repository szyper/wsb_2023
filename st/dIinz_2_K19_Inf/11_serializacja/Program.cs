using System.Xml.Serialization;

namespace _11_serializacja
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
      Person p = new Person { FirstName = "Franek", LastName = "Nowak", Age = 20 };
      XmlSerializer serializer = new XmlSerializer(typeof(Person));
      using (FileStream s = File.Create("osoba.xml"))
      {
        serializer.Serialize(s, p);
        //s.Close();
      }
    }
  }
}