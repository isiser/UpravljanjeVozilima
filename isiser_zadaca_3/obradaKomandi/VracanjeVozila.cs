using isiser_zadaca_3.modeli;
using isiser_zadaca_3.postavkeApp;
using isiser_zadaca_3.stvaranjeAktivnosti;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3.ucitavanjeDatoteka
{
    public class VracanjeVozila : IObrada
    {
        public void ObradiKomandu(Aktivnost aktivnost)
        {
            Lokacija lokacija = pronadiLokaciju(aktivnost);
            VoziloTip voziloTip = pronadiVozilo(aktivnost);
            Osoba osoba = pronadiOsobu(aktivnost);
            Najam najam = pronadiNajam(aktivnost);
            Cjenik cjenik = pronadiCjenik(aktivnost);

            Kapacitet kapacitet = pronadiKapacitet(aktivnost);

            try
            {
                if (osoba == null) { 
                
                }
                if (sadrziNajam(osoba))
                {
                    if ((kapacitet.brojMjesta - kapacitet.raspolozivostVozila) == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Lokacija -" + lokacija.naziv + " ne sadrzi slobodnih mjesta vozila.");
                        Console.ResetColor();
                    }
                    else
                    {
                        najam.placenFlag = true;
                        najam.vozilo.Vrati(kapacitet, najam, aktivnost, cjenik, voziloTip, osoba, lokacija);
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Korisnik -" + osoba.imePrezime + " ne sadrzi najam navedenog vozila.");
                    Console.ResetColor();
                }
            }
            catch (NullReferenceException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (lokacija == null)
                {
                    Console.WriteLine("Navedena lokacija " + aktivnost.idLokacije + " ne postoji.");

                }
                else if (voziloTip == null)
                {
                    Console.WriteLine("Navedena vozilo " + aktivnost.idVozila + " ne postoji.");
                }
                else if (osoba == null)
                {
                    Console.WriteLine("Navedena osoba " + aktivnost.idKorisnika + " ne postoji.");
                }
                else if (najam == null)
                {
                    Console.WriteLine("Navedeni najam korisnika" + najam.korisnik + " ne postoji.");
                }
                else if (cjenik == null)
                {
                    Console.WriteLine("Navedena cjenik za vozilo " + cjenik.VoziloId + " ne postoji.");
                }
                else if (kapacitet == null)
                {
                    Console.WriteLine("Navedena kapacitet " + kapacitet.id + " ne postoji.");
                }
                Console.ResetColor();
            }
        }

        private Boolean sadrziNajam(Osoba osoba) {
            Boolean sadrziNajam = false;

            if (osoba != null)
            {
                foreach (Najam n in BazaPodataka.getInstance().dohvatiNajmove())
                {

                    if (n.korisnik.id.Equals(osoba.id) && n.placenFlag.Equals(false))
                        sadrziNajam = true;
                }
            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Osoba ne postoji.");
                Console.ResetColor();
            }
            return sadrziNajam;
        }

        private Osoba pronadiOsobu(Aktivnost a)
        {
            Osoba osoba = null;
            foreach (Osoba o in BazaPodataka.getInstance().dohvatiOsobe())
            {
                if (a.idKorisnika.Equals(o.id))
                    osoba = o;
            }
            return osoba;
        }

        private Lokacija pronadiLokaciju(Aktivnost a) {
            Lokacija lokacija = null;
            foreach (Lokacija l in BazaPodataka.getInstance().dohvatiLokacije()) {
                if (a.idLokacije.Equals(l.id))
                    lokacija = l;
            }
            return lokacija;
        }

        private VoziloTip pronadiVozilo(Aktivnost a)
        {
            VoziloTip vozilo = null;
            foreach (VoziloTip v in BazaPodataka.getInstance().dohvatiVozila())
            {
                if (a.idVozila.Equals(v.Id))
                    vozilo = v;
            }
            return vozilo;
        }

        private Kapacitet pronadiKapacitet(Aktivnost a) {
            Kapacitet kapacitet = null;
            foreach (Kapacitet k in BazaPodataka.getInstance().dohvatiKapacitete())
            {
                if (k.id.Equals(a.idLokacije) && k.voziloId.Equals(a.idVozila))
                    kapacitet = k;
            }
            return kapacitet;
        }

        private Najam pronadiNajam(Aktivnost a)
        {
            Najam najam = null;
            foreach (Najam n in BazaPodataka.getInstance().dohvatiNajmove())
            {
                if (n.korisnik.id.Equals(a.idKorisnika) && n.placenFlag.Equals(false))
                    najam = n;
            }
            return najam;
        }

        private Cjenik pronadiCjenik(Aktivnost a)
        {
            Cjenik cjenik = null;
            foreach (Cjenik c in BazaPodataka.getInstance().dohvatiCjenike())
            {
                if (c.VoziloId.Equals(a.idVozila))
                    cjenik = c;
            }
            return cjenik;
        }

    }
}
