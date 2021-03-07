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
    public class CitanjeKonfiguracije : ICitanje
    {
        public void Procitaj(String putanja)
        {
            int counter = 0;
            String line;
            StreamReader file = new StreamReader(putanja);
            while ((line = file.ReadLine()) != null)
            {
                String[] data = line.Split(new string[] { "=" }, StringSplitOptions.None);
                BazaPodataka.getInstance().postaviKonfiguraciju(data[0], data[1]);
                counter++;
            }
            file.Close();
            
        }
    }
}
