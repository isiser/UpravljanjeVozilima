using isiser_zadaca_3.postavkeApp;
using isiser_zadaca_3.strukturaOrganizacije;
using isiser_zadaca_3.ucitavanjeDatoteka;
using System;
using System.Collections.Generic;
using System.Text;

namespace isiser_zadaca_3.pokretanjePrograma
{
    class PutemKonfiguracija : NacinIzvrsavanja
    {

        public override void Izvrsavanje(string[] args)
        {
            procitajKonfiguracije(args[0]);
            CitanjeCreator creator;
            foreach (var konfig in BazaPodataka.getInstance().dohvatiKonfiguracije())
            {
                switch (konfig.Key)
                {
                    case "vozila":
                        creator = new CreatorVozila();
                        creator.procitaj(konfig.Value);
                        break;
                    case "cjenik":
                        creator = new CreatorCjenika();
                        creator.procitaj(konfig.Value);
                        break;
                    case "osobe":
                        creator = new CreatorOsoba();
                        creator.procitaj(konfig.Value);
                        break;
                    case "lokacije":
                        creator = new CreatorLokacija();
                        creator.procitaj(konfig.Value);
                        break;
                    case "kapaciteti":
                        creator = new CreatorKapaciteta();
                        creator.procitaj(konfig.Value);
                        break;
                    case "vrijeme":
                        VirtualnoVrijeme.getInstance().postaviVrijemeKonfig(konfig.Value);
                        break;
                    case "aktivnosti":
                        BazaPodataka.getInstance().postaviNacinRada(true);
                        creator = new CreatorAktivnosti();
                        creator.procitaj(konfig.Value);
                        break;
                    case "struktura":
                        creator = new CreatorTvrtki();
                        creator.procitaj(konfig.Value);
                        break;
                    case "dugovanje":
                        BazaPodataka.getInstance().postaviLimit(Double.Parse(konfig.Value));
                        break;
                    default:
                        break;
                }
            }
        }

        private void procitajKonfiguracije(String putanja)
        {
            CitanjeCreator creator = new CreatorKonfiguracije();
            creator.procitaj(putanja);
        }
    }
}
