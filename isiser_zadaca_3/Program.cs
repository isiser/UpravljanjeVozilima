using isiser_zadaca_3.modeli;
using isiser_zadaca_3.pokretanjePrograma;
using isiser_zadaca_3.postavkeApp;
using isiser_zadaca_3.strukturaOrganizacije;
using isiser_zadaca_3.stvaranjeAktivnosti;
using isiser_zadaca_3.ucitavanjeDatoteka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.nacinPokretanja(args);

            AktivnostBuilder builder = new AktivnostBuilderImpl();
            AktivnostBuildDirector aktivnostBuildDirector = new AktivnostBuildDirector(builder);

            while (!VirtualnoVrijeme.getInstance().dohvatiZavrsetak())
            {
                if (BazaPodataka.getInstance().dohvatiNacinRada())
                {
                    List<Aktivnost> listaAktivnosti = BazaPodataka.getInstance().dohvatiAktivnosti();
                    foreach (Aktivnost a in listaAktivnosti)
                    {
                        program.obradiKomandu(a);
                    }
                    if (listaAktivnosti.Last().id != 0) {
                        BazaPodataka.getInstance().postaviNacinRada(false);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Unesi komandu za odabranu aktivnost:");
                    String komanda = Console.ReadLine();
                    Aktivnost aktivnost = aktivnostBuildDirector.construct(komanda, 0);
                    program.obradiKomandu(aktivnost);

                }
            }
            Console.ReadLine();
        }

        private void nacinPokretanja(string[] args)
        {
            NacinIzvrsavanja izvrsavanje;
            if (args.Length.Equals(1))
            {
               izvrsavanje = new PutemKonfiguracija();
               izvrsavanje.Izvrsavanje(args);
            }
            else
            {
                izvrsavanje = new PutemOpcija();
                izvrsavanje.Izvrsavanje(args);
            }
        }

        public void obradiKomandu(Aktivnost aktivnost) {
            if (aktivnost.id.Equals(5))
            {
                BazaPodataka.getInstance().postaviNacinRada(true);
                ObradaCreator creator;
                creator = new CreatorPrijelazUskupni();
                creator.obradiKomandu(aktivnost);
            }
            else if (aktivnost.id.Equals(6))
            {
                ObradaCreator creator;
                creator = new CreatorIspisStanje();
                creator.obradiKomandu(aktivnost);
            }
            else if (aktivnost.id.Equals(7))
            {
                ObradaCreator creator;
                creator = new CreatorIspisStanje();
                creator.obradiKomandu(aktivnost);
            }
            else if (aktivnost.id.Equals(9)) {
                ObradaCreator creator;
                creator = new CreatorFinancijskoStanje();
                creator.obradiKomandu(aktivnost);
            }
            else if (aktivnost.id.Equals(10))
            {
                ObradaCreator creator;
                creator = new CreatorPodaciOracunima();
                creator.obradiKomandu(aktivnost);
            }
            else if (aktivnost.id.Equals(11))
            {
                ObradaCreator creator;
                creator = new CreatorPlacanjeDuga();
                creator.obradiKomandu(aktivnost);
            }
            else
            {
                if (VirtualnoVrijeme.getInstance().dohvatiVrijemeTrenutno() < aktivnost.vrijeme)
                {
                    if (BazaPodataka.getInstance().listaNajmova.Any())
                    {
                        foreach (Kapacitet k in BazaPodataka.getInstance().listaKapaciteta)
                        {
                            foreach (Vozilo ve in k.listaVozila)
                            {
                                if (ve.kapacitetBaterije < 100)
                                {
                                    VoziloTip voziloTip = pronadiVozilo(ve.tipVozila);
                                    Najam najam = pronadiNajam(ve);
                                    ve.PuniBateriju(voziloTip, najam, aktivnost);
                                }
                            }
                        }
                    }
                    VirtualnoVrijeme.getInstance().postaviVrijeme("\"" + aktivnost.vrijeme.ToString("yyyy-MM-dd HH:mm:ss") + "\"");
                    ObradaCreator creator;
                    switch (aktivnost.id)
                    {
                        case 0:
                            creator = new CreatorKrajPrograma();
                            creator.obradiKomandu(aktivnost);
                            break;
                        case 1:
                            creator = new CreatorPregledVozila();
                            creator.obradiKomandu(aktivnost);
                            break;
                        case 2:
                            creator = new CreatorNajamVozila();
                            creator.obradiKomandu(aktivnost);
                            break;
                        case 3:
                            creator = new CreatorPregledRasMjesta();
                            creator.obradiKomandu(aktivnost);
                            break;
                        case 4:
                            if (aktivnost.problemKvara != null)
                                creator = new CreatorVracanjeNeispravnog();
                            else
                                creator = new CreatorVracanjeVozila();
                            creator.obradiKomandu(aktivnost);
                            break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Trenutno vrijeme sustava (" + VirtualnoVrijeme.getInstance().dohvatiVrijemeTrenutno().ToString("yyyy-MM-dd HH:mm:ss") +
                        ") je vece od vremena trazene aktivnosti.");
                    Console.ResetColor();
                }
            }
            
            
        }

        private VoziloTip pronadiVozilo(int id)
        {
            VoziloTip vozilo = null;
            foreach (VoziloTip v in BazaPodataka.getInstance().dohvatiVozila())
            {
                if (id.Equals(v.Id))
                    vozilo = v;
            }
            return vozilo;
        }

        private Najam pronadiNajam(Vozilo ve)
        {
            Najam najam = null;
            foreach (Najam n in BazaPodataka.getInstance().dohvatiNajmove())
            {
                if (n.vozilo.brojKm.Equals(ve.brojKm) && n.vozilo.kapacitetBaterije.Equals(ve.kapacitetBaterije) && n.vozilo.tipVozila.Equals(ve.tipVozila))
                    najam = n;
            }
            return najam;
        }

    }
}
