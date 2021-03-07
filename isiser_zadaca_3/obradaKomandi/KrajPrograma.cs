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
    public class KrajPrograma : IObrada
    {
        public void ObradiKomandu(Aktivnost aktivnost)
        {
            VirtualnoVrijeme.getInstance().postaviZavrsetak(true);
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("U " + aktivnost.vrijeme.ToString("yyyy-MM-dd HH:mm:ss") + " program zavrsava s radom.");
            Console.WriteLine("---------------------------------------");
        }
    }
}
