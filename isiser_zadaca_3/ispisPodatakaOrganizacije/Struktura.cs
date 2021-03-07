using isiser_zadaca_3.modeli;
using isiser_zadaca_3.strukturaOrganizacije;
using System;
using System.Collections.Generic;
using System.Text;

namespace isiser_zadaca_3.ispisPodatakaOrganizacije
{
    class Struktura : IHandler
    {
        private IHandler nextHandler;
        public void Handle(object request)
        {
            if ((request as Aktivnost).zarada == false && (request as Aktivnost).najam == false && (request as Aktivnost).struktura == true && (request as Aktivnost).stanje == false && (request as Aktivnost).orgJedinicaID == 0)
            {
                TreeStructure tree = new TreeStructure();
                tree.CreateTree();
                tree.DisplayTree();
            }
            else if ((request as Aktivnost).zarada == false && (request as Aktivnost).najam == false && (request as Aktivnost).struktura == true && (request as Aktivnost).stanje == false && (request as Aktivnost).orgJedinicaID != 0) {
                TreeStructure tree = new TreeStructure();
                tree.CreateTree();
                List<OrganizationComponent> listaKomponenti = tree.dohvatiKomponente();
                foreach (OrganizationComponent item in listaKomponenti)
                {
                    if (item.getUnitID() == (request as Aktivnost).orgJedinicaID) {
                        item.displayOrganizationInfo();
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
