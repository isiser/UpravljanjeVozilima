using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3.modeli
{
    class Kapacitet
    {
        public int id { get; set; }
        public int voziloId { get; set; }
        public int brojMjesta { get; set; }
        public int raspolozivostVozila { get; set; }
        public List<Vozilo> listaVozila;

        public Kapacitet(int id, int voziloId, int brojMjesta, int raspolozivostVozila)
        {
            this.id = id;
            this.voziloId = voziloId;
            this.brojMjesta = brojMjesta;
            this.raspolozivostVozila = raspolozivostVozila;
            listaVozila = new List<Vozilo>();
        }

        public override string ToString()
        {
            return "Kapacitet [Id = " + id.ToString() + ", voziloId = " + voziloId + "]";
        }

        public void dodajVozilo(Vozilo vozilo) {
            listaVozila.Add(vozilo);
        }

        public List<Vozilo> vratiListu(){
            return listaVozila;
        }
    }
}
