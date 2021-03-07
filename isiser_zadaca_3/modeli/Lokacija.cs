using isiser_zadaca_3.izdavanjeRacuna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3.modeli
{
    class Lokacija : Subscriber
    {
        public int id { get; set; }
        public String naziv { get; set; }
        public String adresa { get; set; }
        public String gps { get; set; }
        public double zarada { get; set; }

        public Lokacija(int id, string naziv, string adresa, string gps)
        {
            zarada = 0;
            this.id = id;
            this.naziv = naziv;
            this.adresa = adresa;
            this.gps = gps;
        }

        public override string ToString()
        {
            return "Lokacija [Id = " + id.ToString() + ", naziv = " + naziv + "]";
        }

        public void Update(double iznosRacuna)
        {
            this.zarada += iznosRacuna;
        }

        public void Update(List<Racun> listaRacuna)
        {
            double pomocnaZarada = 0;
            foreach (Racun racun in listaRacuna) {
                if (this.id.Equals(racun.lokacijaIDvracanja))
                    pomocnaZarada += racun.iznos;
            }
            zarada = pomocnaZarada;
        }
    }
}
