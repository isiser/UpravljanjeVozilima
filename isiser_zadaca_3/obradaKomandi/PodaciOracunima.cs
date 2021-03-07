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
    public class PodaciOracunima : IObrada
    {
        public void ObradiKomandu(Aktivnost aktivnost)
        {
            Console.WriteLine();
            List<Racun> listaRacuna = BazaPodataka.getInstance().publisher.vratiListuRacuna().OrderBy(x => x.datumRacuna).ToList();
            Console.WriteLine(listaRacuna.Count);
            List<Racun> placeniRacuni = listaRacuna.Where(x => x.placeno == true && x.osoba.id == aktivnost.idKorisnika && x.datumRacuna >= aktivnost.datumOd && x.datumRacuna <= aktivnost.datumDo).ToList();
            List<Racun> nePlaceniRacuni = listaRacuna.Where(x => x.placeno == false && x.osoba.id == aktivnost.idKorisnika && x.datumRacuna >= aktivnost.datumOd && x.datumRacuna <= aktivnost.datumDo).ToList();
            Console.WriteLine("Plaćeni računi:");
            Console.WriteLine(placeniRacuni.Count);
            if (placeniRacuni.Any<Racun>())
            {
                Console.WriteLine(String.Format($"|{{0,5}}|{{1,5}}|{{2,-30}}|{{3,-30}}|{{4,-30}}|{{5,-30}}|", "ID", "Iznos", "Datum računa", "Plaćeno", "Tip vozila", "Lokacija najma"));
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                foreach (Racun r in placeniRacuni)
                {
                    Console.WriteLine(String.Format($"|{{0,5}}|{{1,5}}|{{2,-30}}|{{3,-30}}|{{4,-30}}|{{5,-30}}|", r.id , r.iznos, r.datumRacuna.ToString("yyyy-MM-dd HH:mm:ss"), r.placeno ? "Da" : "Ne", r.tipVozila.Naziv, r.najam.lokacijaNajma.naziv));
                }
            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nema plaćenih računa!");
                Console.ResetColor();
            }
            Console.WriteLine("Neplaćeni računi:");
            Console.WriteLine(nePlaceniRacuni.Count);
            if (nePlaceniRacuni.Any<Racun>())
            {
                Console.WriteLine(String.Format($"|{{0,5}}|{{1,5}}|{{2,-30}}|{{3,-30}}|{{4,-30}}|{{5,-30}}|", "ID", "Iznos", "Datum računa", "Plaćeno", "Tip vozila", "Lokacija najma"));
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                foreach (Racun r in nePlaceniRacuni)
                {
                    Console.WriteLine(String.Format($"|{{0,5}}|{{1,5}}|{{2,-30}}|{{3,-30}}|{{4,-30}}|{{5,-30}}|", r.id, r.iznos, r.datumRacuna.ToString("yyyy-MM-dd HH:mm:ss"), r.placeno ? "Da" : "Ne", r.tipVozila.Naziv, r.najam.lokacijaNajma.naziv));
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nema neplaćenih računa!");
                Console.ResetColor();
            }
        }

    }
}
