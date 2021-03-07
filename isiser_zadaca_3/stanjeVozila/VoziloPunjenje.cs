using isiser_zadaca_3.modeli;
using System;
using System.Collections.Generic;
using System.Text;

namespace isiser_zadaca_3.stanjeVozila
{
    class VoziloPunjenje : VoziloState
    {
        public override void iznajmiVozilo(Kapacitet k, Najam n, Aktivnost a, Cjenik c, VoziloTip vt, Osoba o, Lokacija l)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vozilo se ne može iznajmiti jer je trenutno na punjenju");
            Console.ResetColor();
        }

        public override void makniSpunjenja(VoziloTip vt, Najam n, Aktivnost a)
        {
            this.vozilo.TransitionTo(new VoziloSlobodno());
        }

        public override void puniBateriju(VoziloTip vt, Najam n, Aktivnost a)
        {
            int punjenjeUsatu = 100 / vt.PunjenjeBaterijeT;
            int napunjeno = (a.vrijeme.Subtract(n.vrijemeIzdanja)).Hours * punjenjeUsatu;
            vozilo.kapacitetBaterije += napunjeno;
            if (vozilo.kapacitetBaterije >= 100)
            {
                vozilo.kapacitetBaterije = 100;
                makniSpunjenja(vt, n, a);
            }
        }

        public override void vratiVozilo(Kapacitet k, Najam n, Aktivnost a, Cjenik c, VoziloTip vt, Osoba o, Lokacija l)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vozilo se ne može vratiti jer je trenutno na punjenju!");
            Console.ResetColor();
        }
    }
}
