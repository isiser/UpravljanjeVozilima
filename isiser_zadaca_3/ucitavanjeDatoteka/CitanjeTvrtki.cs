using isiser_zadaca_3.modeli;
using isiser_zadaca_3.postavkeApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3.ucitavanjeDatoteka
{
    public class CitanjeTvrtki : ICitanje
    {
        public void Procitaj(String putanja)
        {
            int counter = 0;
            try
            {
                String line;
                StreamReader file = new StreamReader(putanja);
                while ((line = file.ReadLine()) != null)
                {
                    if (counter != 0)
                    {
                        String[] data = line.Trim().Split(new string[] { ";" }, StringSplitOptions.None);


                        Tvrtka tvrtka = new Tvrtka(int.Parse(data[0]), data[1], dohvatiNadredenog(data[2]), dohvatiLokacije(data[3]));
                        BazaPodataka.getInstance().postaviTvrtku(tvrtka);
                    }
                    counter++;
                }
                file.Close();
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("U liniji [" + counter + "] datoteke Cjenika ne valja format argumenta!");
                Console.ResetColor();
            }
        }

        private List<int> dohvatiLokacije(String l)
        {
            if (l.Equals(""))
            {
                return new List<int>();
            }
            else {
                List<int> listaLokacija = new List<int>();
                String[] lokacije = l.Split(new string[] { "," }, StringSplitOptions.None);
                foreach (String lokacija in lokacije)
                {
                    listaLokacija.Add(int.Parse(lokacija));
                }
                return listaLokacija;
            }

            
        }

        private int dohvatiNadredenog(String n) {
            if (n.Equals(" "))
                return 00;
            else
                return int.Parse(n);
        }
    }

   
}
