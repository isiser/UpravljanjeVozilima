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
    public class NajamVozila : IObrada
    {
        public void ObradiKomandu(Aktivnost aktivnost)
        {
            Lokacija lokacija = pronadiLokaciju(aktivnost);
            VoziloTip voziloTip = pronadiVozilo(aktivnost);
            Osoba osoba = pronadiOsobu(aktivnost);

            try
            {

                Boolean sadrziNajam = false;

                //PROVJERA - korisnik sadrzi najam određene vrste vozila
                foreach (Najam n in BazaPodataka.getInstance().dohvatiNajmove())
                {
                    if (n.korisnik.id.Equals(osoba.id) && n.placenFlag.Equals(false) && n.vozilo.tipVozila.Equals(voziloTip.Id))
                        sadrziNajam = true;
                }

                if (!sadrziNajam)
                {
                    Kapacitet kapacitet = pronadiKapacitet(aktivnost);
                    Vozilo odabranoVozilo = null;
                    foreach (Vozilo ve in kapacitet.listaVozila)
                    {
                        if (ve.kapacitetBaterije == 100)
                        {
                            odabranoVozilo = ve;
                            if (dohvatiBrojNajmaVozila(ve) < dohvatiBrojNajmaVozila(odabranoVozilo))
                            {
                                odabranoVozilo = ve;
                            }
                            else if (dohvatiBrojNajmaVozila(ve) == dohvatiBrojNajmaVozila(odabranoVozilo))
                            {
                                if (ve.brojKm < odabranoVozilo.brojKm)
                                {
                                    odabranoVozilo = ve;
                                }
                                else if (ve.brojKm == odabranoVozilo.brojKm)
                                {
                                    if (ve.voziloID < odabranoVozilo.voziloID)
                                    {
                                        odabranoVozilo = ve;
                                    }
                                }
                            }
                        }
                    }
                    if (odabranoVozilo != null)
                    {
                        if (odabranoVozilo.ispravno)
                        {
                            odabranoVozilo.Iznajmi(kapacitet, null, aktivnost, null, voziloTip, osoba, lokacija);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Odabrano vozilo (" + voziloTip.Naziv + ")" + odabranoVozilo.voziloID + " nije ispravno.");
                            Console.ResetColor();
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Na lokaciji -" + lokacija.naziv + " nema raspolozivog vozila.");
                        Console.ResetColor();

                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Korisnik -" + osoba.imePrezime + " vec sadrzi najam vozila (tipa:" + voziloTip.Naziv + ").");
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

        private Kapacitet pronadiKapacitet(Aktivnost a) {
            Kapacitet kapacitet = null;
            foreach (Kapacitet k in BazaPodataka.getInstance().dohvatiKapacitete())
            {
                if (k.id.Equals(a.idLokacije) && k.voziloId.Equals(a.idVozila))
                    kapacitet = k;
            }
            return kapacitet;
        }

        private int dohvatiBrojNajmaVozila(Vozilo v) {
            int najam = 0;
            foreach (Najam n in BazaPodataka.getInstance().dohvatiNajmove()) {
                if (v.voziloID.Equals(n.vozilo.voziloID))
                    najam++;
            }
            return najam;
        }

    }
}
