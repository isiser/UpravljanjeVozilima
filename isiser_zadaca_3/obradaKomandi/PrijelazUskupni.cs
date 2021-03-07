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
    public class PrijelazUskupni : IObrada
    {
        public void ObradiKomandu(Aktivnost aktivnost)
        {
            CitanjeCreator creator;
            creator = new CreatorAktivnosti();
            creator.procitaj(aktivnost.datoteka);
        }
    }
}
