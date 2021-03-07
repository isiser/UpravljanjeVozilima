using isiser_zadaca_3.modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3.ucitavanjeDatoteka
{
    public abstract class ObradaCreator
    {
        private IObrada obrada;

        public abstract IObrada factoryMethod();

        public void obradiKomandu(Aktivnost aktivnost) {
            obrada = factoryMethod();
            obrada.ObradiKomandu(aktivnost);
        }
    }
}
