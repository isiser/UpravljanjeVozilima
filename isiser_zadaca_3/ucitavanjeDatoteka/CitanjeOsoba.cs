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
    public class CitanjeOsoba : ICitanje
    {
        public void Procitaj(String putanja)
        {
            int counter = 0;
                String line;
                StreamReader file = new StreamReader(putanja);
                while ((line = file.ReadLine()) != null)
                {
                    if (counter != 0)
                    {
                        try
                        {
                        String[] data = line.Split(new string[] { "; " }, StringSplitOptions.None);
                        Osoba osoba = new Osoba(int.Parse(data[0]), data[1], int.Parse(data[2]));
                        BazaPodataka.getInstance().postaviOsobu(osoba);
                    }
                    catch (FormatException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("U liniji [" + counter + "] datoteke Osoba ne valja format argumenta!");
                        Console.ResetColor();
                    }
                    catch (IndexOutOfRangeException ex2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("U liniji [" + counter + "] datoteke Osoba ne valja format argumenta!");
                        Console.ResetColor();
                    }
                }
                    counter++;
                }
                file.Close();
            
        }
    }
}
