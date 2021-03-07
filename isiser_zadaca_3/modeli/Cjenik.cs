using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3
{
    public class Cjenik
    {
        public int VoziloId { get; set; }
        public double Najam { get; set; }
        public double PoSatu { get; set; }
        public double PoKm { get; set; }

        public Cjenik(int voziloId, double najam, double poSatu, double poKm)
        {
            VoziloId = voziloId;
            Najam = najam;
            PoSatu = poSatu;
            PoKm = poKm;
        }

        public override string ToString()
        {
            return "Cjenik [Id = " + VoziloId.ToString() + ", Najam = " + Najam.ToString() + "]";
        }

    }
}
