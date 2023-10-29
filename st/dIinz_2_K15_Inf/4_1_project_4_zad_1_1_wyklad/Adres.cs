using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_4_zad_1_wyklad
{
    internal class Adres
    {
        public string Ulica { get; set; }
        public string NumerDomu { get; set; }
        public string NumerMieszkania { get; set; }
        public string KodPocztowy { get; set; }
        public string Miasto { get; set; }
        public string Panstwo { get; set; }
        public string kontynent { get; set; }

        //public string AdresPelny => $"{AdresPocztowy} {kontynent}";
        public string AdresPelny => $"{AdresPocztowy}";


        public string AdresPocztowy
        {
            get
            {
                return $"Ul. {Ulica} {NumerDomu}/{NumerMieszkania}\n{KodPocztowy} {Miasto}\n{Panstwo}";
            }
        }
    }
}
