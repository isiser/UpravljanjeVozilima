using isiser_zadaca_3.modeli;
using isiser_zadaca_3.postavkeApp;
using isiser_zadaca_3.strukturaOrganizacije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace isiser_zadaca_3.ispisPodatakaOrganizacije
{
    class Stanje : IHandler
    {
        private IHandler nextHandler;
        public void Handle(object request)
        {
            if ((request as Aktivnost).id == 6 && (request as Aktivnost).zarada == false && (request as Aktivnost).struktura == true && (request as Aktivnost).stanje == true && (request as Aktivnost).orgJedinicaID == 0)
            {
                TreeStructure tree = new TreeStructure();
                tree.CreateTree();
                List<OrganizationComponent> listaKomponenti = tree.dohvatiKomponente();
                foreach (OrganizationComponent item in listaKomponenti) {
                    Console.WriteLine(String.Format($"|{{0,-30}}|{{1,-30}}|{{2,5}}|{{3,5}}|{{4,5}}|",
                        item.getUnitID().ToString(), item.getUnitName(), item.getBrojMjesta().ToString(),
                        item.getBrojRaspolozivih().ToString(), item.getBrojNeispravnih().ToString()));
                    foreach(OrganizationComponent l in item.getChildren())
                    {
                        if(l is OrganizationLocation)
                            Console.WriteLine(String.Format($"|{{0,-30}}|{{1,-30}}|{{2,5}}|{{3,5}}|{{4,5}}|",
                        l.getLocationID().ToString(), l.getLocationName(), l.getBrojMjesta().ToString(),
                        l.getBrojRaspolozivih().ToString(), l.getBrojNeispravnih().ToString()));
                    }
                        
                }
            }
            else
            {
                nextHandler.Handle(request);
            }
        }

        public void SetNext(IHandler handler)
        {
            this.nextHandler = handler;
        }

    }
}
