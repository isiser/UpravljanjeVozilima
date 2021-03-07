using isiser_zadaca_3.izdavanjeRacuna;
using System;
using System.Collections.Generic;
using System.Text;

namespace isiser_zadaca_3.modeli
{
    class Tvrtka
    {
        public int tvrtkaID { get; set; }
        public String nazivJedinice { get; set; }
        public int nadredenaJednica { get; set; }
        public List<int> lokacije { get; set; }

        public Tvrtka(int tvrtkaID, string nazivJedinice, int nadredenaJednica, List<int> lokacije)
        {
            this.lokacije = new List<int>();
            this.tvrtkaID = tvrtkaID;
            this.nazivJedinice = nazivJedinice;
            this.nadredenaJednica = nadredenaJednica;
            this.lokacije = lokacije;
        }

        public override string ToString()
        {
            return "id " + tvrtkaID + ", naziv: " + nazivJedinice + ", nadredena jed: " + nadredenaJednica;
        }


    }
}
