using System;
using System.Collections.Generic;
using System.Text;

namespace isiser_zadaca_3.strukturaOrganizacije
{
    abstract class OrganizationComponent
    {
        public virtual void Add(OrganizationComponent newOrgComponent) {
            throw new NotImplementedException();
        }

        public virtual void Remove(OrganizationComponent newOrgComponent) {
            throw new NotImplementedException();
        }

        public virtual OrganizationComponent GetComponent(int componentIndex)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsComposite()
        {
            return true;
        }

        public virtual int getUnitID() {
            throw new NotImplementedException();
        }

        public virtual String getUnitName()
        {
            throw new NotImplementedException();
        }

        public virtual int getLocationID()
        {
            throw new NotImplementedException();
        }

        public virtual String getLocationName()
        {
            throw new NotImplementedException();
        }

        public virtual int getLocationAdress()
        {
            throw new NotImplementedException();
        }

        public virtual int getLocationGPS()
        {
            throw new NotImplementedException();
        }

        public virtual void displayOrganizationInfo()
        {
            throw new NotImplementedException();
        }

        public virtual List<OrganizationComponent> getChildren()
        {
            throw new NotImplementedException();
        }

        public virtual double getZarada() {
            throw new NotImplementedException();
        }

        public virtual int getBrojMjesta() {
            throw new NotImplementedException();
        }

        public virtual int getBrojRaspolozivih()
        {
            throw new NotImplementedException();
        }

        public virtual int getBrojNeispravnih()
        {
            throw new NotImplementedException();
        }







    }
}
