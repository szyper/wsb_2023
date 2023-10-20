using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_wyklad_1_Osoba_Adres
{
    internal class Address
    {
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country{ get; set; }

        public string PostalAddress 
        {
            get
            {
                return $"Ul. {Street} {BuildingNumber}/{ApartmentNumber}\n{PostalCode} {City}\n{Country}";
            }
        }
    }
}
