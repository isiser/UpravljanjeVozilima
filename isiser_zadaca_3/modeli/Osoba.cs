using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3.modeli
{
    class Osoba
    {
        public int id { get; set; }
        public String imePrezime { get; set; }
        public int brojVracenihNeispravnih { get; set; }
        public int ugovor { get; set; }
        public double dugovanje { get; set; }

        public Osoba(int id, string imePrezime, int ugovor)
        {
            this.dugovanje = 0;
            this.brojVracenihNeispravnih = 0; 
            this.id = id;
            this.imePrezime = imePrezime;
            this.ugovor = ugovor;
        }

        public override string ToString()
        {
            return "Osoba [Id = " + id.ToString() + ", imePrezime = " + imePrezime + "]";
        }
    }
}
