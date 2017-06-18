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

            Dictionary<int, List<string>> values = new Dictionary<int, List<string>>();

            foreach (var index in Program.AdditionalParams)
            {
                values.Add(index, new List<string>());

                foreach (var i1 in c.Apartaments)
                {
                    if (!values[index].Contains(i1.GetOtherData(index)))
                        values[index].Add(i1.GetOtherData(index));
                }
            }

            return new ClusterOutputData()
            {
                Max = max,
                Min = min,
                Average = average,
                Additional = values
            };
        }

    }
}
