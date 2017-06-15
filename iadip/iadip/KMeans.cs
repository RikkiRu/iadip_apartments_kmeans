using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace iadip
{
    class KMeans : IClusterize
    {
        private static Random random = new Random(0);

        private class ApartamentCalculated
        {
            public Apartament SourceApartament;
            public ClusterDataLerp LerpValue;
            public double DistanceToAverage;
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

        private List<Apartament> sourceData;
        private List<ClusterData> clusterData;
        private ClusterData min;
        private ClusterData max;
        private ClusterDataLerp average;
        private ClusterDataLerp averageLerp;
        private List<ClusterDataLerp> lerpValues;
        private List<ApartamentCalculated> calculated;
        private List<Center> centers;

        public List<Cluster> Clasterize(List<Apartament> apartaments)
        {
            StringBuilder log = new StringBuilder();
            sourceData = apartaments;
            clusterData = apartaments.ToClusterData();
            foreach (var a in clusterData)
                log.AppendLine(a.ToString());

            min = clusterData.ClusterMin();
            max = clusterData.ClusterMax();
            average = ClusterDataExtension.ClusterAverage(min, max);

            // Взяли относительное среднее - всё по 0.5
            averageLerp = average.Lerp(min, max);

            log.AppendLine("min " + min.ToString());
            log.AppendLine("max " + max.ToString());
            log.AppendLine("average " + average.ToString());
            log.AppendLine("average lerp: " + averageLerp.ToString());

            lerpValues = clusterData.Select(c => c.Lerp(min, max)).ToList();

            calculated = new List<ApartamentCalculated>();
            for (int i = 0; i < sourceData.Count; i++)
            {
                calculated.Add(new ApartamentCalculated()
                {
                    SourceApartament = sourceData[i],
                    LerpValue = lerpValues[i],
                    // Дистанция между текущим относительным и средним относительным
                    DistanceToAverage = ClusterDataExtension.Distance(lerpValues[i], averageLerp)
                });
            }

            calculated = calculated.OrderBy(c => c.DistanceToAverage).ToList();

            foreach (var i in calculated)
                log.AppendLine( string.Format("Dist: {0:0.00}; ", i.DistanceToAverage) + i.LerpValue.ToString());

            // Берём центр в середине и несколько самых дальних
            centers = new List<Center>();
            centers.Add(new Center(calculated[0].LerpValue));
            int clusters = (calculated.Count - 1) / 3;
            for (int i = 0; i < clusters; i++)
            {
                centers.Add(new Center(calculated[calculated.Count - 1 - i].LerpValue));
            }

            bool wasChanges = true;

            while (wasChanges)
            {
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

                for (int i = 0; i < toRecalculateCenters.Count; i++)
                {
                    Center c = toRecalculateCenters[i];
                    Recalculate(c);
                }
            }

            foreach (var i in centers)
            {
                log.AppendLine("Cluster: " + i.Coords.ToString());
                foreach (var j in i.Rows)
                {
                    log.AppendLine(j.LerpValue.ToString());
                }
            }

            Debug.Print(log.ToString());

            return null;
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

        public static void Test()
        {
            List<Apartament> apartaments = new List<Apartament>();

            for (int i = 0; i < 10; i++)
            {
                Apartament a1 = new Apartament();
                a1.City = "";
                a1.Company = "";
                a1.Data = new ClusterData()
                {
                    AreaSize = random.Next(1, 100),
                    BathroomsCount = random.Next(0, 1),
                    Cost = random.Next(0, 1),
                    RoomsCount = random.Next(0, 1)
                };
                a1.Id = i;
                apartaments.Add(a1);
            }

            KMeans k = new KMeans();
            List<Cluster> c = k.Clasterize(apartaments);
        } 
    }
}
