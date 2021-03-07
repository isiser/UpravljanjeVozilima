using System;
using System.Collections.Generic;
using System.Text;

namespace isiser_zadaca_3.modeli
{
    class Racun
    {
        public int id { get; set; }
        public static int idRacun { get; set; } = 0;
        public double iznos { get; set; }
        public DateTime datumRacuna { get; set; }
        public int lokacijaIDnajma { get; set; }
        public int lokacijaIDvracanja { get; set; }
        public Osoba osoba { get; set; }
        public Lokacija lokacija { get; set; }
        public Najam najam { get; set; }
        public VoziloTip tipVozila { get; set; }
        public bool placeno { get; set; }


        public Racun(double iznos, DateTime datumRacuna, int lokacijaIDnajma, int lokacijaIDvracanja, Osoba osoba, Lokacija l, Najam n, VoziloTip vt)
        {
            id = idRacun;
            idRacun++;
            this.iznos = iznos;
            this.datumRacuna = datumRacuna;
            this.lokacijaIDnajma = lokacijaIDnajma;
            this.lokacijaIDvracanja = lokacijaIDvracanja;
            this.osoba = osoba;
            this.lokacija = l;
            this.najam = n;
            this.tipVozila = vt;
        }
    }
}
