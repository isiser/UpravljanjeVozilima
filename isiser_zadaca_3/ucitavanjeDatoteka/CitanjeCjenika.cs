using isiser_zadaca_3.postavkeApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3.ucitavanjeDatoteka
{
    public class CitanjeCjenika : ICitanje
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
                        String[] data = line.Split(new string[] { "; " }, StringSplitOptions.None);
                        Cjenik cjenik = new Cjenik(int.Parse(data[0]), double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3]));
                        BazaPodataka.getInstance().postaviCjenik(cjenik);
                    }
                    counter++;
                }
                file.Close();
            }
            catch (FormatException ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("U liniji [" + counter + "] datoteke Cjenika ne valja format argumenta!");
                Console.ResetColor();
            } 
            
        }
    }
}
