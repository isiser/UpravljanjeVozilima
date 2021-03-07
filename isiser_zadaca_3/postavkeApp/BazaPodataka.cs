using isiser_zadaca_3.izdavanjeRacuna;
using isiser_zadaca_3.modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3.postavkeApp
{
    class BazaPodataka
    {
        public List<VoziloTip> listaVozila;
        public List<Cjenik> listaCjenika;
        public List<Osoba> listaOsoba;
        public List<Lokacija> listaLokacija;
        public List<Kapacitet> listaKapaciteta;
        public List<Aktivnost> listaAktivnosti;
        public List<Najam> listaNajmova;
        public List<Tvrtka> listaTvrtki;
        public IDictionary<string, string> listaKonfiguracija;
        public Publisher publisher;
        public double limit;

        //interaktivno - false, skupno - true
        public Boolean nacinRadaFlag = false;

        private static BazaPodataka INSTANCE;

        public BazaPodataka()
        {
            listaVozila = new List<VoziloTip>();
            listaCjenika = new List<Cjenik>();
            listaOsoba = new List<Osoba>();
            listaLokacija = new List<Lokacija>();
            listaKapaciteta = new List<Kapacitet>();
            listaAktivnosti = new List<Aktivnost>();
            listaNajmova = new List<Najam>();
            listaTvrtki = new List<Tvrtka>();
            listaKonfiguracija = new Dictionary<string, string>();
            publisher = new Publisher();
            limit = 0;
        }

        public static BazaPodataka getInstance() {
            if (INSTANCE == null) {
                INSTANCE = new BazaPodataka();
            }
            return INSTANCE;
        }

        public void postaviLimit(double limit) {
            this.limit = limit;
        }

        public double vratiLimit()
        {
            return limit;
        }


        public void postaviVozilo(VoziloTip vozilo) {
            listaVozila.Add(vozilo);
        }

        public List<VoziloTip> dohvatiVozila()
        {
            return listaVozila;
        }

        public void postaviCjenik(Cjenik cjenik)
        {
            listaCjenika.Add(cjenik);
        }

        public List<Cjenik> dohvatiCjenike()
        {
            return listaCjenika;
        }

        public void postaviOsobu(Osoba osoba)
        {
            listaOsoba.Add(osoba);
        }

        public List<Osoba> dohvatiOsobe()
        {
            return listaOsoba;
        }

        public void postaviLokaciju(Lokacija lokacija)
        {
            listaLokacija.Add(lokacija);
        }

        public List<Lokacija> dohvatiLokacije()
        {
            return listaLokacija;
        }

        public void postaviKapacitet(Kapacitet kapacitet)
        {
            listaKapaciteta.Add(kapacitet);
        }

        public List<Kapacitet> dohvatiKapacitete()
        {
            return listaKapaciteta;
        }

        public void postaviAktivnost(Aktivnost aktivnost)
        {
            listaAktivnosti.Add(aktivnost);
        }

        public List<Aktivnost> dohvatiAktivnosti()
        {
            return listaAktivnosti;
        }

        public void postaviNacinRada(Boolean flag)
        {
            nacinRadaFlag = flag;
        }

        public Boolean dohvatiNacinRada()
        {
            return nacinRadaFlag;
        }

        public void postaviNajam(Najam najam)
        {
            listaNajmova.Add(najam);
        }

        public List<Najam> dohvatiNajmove()
        {
            return listaNajmova;
        }

        public void postaviTvrtku(Tvrtka tvrtka)
        {
            listaTvrtki.Add(tvrtka);
        }

        public List<Tvrtka> dohvatiTvrtke()
        {
            return listaTvrtki;
        }

        public void postaviKonfiguraciju(String kljuc, String vrijednost)
        {
            listaKonfiguracija.Add(kljuc, vrijednost);
        }

        public IDictionary<string, string> dohvatiKonfiguracije()
        {
            return listaKonfiguracija;
        }

    }
}
