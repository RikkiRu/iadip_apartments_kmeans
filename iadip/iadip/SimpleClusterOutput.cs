using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iadip {
    class SimpleClusterOutput : IClusterOutput {

        public ClusterOutputData Calculate(Cluster c) {

            ClusterData max = ClusterDataExtension.ClusterMax(c.Apartaments);
            ClusterData min = ClusterDataExtension.ClusterMin(c.Apartaments);
            ClusterData average = new ClusterData() {
                Cost = (max.Cost + min.Cost) / 2,
                AreaSize = (max.AreaSize + min.AreaSize) / 2,
                RoomsCount = (max.RoomsCount + min.RoomsCount) / 2,
                BathroomsCount = (max.BathroomsCount + min.BathroomsCount) / 2
            };

            List<string> cities = new List<string>();
            foreach (var i in c.Apartaments) {
                if (!cities.Contains(i.City)) {
                    cities.Add(i.City);
                }
            }

            List<string> companies = new List<string>();
            foreach (var i in c.Apartaments) {
                if (!companies.Contains(i.Company)) {
                    companies.Add(i.Company);
                }
            }

            return new ClusterOutputData() {
                Max = max,
                Min = min,
                Average = average,
                Cities = cities,
                Companies = companies
            };
        }

    }
}
