using isiser_zadaca_3.modeli;
using isiser_zadaca_3.postavkeApp;
using System;
using System.Collections.Generic;
using System.Text;

namespace isiser_zadaca_3.stanjeVozila
{
    class VoziloIznajmljeno : VoziloState
    {
        public override void iznajmiVozilo(Kapacitet k, Najam n, Aktivnost a, Cjenik c, VoziloTip vt, Osoba o, Lokacija l)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vozilo se ne može iznajmiti jer je već iznajmljeno");
            Console.ResetColor();
        }

        public override void makniSpunjenja(VoziloTip vt, Najam n, Aktivnost a)
        {
            throw new NotImplementedException();
        }

        public override void puniBateriju(VoziloTip vt, Najam n, Aktivnost a)
        {
            this.vozilo.TransitionTo(new VoziloPunjenje());
        }

        public override void vratiVozilo(Kapacitet k, Najam n, Aktivnost a, Cjenik c, VoziloTip vt, Osoba o, Lokacija l)
        {
            int stariBrojKm = n.vozilo.brojKm;
            n.vozilo.brojKm = a.brojKm;

            n.vozilo.kapacitetBaterije -= ((Double)a.brojKm / (Double)vt.Domet) * 100;

            int trajanjeNajmaH = a.vrijeme.Subtract(n.vrijemeIzdanja).Hours + 1;

            k.raspolozivostVozila++;
            n.vozilo.tipVozila = vt.Id;
            k.listaVozila.Add(n.vozilo);
            n.vrijemeIzdanja = a.vrijeme;
            double iznosRacuna = c.Najam + (trajanjeNajmaH * c.PoSatu) + ((n.vozilo.brojKm - stariBrojKm) * c.PoKm);
            Racun racun = new Racun(iznosRacuna, a.vrijeme, n.lokacijaNajma.id, l.id, o, l, n, vt);
            BazaPodataka.getInstance().publisher.dohvatiRacun(racun);

            if (o.ugovor == 1)
            {
                o.dugovanje += iznosRacuna;
                racun.placeno = false;
            }
            else {
                racun.placeno = true;
            }

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Datum izdavanja racuna: " + a.vrijeme.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine("Racun zaprima korisnik: " + o.imePrezime);
            Console.WriteLine("Unamjeno vozilo se vraća na lokaciju: " + l.naziv);
            Console.WriteLine("Stavke računa su: ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1 najam " + vt.Naziv + " - " + c.Najam.ToString() + " kn.");
            Console.WriteLine("Trajanje: " + trajanjeNajmaH.ToString() + " h - " + (trajanjeNajmaH * c.PoSatu).ToString() + " kn.");
            Console.WriteLine("Prethodna kilometraza vozila - " + stariBrojKm.ToString() + " km.");
            Console.WriteLine("Nova kilometraza vozila - " + n.vozilo.brojKm.ToString() + " km.");
            Console.WriteLine("Prijedeno: " + (n.vozilo.brojKm - stariBrojKm).ToString() + " km - " +
                (n.vozilo.brojKm - stariBrojKm) * c.PoKm + " kn (" + c.PoKm + "kn/km).");
            Console.WriteLine("Ukupan iznos racuna: " + (iznosRacuna).ToString() + " kn.");
            Console.WriteLine("=========================================");
            Console.WriteLine("---------------------------------------");

            puniBateriju(vt, n, a);
        }
    }
}
