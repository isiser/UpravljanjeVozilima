using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using isiser_zadaca_3.modeli;

namespace isiser_zadaca_3.stvaranjeAktivnosti
{
    class AktivnostBuilderImpl : AktivnostBuilder
    {
        private Aktivnost aktivnost;

       

        public AktivnostBuilder setBrojKm(String brojKm)
        {
            aktivnost.brojKm = int.Parse(brojKm);
            return this;
        } public AktivnostBuilderImpl()
        {
            aktivnost = new Aktivnost();
        }

        public Aktivnost build()
        {
            return aktivnost;
        }

        public AktivnostBuilder setIdAktivnosti(int id)
        {
            aktivnost.id = id;
            return this;
        }

        public AktivnostBuilder setIdKorisnika(String idKorisnika)
        {
            aktivnost.idKorisnika = int.Parse(idKorisnika);
            return this;
        }

        public AktivnostBuilder setIdLokacije(String idLokacije)
        {
            aktivnost.idLokacije = int.Parse(idLokacije);
            return this;
        }

        public AktivnostBuilder setIdVozila(String idVozila)
        {
            aktivnost.idVozila = int.Parse(idVozila);
            return this;
        }

        public AktivnostBuilder setVrijeme(String vrijeme)
        {
            aktivnost.vrijeme = DateTime.ParseExact(vrijeme.Substring(1, vrijeme.Length - 2), "yyyy-MM-dd HH:mm:ss", null);
            return this;
        }

        public AktivnostBuilder setProblemKvara(string problemKvara)
        {
            aktivnost.problemKvara = problemKvara;
            return this;
        }

        public AktivnostBuilder setDatoteka(string datoteka)
        {
            aktivnost.datoteka = datoteka;
            return this;
        }

        public AktivnostBuilder setStruktura(bool struktura)
        {
            aktivnost.struktura = struktura;
            return this;
        }

        public AktivnostBuilder setStanje(bool stanje)
        {
            aktivnost.stanje = stanje;
            return this;
        }

        public AktivnostBuilder setOrgJedinicaID(int jedID)
        {
            aktivnost.orgJedinicaID = jedID;
            return this;
        }

        public AktivnostBuilder setNajam(bool najam)
        {
            aktivnost.najam = najam;
            return this;
        }

        public AktivnostBuilder setZarada(bool zarada)
        {
            aktivnost.zarada = zarada;
            return this;
        }

        public AktivnostBuilder setDatumOd(string datumOd)
        {
            try
            {
                DateTime datumKonvertOd = DateTime.ParseExact(datumOd, "dd.MM.yyyy", null);
                aktivnost.datumOd = datumKonvertOd;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Datum nije unesen u ispravnom formatu!");
                Console.ResetColor();
            }
            return this;
        }

        public AktivnostBuilder setDatumDo(string datumDo)
        {
            try
            {
                DateTime datumKonvertDo = DateTime.ParseExact(datumDo, "dd.MM.yyyy", null);
                aktivnost.datumDo = datumKonvertDo;
            }
            catch (Exception e) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Datum nije unesen u ispravnom formatu!");
                Console.ResetColor();
            }
            return this;
        }

        public AktivnostBuilder setUplata(double uplata)
        {
            aktivnost.uplata = uplata;
            return this;
        }
    }
}
