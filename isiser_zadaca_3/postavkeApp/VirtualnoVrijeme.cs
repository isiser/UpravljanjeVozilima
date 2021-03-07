using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isiser_zadaca_3.postavkeApp
{
    class VirtualnoVrijeme
    {
        public DateTime trenutnoVrijeme;
        //true- prestaje s radom, false - dalje radi
        public Boolean zavrsetakFlag = false;

        private static VirtualnoVrijeme INSTANCE;

        public VirtualnoVrijeme()
        {

        }

        public static VirtualnoVrijeme getInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new VirtualnoVrijeme();
            }
            return INSTANCE;
        }

        public void postaviVrijeme(String vrijeme)
        {
            trenutnoVrijeme = DateTime.ParseExact(vrijeme.Substring(1, vrijeme.Length - 2), "yyyy-MM-dd HH:mm:ss", null);
        }

        public void postaviVrijemeKonfig(String vrijeme)
        {
            trenutnoVrijeme = DateTime.ParseExact(vrijeme, "yyyy-MM-dd HH:mm:ss", null);
        }

        public DateTime dohvatiVrijemeTrenutno()
        {
            return trenutnoVrijeme;
        }

        public void postaviZavrsetak(Boolean kraj)
        {
            zavrsetakFlag = true;
        }

        public Boolean dohvatiZavrsetak()
        {
            return zavrsetakFlag;
        }
    }
}
