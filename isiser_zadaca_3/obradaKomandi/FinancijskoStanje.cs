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
    public class FinancijskoStanje : IObrada
    {
        public void ObradiKomandu(Aktivnost aktivnost)
        {
            Console.WriteLine();
            List<Racun> listaRacuna = BazaPodataka.getInstance().publisher.vratiListuRacuna().OrderBy(x => x.datumRacuna).ToList();
            if (listaRacuna.Any<Racun>())
            {
                Console.WriteLine(String.Format($"|{{0,5}}|{{1,-30}}|{{2,-30}}|{{3,-30}}|", "ID", "Ime i prezime", "Stanje dugovanja", "Vrijeme zadnjeg najma"));
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                foreach (Racun r in listaRacuna)
                {
                    Console.WriteLine(String.Format($"|{{0,5}}|{{1,-30}}|{{2,-30}}|{{3,-30}}|", r.osoba.id.ToString(), r.osoba.imePrezime, r.osoba.dugovanje.ToString(), r.datumRacuna.ToString("yyyy-MM-dd HH:mm:ss")));
                }
            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Niti jedan korisnik nije imao najam vozila!");
                Console.ResetColor();
            }
        }

    }
}
