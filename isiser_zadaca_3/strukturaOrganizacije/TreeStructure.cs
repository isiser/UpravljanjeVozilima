using isiser_zadaca_3.ispisPodatakaOrganizacije;
using isiser_zadaca_3.modeli;
using isiser_zadaca_3.postavkeApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace isiser_zadaca_3.strukturaOrganizacije
{
    class TreeStructure
    {
        List<OrganizationComponent> components = new List<OrganizationComponent>();

        public void CreateTree() {
            OrganizationComponent root = null;
            OrganizationComponent parent = null;
            foreach (Tvrtka t in BazaPodataka.getInstance().dohvatiTvrtke())
            {
                if (t.nadredenaJednica.Equals(00))
                {
                    root = new OrganizationUnit(t.tvrtkaID, t.nazivJedinice);
                }
                else
                {
                    parent = components.Where((x) => x.getUnitID() == t.nadredenaJednica).SingleOrDefault();
                    root = new OrganizationUnit(t.tvrtkaID, t.nazivJedinice);
                    parent.Add(root);
                }
                foreach (int l in t.lokacije) {
                    Lokacija lokacija = getLocationByID(l);
                    root.Add(new OrganizationLocation(lokacija.id, lokacija.naziv, lokacija.adresa,
                        lokacija.gps, lokacija.zarada, getStanjeLokacija(lokacija.id)["brojMjesta"],
                        getStanjeLokacija(lokacija.id)["raspolozivost"], getStanjeLokacija(lokacija.id)["brojNeispravnih"]));
                }
                components.Add(root);
            }
            
        }

        public void DisplayTree() {
            foreach (OrganizationComponent oc in components)
            {
                oc.displayOrganizationInfo();
            }
        }

        public Lokacija getLocationByID(int id) {
            Lokacija lokacija = null;
            foreach (Lokacija l in BazaPodataka.getInstance().dohvatiLokacije()) {
                if (l.id.Equals(id))
                    lokacija = l;

            }
            return lokacija;
        }

        public IDictionary<string, int> getStanjeLokacija(int id) {
            IDictionary<string, int> stanja = new Dictionary<string, int>();
            int brojMjesta = 0;
            int raspolozivost = 0;
            int brojNeispravnih = 0;
            foreach (Kapacitet k in BazaPodataka.getInstance().dohvatiKapacitete()) {
                if (k.id.Equals(id)) {
                    brojMjesta = k.brojMjesta;
                    raspolozivost = k.raspolozivostVozila;
                    foreach (Vozilo v in k.listaVozila) {
                        if (!v.ispravno) {
                            brojNeispravnih++;
                        }
                    }

                }
            }
            stanja.Add("brojMjesta", brojMjesta);
            stanja.Add("raspolozivost", raspolozivost);
            stanja.Add("brojNeispravnih", brojNeispravnih);
            return stanja;
        }

        public List<OrganizationComponent> dohvatiKomponente() {
            return components;
        }

    }
}
