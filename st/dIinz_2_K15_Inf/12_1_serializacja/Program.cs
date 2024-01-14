using System.Xml;
using System.Xml.Serialization;

namespace _12_serializacja
{
  public class Program
  {
    public class Person : IXmlSerializable
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public int Age { get; set; }

      public void WriteXml(XmlWriter writer)
      {
        writer.WriteAttributeString("FirstName", FirstName);
        writer.WriteAttributeString("LastName", LastName);
        writer.WriteAttributeString("Age", Age.ToString());
      }

      public void ReadXml(XmlReader reader)
      {
        reader.MoveToContent();
        FirstName = reader.GetAttribute("FirstName");
        LastName = reader.GetAttribute("LastName");
        Age = int.Parse(reader.GetAttribute("Age"));
      }

      public System.Xml.Schema.XmlSchema GetSchema()
      {
        return null;
      }
    }
    static void Main(string[] args)
    {
      Person p = new Person { FirstName = "Franek", LastName = "Kowalski", Age = 20 };
      XmlSerializer serializer = new XmlSerializer(typeof(Person));
      using (FileStream s = File.Create("osoba.xml"))
      {
        serializer.Serialize(s, p);
        //s.Close();
      }

      using (FileStream s = File.OpenRead("osoba.xml"))
      {
        Person p2 = (Person)serializer.Deserialize(s);
        //s.Close();
        Console.WriteLine("Imię: {0}, nazwisko: {1}, wiek: {2}", p2.FirstName, p2.LastName, p2.Age);
      }
    }
  }
}