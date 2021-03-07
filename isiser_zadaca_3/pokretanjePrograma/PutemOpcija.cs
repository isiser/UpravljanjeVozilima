using isiser_zadaca_3.postavkeApp;
using isiser_zadaca_3.strukturaOrganizacije;
using isiser_zadaca_3.ucitavanjeDatoteka;
using System;
using System.Collections.Generic;
using System.Text;

namespace isiser_zadaca_3.pokretanjePrograma
{
    class PutemOpcija : NacinIzvrsavanja
    {
        public override void Izvrsavanje(string[] args)
        {
            CitanjeCreator creator;
            foreach (String argument in args)
            {
                switch (argument)
                {
                    case "-v":
                        creator = new CreatorVozila();
                        creator.procitaj(args[Array.IndexOf(args, argument) + 1]);
                        break;
                    case "-c":
                        creator = new CreatorCjenika();
                        creator.procitaj(args[Array.IndexOf(args, argument) + 1]);
                        break;
                    case "-o":
                        creator = new CreatorOsoba();
                        creator.procitaj(args[Array.IndexOf(args, argument) + 1]);
                        break;
                    case "-l":
                        creator = new CreatorLokacija();
                        creator.procitaj(args[Array.IndexOf(args, argument) + 1]);
                        break;
                    case "-k":
                        creator = new CreatorKapaciteta();
                        creator.procitaj(args[Array.IndexOf(args, argument) + 1]);
                        break;
                    case "-t":
                        VirtualnoVrijeme.getInstance().postaviVrijeme(args[Array.IndexOf(args, argument) + 1] + " " + args[Array.IndexOf(args, argument) + 2]);
                        break;
                    case "-s":
                        BazaPodataka.getInstance().postaviNacinRada(true);
                        creator = new CreatorAktivnosti();
                        creator.procitaj(args[Array.IndexOf(args, argument) + 1]);
                        break;
                    case "-os":
                        creator = new CreatorTvrtki();
                        creator.procitaj(args[Array.IndexOf(args, argument) + 1]);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
