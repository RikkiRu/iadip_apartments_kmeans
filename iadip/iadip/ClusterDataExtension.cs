using System;
using System.Collections.Generic;
using System.Linq;

namespace iadip
{
    static class ClusterDataExtension
    {
        public static ClusterData Clone(this ClusterData source)
        {
            ClusterData clone = new ClusterData();
            clone.P1 = source.P1;
            clone.P2 = source.P2;
            clone.P3 = source.P3;
            clone.P4 = source.P4;
            return clone;
        }

        public static double Distance(ClusterData c1, ClusterData c2, ClusterData max)
        {
            double cost = Math.Pow(Math.Abs(c1.P1 - c2.P1) / max.P1, 2);
            double area = Math.Pow(Math.Abs(c1.P2 - c2.P2) / max.P2, 2);
            double rooms = Math.Pow(Math.Abs(c1.P3 - c2.P3) / max.P3, 2);
            double bath = Math.Pow(Math.Abs(c1.P4 - c2.P4) / max.P4, 2);
            return Math.Sqrt(cost + area + rooms + bath);
        }

        public static ClusterData ClusterMax(this List<ClusterData> data)
        {
            double cost = data.Max(c => c.P1);
            double area = data.Max(c => c.P2);
            double rooms = data.Max(c => c.P3);
            double bathrooms = data.Max(c => c.P4);

            return new ClusterData()
            {
                P1 = cost,
                P2 = area,
                P3 = rooms,
                P4 = bathrooms
            };
        }

        public static ClusterData ClusterMax(this List<SourceDataRow> data) {
            double cost = data.Max(c => c.Data.P1);
            double area = data.Max(c => c.Data.P2);
            double rooms = data.Max(c => c.Data.P3);
            double bathrooms = data.Max(c => c.Data.P4);

            return new ClusterData() {
                P1 = cost,
                P2 = area,
                P3 = rooms,
                P4 = bathrooms
            };
        }

        public static ClusterData ClusterMin(this List<SourceDataRow> data) {
            double cost = data.Min(c => c.Data.P1);
            double area = data.Min(c => c.Data.P2);
            double rooms = data.Min(c => c.Data.P3);
            double bathrooms = data.Min(c => c.Data.P4);

            return new ClusterData() {
                P1 = cost,
                P2 = area,
                P3 = rooms,
                P4 = bathrooms
            };
        }  
    }
}