using isiser_zadaca_3.modeli;
using isiser_zadaca_3.strukturaOrganizacije;
using System;
using System.Collections.Generic;
using System.Text;

namespace isiser_zadaca_3.ispisPodatakaOrganizacije
{
    class Zarada : IHandler
    {
        private IHandler nextHandler;
        public void Handle(object request)
        {
            if ((request as Aktivnost).id == 7 && (request as Aktivnost).struktura == true && (request as Aktivnost).zarada == true && (request as Aktivnost).orgJedinicaID == 0)
            {
                Console.WriteLine();
                TreeStructure tree = new TreeStructure();
                tree.CreateTree();
                List<OrganizationComponent> listaKomponenti = tree.dohvatiKomponente();
                foreach (OrganizationComponent item in listaKomponenti)
                {
                    Console.WriteLine(String.Format($"|{{0,5}}|{{1,-30}}|{{2,5}}|",
                        item.getUnitID().ToString(), item.getUnitName(), item.getZarada()));
                    foreach (OrganizationComponent l in item.getChildren())
                    {
                        if (l is OrganizationLocation)
                            Console.WriteLine(String.Format($"|{{0,5}}|{{1,-30}}|{{2,5}}|",
                        l.getLocationID().ToString(), l.getLocationName(), l.getZarada()));
                    }

                }
            }
            else
            {
                //nextHandler.Handle(request);
            }
        }

        public void SetNext(IHandler handler)
        {
            this.nextHandler = handler;
        }
    }
}
