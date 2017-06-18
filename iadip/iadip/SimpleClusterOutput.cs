using System.Collections.Generic;

namespace iadip
{
    class SimpleClusterOutput : IClusterOutput {

        public ClusterOutputData Calculate(Cluster c) {

            ClusterData max = ClusterDataExtension.ClusterMax(c.Apartaments);
            ClusterData min = ClusterDataExtension.ClusterMin(c.Apartaments);
            ClusterData average = new ClusterData();

            foreach (var pair in Program.DataExample.ParamValues)
            {
                double v = (max.Get(pair.Key) + min.Get(pair.Key)) / 2;
                average.Set(pair.Key, v);
            }

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
