using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace iadip
{
    class KMeansV2 : IClusterize
    {
        public List<Cluster> Clasterize(List<SourceDataRow> apartaments)
        {
            ClusterData globalMax = apartaments.Select(c => c.Data).ToList().ClusterMax();
            ClusterData globalCenter = GetCenter(apartaments.Select(c => c.Data.Clone()).ToList());
            apartaments = apartaments.OrderBy(c => OrderByDistance(c, globalCenter, globalMax)).ToList();

            string elemsPerClusterStr = Localization.Instance.Get("param.kmeans.elemsPerCluster");
            int elemsPerCluster = int.Parse(elemsPerClusterStr, CultureInfo.InvariantCulture.NumberFormat);

            ClusterData[] centers = new ClusterData[apartaments.Count / elemsPerCluster];
            centers[0] = globalCenter;
            for (int i = 1; i < centers.Length; i++)
                centers[i] = apartaments[apartaments.Count - 1 - i].Data.Clone();

            int[] assignToCluster = new int[apartaments.Count];
            for (int i = 0; i < assignToCluster.Length; i++)
                assignToCluster[i] = -1;

            bool[] needUpdateCenter = new bool[centers.Length];

            bool continueCalculate = false;
            int iterations = 0;

            do
            {
                iterations++;

                for (int i = 0; i < needUpdateCenter.Length; i++)
                    needUpdateCenter[i] = false;

                for (int i = 0; i < apartaments.Count; i++)
                {
                    ClusterData apartamentData = apartaments[i].Data.Clone();
                    Dictionary<int, double> distancesToCenter = new Dictionary<int, double>();
                    for (int k = 0; k < centers.Length; k++)
                        distancesToCenter.Add(k, ClusterDataExtension.Distance(apartamentData, centers[k], globalMax));

                    int indexClosest = distancesToCenter.OrderBy(c => c.Value).First().Key;

                    if (assignToCluster[i] != indexClosest)
                    {
                        continueCalculate = true;
                        needUpdateCenter[indexClosest] = true;
                        if (assignToCluster[i] != -1)
                            needUpdateCenter[assignToCluster[i]] = true;

                        assignToCluster[i] = indexClosest;
                    }
                }

                for (int i = 0; i < centers.Length; i++)
                {
                    if (needUpdateCenter[i])
                    {
                        List<ClusterData> dataInCluster = new List<ClusterData>();
                        for (int k = 0; k < apartaments.Count; k++)
                        {
                            if (assignToCluster[k] == i)
                                dataInCluster.Add(apartaments[k].Data.Clone());
                        }

                        centers[i] = GetCenter(dataInCluster);
                    }
                }

                if (iterations >= 100)
                {
                    continueCalculate = false;
                    Debug.WriteLine("KMeansV2: max iterations reached");
                }
            }
            while (continueCalculate);

            List<Cluster> result = new List<Cluster>();
            for (int i = 0; i < centers.Length; i++)
            {
                List<SourceDataRow> rows = new List<SourceDataRow>();

                for (int k = 0; k < apartaments.Count; k++)
                {
                    if (assignToCluster[k] == i)
                        rows.Add(apartaments[k]);
                }

                if (rows.Count != 0)
                {
                    Cluster c = new Cluster();
                    c.Apartaments = rows;
                    c.Center = centers[i];
                    result.Add(c);
                }
            }

            return result;
        }

        private ClusterData GetCenter(List<ClusterData> apartaments)
        {
            ClusterData allAverage = new ClusterData();

            foreach (var pair in Program.DataExample.ParamValues)
            {
                double v = apartaments.Sum(a => a.Get(pair.Key)) / apartaments.Count;
                allAverage.Set(pair.Key, v);
            }

            return allAverage;
        }

        private double OrderByDistance(SourceDataRow a, ClusterData center, ClusterData max)
        {
            return ClusterDataExtension.Distance(a.Data.Clone(), center, max);
        }
    }
}
