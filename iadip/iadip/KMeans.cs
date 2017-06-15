using System;
using System.Collections.Generic;
using System.Linq;

namespace iadip
{
    class KMeans : IClusterize
    {
        const int ElementsPerCluster = 100;
        private static Random random = new Random(0);

        private class ApartamentCalculated
        {
            public Apartament SourceApartament;
            public ClusterDataLerp LerpValue;
            public Center ClusterCenter;
        }

        private class Center
        {
            public ClusterDataLerp Coords;
            public List<ApartamentCalculated> Rows;

            public Center(ClusterDataLerp coords)
            {
                Rows = new List<ApartamentCalculated>();
                Coords = coords.Clone();
            }
        }

        public List<Cluster> Clasterize(List<Apartament> apartaments)
        {
            List<ClusterData> clusterData = apartaments.ToClusterData();
            ClusterData min = clusterData.ClusterMin();
            ClusterData max = clusterData.ClusterMax();
            ClusterDataLerp average = ClusterDataExtension.ClusterAverage(min, max);
            ClusterDataLerp averageLerp = average.Lerp(min, max);

            List<ClusterDataLerp> lerpValues = clusterData.Select(c => c.Lerp(min, max)).ToList();

            List<ApartamentCalculated> calculated = new List<ApartamentCalculated>();
            for (int i = 0; i < apartaments.Count; i++)
            {
                calculated.Add(new ApartamentCalculated()
                {
                    SourceApartament = apartaments[i],
                    LerpValue = lerpValues[i],
                });
            }

            calculated = calculated.OrderBy(c => ClusterDataExtension.Distance(c.LerpValue, averageLerp)).ToList();

            List<Center> centers = new List<Center>();
            centers.Add(new Center(calculated[0].LerpValue));
            int clusters = (calculated.Count - 1) / ElementsPerCluster;
            for (int i = 0; i < clusters; i++)
                centers.Add(new Center(calculated[calculated.Count - 1 - i].LerpValue));

            bool wasChanges = true;

            int loops = 0; // Не известно как пофиксить зацикленность. Возможно никак, ведь кластеры могут смещаться как угодно и ходить кругами.
            
            while (wasChanges && loops < 100)
            {
                loops++;
                wasChanges = false;

                List<Center> toRecalculateCenters = new List<Center>();

                for (int i = 0; i < calculated.Count; i++)
                {
                    ApartamentCalculated row = calculated[i];

                    double minDist = double.MaxValue;
                    Center c = null;

                    for (int j = 0; j < centers.Count; j++)
                    {
                        double dist = ClusterDataExtension.Distance(centers[j].Coords, row.LerpValue);
                        if (dist < minDist)
                        {
                            minDist = dist;
                            c = centers[j];
                        }
                    }

                    if (row.ClusterCenter != c)
                    {
                        if (row.ClusterCenter != null)
                        {
                            if (!toRecalculateCenters.Contains(row.ClusterCenter))
                                toRecalculateCenters.Add(row.ClusterCenter);
                            row.ClusterCenter.Rows.Remove(row);
                        }

                        row.ClusterCenter = c;
                        wasChanges = true;
                        c.Rows.Add(row);

                        if (!toRecalculateCenters.Contains(c))
                            toRecalculateCenters.Add(c);
                    }
                }

                foreach (var i in toRecalculateCenters)
                    Recalculate(i);
            }

            List<Cluster> resultClusters = new List<Cluster>();
            foreach (var i in centers)
            {
                Cluster c = new Cluster();
                c.Apartaments = i.Rows.Select(r => r.SourceApartament).ToList();
                c.Center = i.Coords; // Сделать абсолютное значение вместо нормы.
                resultClusters.Add(c);
            }

            return resultClusters;
        }
        
        private void Recalculate(Center c)
        {
            if (c.Rows.Count < 1)
                return;

            ClusterDataLerp center = c.Rows[0].LerpValue;

            for (int i=1; i<c.Rows.Count; i++)
                center = ClusterDataExtension.ClusterAverage(center, c.Rows[i].LerpValue);

            c.Coords = center;
        }
    }
}
