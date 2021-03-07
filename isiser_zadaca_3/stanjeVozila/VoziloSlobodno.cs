using isiser_zadaca_3.modeli;
using isiser_zadaca_3.postavkeApp;
using System;
using System.Collections.Generic;
using System.Text;

namespace isiser_zadaca_3.stanjeVozila
{
    class VoziloSlobodno : VoziloState
    {
        /*public Vozilo vozilo { get; set; }
        public VoziloSlobodno(Vozilo vozilo)
        {
            this.vozilo = vozilo;
        }
        */

        public override void iznajmiVozilo(Kapacitet k, Najam n, Aktivnost a, Cjenik c, VoziloTip vt, Osoba o, Lokacija l)
        {
            if (o.dugovanje > BazaPodataka.getInstance().vratiLimit())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Korisnik ne može iznajmiti vozilo dok ne podmiri dugovanja!");
                Console.ResetColor();
            }
            else {
                k.listaVozila.Remove(vozilo);
                k.raspolozivostVozila--;
                Najam najam = new Najam(o, vozilo, a.vrijeme, false);
                najam.lokacijaNajma = l;
                BazaPodataka.getInstance().postaviNajam(najam);
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("U " + a.vrijeme.ToString("yyyy-MM-dd HH:mm:ss") + " korisnik -" + o.imePrezime +
                    " traži na lokaciji -" + l.naziv + " najam automobila.");
                Console.WriteLine("---------------------------------------");
                this.vozilo.TransitionTo(new VoziloIznajmljeno());
                //vozilo.voziloState = new VoziloIznajmljeno();
            }
        }

        public override void vratiVozilo(Kapacitet k, Najam n, Aktivnost a, Cjenik c, VoziloTip vt, Osoba o, Lokacija l)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vozilo se ne može vratiti jer je slobodno!");
            Console.ResetColor();
        }

        public override void makniSpunjenja(VoziloTip vt, Najam n, Aktivnost a)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vozilo je slobodno i napunjeno do kraja!");
            Console.ResetColor();
        }

        public override void puniBateriju(VoziloTip vt, Najam n, Aktivnost a)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vozilo je slobodno i napunjeno do kraja!");
            Console.ResetColor();
        }
    }
}
