using isiser_zadaca_3.modeli;
using System;
using System.Collections.Generic;
using System.Text;

namespace isiser_zadaca_3.izdavanjeRacuna
{
    interface Subscriber
    {
        void Update(List<Racun> listaRacuna);
    }
}
