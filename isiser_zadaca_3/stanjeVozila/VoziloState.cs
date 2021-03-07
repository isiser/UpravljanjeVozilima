using isiser_zadaca_3.modeli;
using System;
using System.Collections.Generic;
using System.Text;

namespace isiser_zadaca_3.stanjeVozila
{
    abstract class VoziloState
    {
        protected Vozilo vozilo;

        public void SetStanje(Vozilo vozilo) {
            this.vozilo = vozilo;
        }

        public abstract void vratiVozilo(Kapacitet k, Najam n, Aktivnost a, Cjenik c, VoziloTip vt, Osoba o, Lokacija l);

        public abstract void iznajmiVozilo(Kapacitet k, Najam n, Aktivnost a, Cjenik c, VoziloTip vt, Osoba o, Lokacija l);

        public abstract void puniBateriju(VoziloTip vt, Najam n, Aktivnost a);

        public abstract void makniSpunjenja(VoziloTip vt, Najam n, Aktivnost a);

    }
}
