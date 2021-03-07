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
    public class IspisStanje : IObrada
    {
        public void ObradiKomandu(Aktivnost aktivnost)
        {
            IHandler handler1 = new Struktura();
            IHandler handler2 = new Stanje();
            IHandler handler3 = new Zarada();

            handler1.SetNext(handler2);
            handler2.SetNext(handler3);
            handler1.Handle(aktivnost);

        }
    }
}
