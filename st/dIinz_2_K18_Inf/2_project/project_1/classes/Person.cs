using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_1.classes
{
    internal class Person
    {
        public string firstName;
        public string lastName;
        public float height;
        public float weight;

        public string getData()
        {
            return "Imię i nazwisko: " + firstName + " " + lastName + "\nWzrost: " + height + "cm, waga: " + weight + "kg";
        }
    }
}
