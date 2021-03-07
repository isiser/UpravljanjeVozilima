using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3
{
    class VoziloTip
    {
        public int Id { get; set; }
        public String Naziv { get; set; }
        public int PunjenjeBaterijeT { get; set; }
        public int Domet { get; set; }

        public VoziloTip(int id, string naziv, int punjenjeBaterijeT, int domet)
        {
            Id = id;
            Naziv = naziv;
            PunjenjeBaterijeT = punjenjeBaterijeT;
            Domet = domet;
        }

        public override string ToString()
        {
            return "Vozilo [Id = " + Id.ToString() + ", naziv = " + Naziv + "]";
        }
    }

}
