using isiser_zadaca_3.modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3.stvaranjeAktivnosti
{
    interface AktivnostBuilder
    {
        Aktivnost build();

        AktivnostBuilder setIdAktivnosti(int id);

        AktivnostBuilder setVrijeme(String vrijeme);

        AktivnostBuilder setIdKorisnika(String idKorisnika);

        AktivnostBuilder setIdLokacije(String idLokacije);

        AktivnostBuilder setIdVozila(String idVozila);

        AktivnostBuilder setBrojKm(String brojKm);

        AktivnostBuilder setProblemKvara(String problemKvara);

        AktivnostBuilder setDatoteka(String datoteka);

        AktivnostBuilder setStruktura(bool struktura);

        AktivnostBuilder setStanje(bool stanje);

        AktivnostBuilder setOrgJedinicaID(int jedID);

        AktivnostBuilder setNajam(bool najam);

        AktivnostBuilder setZarada(bool zarada);

        AktivnostBuilder setDatumOd(String datumOd);

        AktivnostBuilder setDatumDo(String datumDo);

        AktivnostBuilder setUplata(double uplata);
    }
}
