using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3.ucitavanjeDatoteka
{
    public abstract class CitanjeCreator
    {
        private ICitanje citanje;

        public abstract ICitanje factoryMethod();

        public void procitaj(String putanja) {
            citanje = factoryMethod();
            citanje.Procitaj(putanja);
        }
    }
}
