using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace iadip
{
    class KMeansV2 : IClusterize
    {
        const int ElementsPerCluster = 100;

        public List<Cluster> Clasterize(List<Apartament> apartaments)
        {
            ClusterData globalMax = apartaments.Select(c => c.Data).ToList().ClusterMax();
            ClusterDataLerp globalCenter = GetCenter(apartaments.Select(c => c.Data.ToLerp()).ToList());
            apartaments = apartaments.OrderBy(c => OrderByDistance(c, globalCenter, globalMax)).ToList();

            ClusterDataLerp[] centers = new ClusterDataLerp[apartaments.Count / ElementsPerCluster];
            centers[0] = globalCenter;
            for (int i = 1; i < centers.Length; i++)
                centers[i] = apartaments[apartaments.Count - 1 - i].Data.ToLerp();

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
                    ClusterDataLerp apartamentData = apartaments[i].Data.ToLerp();
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
                        List<ClusterDataLerp> dataInCluster = new List<ClusterDataLerp>();
                        for (int k = 0; k < apartaments.Count; k++)
                        {
                            if (assignToCluster[k] == i)
                                dataInCluster.Add(apartaments[k].Data.ToLerp());
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
                List<Apartament> rows = new List<Apartament>();

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

        private ClusterDataLerp GetCenter(List<ClusterDataLerp> apartaments)
        {
            ClusterDataLerp allAverage = new ClusterDataLerp();
            allAverage.AreaSize = apartaments.Sum(a => a.AreaSize) / apartaments.Count;
            allAverage.BathroomsCount = apartaments.Sum(a => a.BathroomsCount) / apartaments.Count;
            allAverage.Cost = apartaments.Sum(a => a.Cost) / apartaments.Count;
            allAverage.RoomsCount = apartaments.Sum(a => a.RoomsCount) / apartaments.Count;
            return allAverage;
        }

        private double OrderByDistance(Apartament a, ClusterDataLerp center, ClusterData max)
        {
            return ClusterDataExtension.Distance(a.Data.ToLerp(), center, max);
        }
    }
}
