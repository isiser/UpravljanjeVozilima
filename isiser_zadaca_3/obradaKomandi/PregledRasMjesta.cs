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
    public class PregledRasMjesta : IObrada
    {
        public void ObradiKomandu(Aktivnost aktivnost)
        {
            Lokacija lokacija = pronadiLokaciju(aktivnost);
            VoziloTip vozilo = pronadiVozilo(aktivnost);
            Osoba osoba = pronadiOsobu(aktivnost);

            try
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("U " + aktivnost.vrijeme.ToString("yyyy-MM-dd HH:mm:ss") + " korisnik -" +
                    osoba.imePrezime + " traži na lokaciji -" + lokacija.naziv + " broj raspoloživih mjesta za automobile.");

                foreach (Kapacitet k in BazaPodataka.getInstance().dohvatiKapacitete())
                {
                    if (lokacija.id.Equals(k.id) & vozilo.Id.Equals(k.voziloId))
                    {
                        Console.WriteLine("------> Broj raspolozivih mjesta: " + (k.brojMjesta - k.raspolozivostVozila).ToString());
                    }
                }
                Console.WriteLine("---------------------------------------");
            }
            catch (NullReferenceException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                if (lokacija == null)
                {
                    Console.WriteLine("Navedena lokacija " + aktivnost.idLokacije + " ne postoji.");

                }
                else if (vozilo == null)
                {
                    Console.WriteLine("Navedena vozilo " + aktivnost.idVozila + " ne postoji.");
                }
                else if (osoba == null)
                {
                    Console.WriteLine("Navedena osoba " + aktivnost.idKorisnika + " ne postoji.");
                }
                Console.ResetColor();
            }
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

    }
}
