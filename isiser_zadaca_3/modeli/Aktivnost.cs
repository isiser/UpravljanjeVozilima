using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3.modeli
{
    public class Aktivnost
    {
        public int id { get; set; }
        public DateTime vrijeme { get; set; }
        public int idKorisnika { get; set; }
        public int idLokacije { get; set; }
        public int idVozila { get; set; }
        public int brojKm { get; set; }
        public String problemKvara { get; set; }
        public String datoteka { get; set; }
        public int orgJedinicaID { get; set; }
        public bool struktura { get; set; }
        public bool stanje { get; set; }
        public bool najam { get; set; }
        public bool zarada { get; set; }
        public DateTime datumOd { get; set; }
        public DateTime datumDo { get; set; }
        public double uplata { get; set; }



        public Aktivnost() {
        }

        public override string ToString()
        {
            return "Aktivnost [Id = " + id.ToString() + ", Vrijeme = " + vrijeme.ToString() + "]";
        }
    }
}
