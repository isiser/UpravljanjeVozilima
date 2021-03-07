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
    public class CitanjeKapaciteta : ICitanje
    {
        public void Procitaj(String putanja)
        {
            int counter = 0;
            try
            {
                String line;
                Vozilo vozilo = new Vozilo();
                StreamReader file = new StreamReader(putanja);
                while ((line = file.ReadLine()) != null)
                {
                    if (counter != 0)
                    {
                        String[] data = line.Split(new string[] { "; " }, StringSplitOptions.None);
                        Kapacitet kapacitet = new Kapacitet(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2]), int.Parse(data[3]));

                        for (int i = 1; i <= kapacitet.raspolozivostVozila; i++)
                        {
                            kapacitet.dodajVozilo(vozilo.Clone(kapacitet.voziloId));
                        }
                        BazaPodataka.getInstance().postaviKapacitet(kapacitet);
                    }
                    counter++;
                }
                file.Close();
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("U liniji [" + counter + "] datoteke Kapaciteta ne valja format argumenta!");
                Console.ResetColor();
            }
        }
    }
}
