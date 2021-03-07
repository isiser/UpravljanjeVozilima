using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3.modeli
{
    class Najam
    {
        public Osoba korisnik { get; set; }
        public Vozilo vozilo { get; set; }
        public DateTime vrijemeIzdanja { get; set; }
        public Boolean placenFlag { get; set; }
        public Lokacija lokacijaNajma { get; set; }

        public Najam(Osoba korisnik, Vozilo vozilo, DateTime vrijemeIzdanja, bool placenFlag)
        {
            this.korisnik = korisnik;
            this.vozilo = vozilo;
            this.vrijemeIzdanja = vrijemeIzdanja;
            this.placenFlag = placenFlag;
        }

        public override string ToString()
        {
            return "Najam [Osoba = " + korisnik.imePrezime + ", vrijemeIzdanja = " + vrijemeIzdanja.ToString() + "]";
        }


    }
}
