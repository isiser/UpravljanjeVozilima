using isiser_zadaca_3.strukturaOrganizacije;
using System;
using System.Collections.Generic;
using System.Text;

namespace isiser_zadaca_3.strukturaOrganizacije
{
    class OrganizationUnit : OrganizationComponent
    {
        public List<OrganizationComponent> childrenComponents = new List<OrganizationComponent>();

        public int unitID { get; set; }
        public String unitName { get; set; }

        public OrganizationUnit(int unitID, string unitName)
        {
            this.unitID = unitID;
            this.unitName = unitName;
        }

        public override void Add(OrganizationComponent newOrgComponent) {
            childrenComponents.Add(newOrgComponent);
        }

        public override void Remove(OrganizationComponent newOrgComponent)
        {
            childrenComponents.Remove(newOrgComponent);
        }

        public override void displayOrganizationInfo()
        {
            Console.WriteLine(String.Format($"|{{0,5}}|{{1,-30}}|", unitID.ToString(), unitName));

            foreach (OrganizationComponent k in childrenComponents) {
                    k.displayOrganizationInfo();
            }

        }

        public override int getUnitID()
        {
            return unitID;
        }

        public override string getUnitName()
        {
            return unitName;
        }

        public override List<OrganizationComponent> getChildren()
        {
            return this.childrenComponents;
        }

        public override double getZarada()
        {
            double zarada = 0;
            foreach (OrganizationComponent orgc in childrenComponents) {
                    zarada += orgc.getZarada();
            }
            return zarada;
        }

        public override int getBrojMjesta()
        {
            int brMjesta = 0;
            foreach (OrganizationComponent orgc in childrenComponents)
            {
                brMjesta += orgc.getBrojMjesta();
            }
            return brMjesta;
        }

        public override int getBrojRaspolozivih()
        {
            int brRaspolozivih = 0;
            foreach (OrganizationComponent orgc in childrenComponents)
            {
                brRaspolozivih += orgc.getBrojRaspolozivih();
            }
            return brRaspolozivih;
        }

        public override int getBrojNeispravnih()
        {
            int brNeispravnih = 0;
            foreach (OrganizationComponent orgc in childrenComponents)
            {
                brNeispravnih += orgc.getBrojNeispravnih();
            }
            return brNeispravnih;
        }
    }
}
