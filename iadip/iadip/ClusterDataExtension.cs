using System;
using System.Collections.Generic;
using System.Linq;

namespace iadip
{
    static class ClusterDataExtension
    {
        public static double Distance(ClusterData c1, ClusterData c2, ClusterData max)
        {
            List<double> pows = new List<double>();
            foreach(var pair in c1.ParamValues)
            {
                int key = pair.Key;
                double v = Math.Pow(Math.Abs(c1.Get(key) - c2.Get(key)) / max.Get(key), 2);
                pows.Add(v);
            }

            double sum = pows.Sum();
            return Math.Sqrt(sum);
        }

        public static ClusterData ClusterMax(this List<ClusterData> data)
        {
            return data.ClusterFunc(true);
        }

        public static ClusterData ClusterMin(this List<ClusterData> data)
        {
            return data.ClusterFunc(false);
        }

        public static ClusterData ClusterFunc(this List<ClusterData> data, bool isMax)
        {
            if (data.Count < 1)
                throw new Exception("ClusterFunc require at least 1 element");

            Dictionary<int, double> maxValues = new Dictionary<int, double>();

            foreach (var pair in data[0].ParamValues)
            {
                int key = pair.Key;
                double v = 0;

                if (isMax)
                    v = data.Max(c => c.Get(key));
                else
                    v = data.Min(c => c.Get(key));

                maxValues.Add(key, v);
            }

            ClusterData max = new ClusterData();
            foreach (var pair in maxValues)
                max.Set(pair.Key, pair.Value);

            return max;
        }

        public static ClusterData ClusterMax(this List<SourceDataRow> data)
        {
            List<ClusterData> d = data.Select(c => c.Data).ToList();
            return d.ClusterMax();
        }

        public static ClusterData ClusterMin(this List<SourceDataRow> data) {
            List<ClusterData> d = data.Select(c => c.Data).ToList();
            return d.ClusterMin();
        }  
    }
}