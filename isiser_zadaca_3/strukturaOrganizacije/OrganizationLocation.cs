using System;
using System.Collections.Generic;
using System.Text;

namespace isiser_zadaca_3.strukturaOrganizacije
{
    class OrganizationLocation : OrganizationComponent
    {
        public int locationID { get; set; }
        public String locationName { get; set; }
        public String locationAdress { get; set; }
        public String locationGPS { get; set; }
        public double zarada { get; set; }
        public int brojMjesta { get; set; }
        public int brojRaspolozivih { get; set; }
        public int brojNeispravnih { get; set; }

        public OrganizationLocation(int locationID, string locationName, string locationAdress, string locationGPS, double zarada, int brojMjesta, int brojRaspolozivih, int brojNeispravnih)
        {
            this.zarada = zarada;
            this.locationID = locationID;
            this.locationName = locationName;
            this.locationAdress = locationAdress;
            this.locationGPS = locationGPS;
            this.brojMjesta = brojMjesta;
            this.brojRaspolozivih = brojRaspolozivih;
            this.brojNeispravnih = brojNeispravnih;
        }

        public override bool IsComposite()
        {
            return false;
        }

        public override void displayOrganizationInfo()
        {
            Console.WriteLine(String.Format($"|{{0,5}}|{{1,-30}}|", locationID.ToString(), locationName));
        }

        public override int getLocationID()
        {
            return this.locationID;
        }

        public override String getLocationName()
        {
            return this.locationName;
        }

        public override double getZarada()
        {
            return this.zarada;
        }

        public override int getBrojMjesta()
        {
            return this.brojMjesta;
        }

        public override int getBrojRaspolozivih()
        {
            return this.brojRaspolozivih;
        }

        public override int getBrojNeispravnih()
        {
            return this.brojNeispravnih;
        }

    }
}
