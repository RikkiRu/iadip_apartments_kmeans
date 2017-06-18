using System.Collections.Generic;

namespace iadip
{
    class SimpleClusterOutput : IClusterOutput {

        public ClusterOutputData Calculate(Cluster c) {

            ClusterData max = ClusterDataExtension.ClusterMax(c.Apartaments);
            ClusterData min = ClusterDataExtension.ClusterMin(c.Apartaments);
            ClusterData average = new ClusterData() {
                P1 = (max.P1 + min.P1) / 2,
                P2 = (max.P2 + min.P2) / 2,
                P3 = (max.P3 + min.P3) / 2,
                P4 = (max.P4 + min.P4) / 2
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
