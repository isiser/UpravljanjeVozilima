using isiser_zadaca_3.modeli;
using System;
using System.Collections.Generic;
using System.Text;

namespace isiser_zadaca_3.izdavanjeRacuna
{
    class Publisher
    {
        public List<Subscriber> subscribers { get; set; }
        public List<Racun> listaRacuna { get; set; }

        public Publisher()
        {
            this.subscribers = new List<Subscriber>();
            this.listaRacuna = new List<Racun>();
        }

        public void Subscribe(Subscriber s) {
            subscribers.Add(s);
        }

        public void UnSubscribe(Subscriber s)
        {
            subscribers.Remove(s);
        }

        public void NotifySubscribers()
        {
            foreach (Subscriber s in subscribers) {
                s.Update(listaRacuna);
            }
        }

        public void dohvatiRacun(Racun racun) {
            listaRacuna.Add(racun);
            this.NotifySubscribers();
        }

        public List<Racun> vratiListuRacuna() {
            return listaRacuna;
        }

    }
}
