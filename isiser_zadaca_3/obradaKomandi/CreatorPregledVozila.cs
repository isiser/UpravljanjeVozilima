using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3.ucitavanjeDatoteka
{
    public class CreatorPregledVozila: ObradaCreator
    {
        public override IObrada factoryMethod()
        {
            return new PregledVozila();
        }
    }
}
