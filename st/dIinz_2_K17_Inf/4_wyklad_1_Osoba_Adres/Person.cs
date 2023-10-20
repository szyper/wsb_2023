using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_wyklad_1_Osoba_Adres
{
    internal class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Address Address { get; set; }

        public string FullAddress { get => $"{Address.PostalAddress}"; }        
        public string Introduce()
        {
            return $"Nazywam się {FirstName} {LastName}, Adres: {Address.PostalAddress}";
        }

        public void SetData(string firstName, string lastName, Address adres)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = adres;
        }
    }
}
