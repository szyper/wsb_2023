using System.Xml;
using System.Xml.Serialization;

namespace _11_1_serializacja
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
            Person p = new Person { FirstName = "Janusz", LastName = "Nowak", Age = 20 };
            XmlSerializer xs = new XmlSerializer(typeof(Person));
            using (FileStream s = File.Create("osoba.xml"))
            {
                xs.Serialize(s, p);
            }

            using (FileStream s = File.OpenRead("osoba.xml"))
            {
                Person p2 = (Person)xs.Deserialize(s);
                //s.Close();
                Console.WriteLine($"Imię: {p2.FirstName}, nazwisko: {p2.LastName}, wiek: {p2.Age}\n\n");
            }
        }
    }
}