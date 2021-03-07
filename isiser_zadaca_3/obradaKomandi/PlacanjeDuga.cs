using isiser_zadaca_3.ispisPodatakaOrganizacije;
using isiser_zadaca_3.modeli;
using isiser_zadaca_3.postavkeApp;
using isiser_zadaca_3.strukturaOrganizacije;
using isiser_zadaca_3.stvaranjeAktivnosti;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3.ucitavanjeDatoteka
{
    public class PlacanjeDuga : IObrada
    {
        public void ObradiKomandu(Aktivnost aktivnost)
        {
            Console.WriteLine();
            List<Racun> listaRacuna = BazaPodataka.getInstance().publisher.vratiListuRacuna().OrderBy(x => x.datumRacuna).ToList();
            List<Racun> listaRacunaKor = listaRacuna.Where(x => x.osoba.id == aktivnost.idKorisnika && x.placeno == false).ToList();
            double uplata = aktivnost.uplata;
            if (listaRacunaKor.Any<Racun>())
            {
                Console.WriteLine("Podmireni računi:");
                Console.WriteLine(String.Format($"|{{0,5}}|{{1,-30}}|{{2,5}}|", "Broj", "Datum računa", "Iznos"));
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
                foreach (Racun r in listaRacunaKor)
                {
                    if (r.iznos <= uplata)
                    {
                        r.placeno = true;
                        uplata -= r.iznos;
                        r.osoba.dugovanje -= r.iznos;
                        Console.WriteLine(String.Format($"|{{0,5}}|{{1,-30}}|{{2,5}}|", r.id, r.datumRacuna.ToString("yyyy-MM-dd HH:mm:ss"), r.iznos));
                    }
                }
                Console.WriteLine("Korisniku se vraća ostatak novaca od uplate: " + uplata + " kn");
            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Korisnik nema niti jedan račun!");
                Console.ResetColor();
            }
        }

    }
}
