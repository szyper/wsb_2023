using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_4_zad_1_wyklad
{
    internal class Osoba
    {
        private string _imie;
        private string _nazwisko;
        private Adres _adres { get; set; }

        public Osoba(string imie, string nazwisko, Adres adres)
        {
            _imie = imie;
            _nazwisko = nazwisko;
            _adres = adres;
        }

        public string Imie
        {
            get { return _imie; }
            set { _imie = value; }
        }

        public string Nazwisko
        {
            get { return _nazwisko; }
            set { _nazwisko = value; }
        }

        public string PrzedstawSie()
        {
            return $"Nazywam się: {Imie} {Nazwisko}. Adres zamieszkania: {_adres.AdresPelny}";
        }

        public void UstawDane(string imie, string nazwisko, Adres adres)
        {
            this.Imie = imie;
            this._nazwisko = nazwisko;
            this._adres = adres;
        }

         
    }
}
