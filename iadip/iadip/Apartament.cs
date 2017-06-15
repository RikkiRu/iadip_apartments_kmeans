using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iadip
{
    class Apartament
    {
        public ClusterData Data;
        public int Id;
        public string City;
        public string Company;

        public override string ToString()
        {
            return string.Format("Apartament {0}", Data.ToString());
        }

        public Apartament() {
            Data = new ClusterData();
        }

        public Apartament(Apartament apartment) {
            Data = new ClusterData() {
                Cost = apartment.Data.Cost,
                AreaSize = apartment.Data.AreaSize,
                RoomsCount = apartment.Data.RoomsCount,
                BathroomsCount = apartment.Data.BathroomsCount
            };
            Id = apartment.Id;
            City = apartment.City;
            Company = apartment.Company;
        }
    }
}
