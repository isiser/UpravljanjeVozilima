using isiser_zadaca_3.stanjeVozila;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3.modeli
{
    class Vozilo
    {
        public int voziloID { get; set; } = 0;
        public int tipVozila { get; set; }
        public double kapacitetBaterije { get; set; }
        public int brojKm { get; set; }
        public bool ispravno { get; set; }
        public VoziloState voziloState { get; set; } = null;

        public Vozilo()
        {
            this.kapacitetBaterije = 100;
            this.brojKm = 0;
            this.ispravno = true;
            TransitionTo(new VoziloSlobodno());

        }

        public Vozilo Clone(int tipVozila) {
            voziloID++;
            Vozilo clone = (Vozilo)this.MemberwiseClone();
            clone.voziloID = voziloID;
            clone.tipVozila = tipVozila;
            clone.kapacitetBaterije = this.kapacitetBaterije;
            clone.brojKm = brojKm;
            clone.ispravno = this.ispravno;
            return clone;
        }

        public void Iznajmi(Kapacitet k, Najam n, Aktivnost a, Cjenik c, VoziloTip vt, Osoba o, Lokacija l) {
            this.voziloState.iznajmiVozilo(k, n, a, c, vt, o, l);
        }

        public void Vrati(Kapacitet k, Najam n, Aktivnost a, Cjenik c, VoziloTip vt, Osoba o, Lokacija l)
        {
            this.voziloState.vratiVozilo(k, n, a, c, vt, o, l);
        }

        public void PuniBateriju(VoziloTip vt, Najam n, Aktivnost a) {
            this.voziloState.puniBateriju(vt, n, a);
        }

        public void PrestaniPunit(VoziloTip vt, Najam n, Aktivnost a)
        {
            this.voziloState.makniSpunjenja(vt, n, a);
        }

        public void TransitionTo(VoziloState state) {
            this.voziloState = state;
            this.voziloState.SetStanje(this);
        }
    }
}
