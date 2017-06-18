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
            clone.Cost = source.Cost;
            clone.AreaSize = source.AreaSize;
            clone.RoomsCount = source.RoomsCount;
            clone.BathroomsCount = source.BathroomsCount;
            return clone;
        }

        public static double Distance(ClusterData c1, ClusterData c2, ClusterData max)
        {
            double cost = Math.Pow(Math.Abs(c1.Cost - c2.Cost) / max.Cost, 2);
            double area = Math.Pow(Math.Abs(c1.AreaSize - c2.AreaSize) / max.AreaSize, 2);
            double rooms = Math.Pow(Math.Abs(c1.RoomsCount - c2.RoomsCount) / max.RoomsCount, 2);
            double bath = Math.Pow(Math.Abs(c1.BathroomsCount - c2.BathroomsCount) / max.BathroomsCount, 2);
            return Math.Sqrt(cost + area + rooms + bath);
        }

        public static ClusterData ClusterMax(this List<ClusterData> data)
        {
            double cost = data.Max(c => c.Cost);
            double area = data.Max(c => c.AreaSize);
            double rooms = data.Max(c => c.RoomsCount);
            double bathrooms = data.Max(c => c.BathroomsCount);

            return new ClusterData()
            {
                Cost = cost,
                AreaSize = area,
                RoomsCount = rooms,
                BathroomsCount = bathrooms
            };
        }

        public static ClusterData ClusterMax(this List<Apartament> data) {
            double cost = data.Max(c => c.Data.Cost);
            double area = data.Max(c => c.Data.AreaSize);
            double rooms = data.Max(c => c.Data.RoomsCount);
            double bathrooms = data.Max(c => c.Data.BathroomsCount);

            return new ClusterData() {
                Cost = cost,
                AreaSize = area,
                RoomsCount = rooms,
                BathroomsCount = bathrooms
            };
        }

        public static ClusterData ClusterMin(this List<Apartament> data) {
            double cost = data.Min(c => c.Data.Cost);
            double area = data.Min(c => c.Data.AreaSize);
            double rooms = data.Min(c => c.Data.RoomsCount);
            double bathrooms = data.Min(c => c.Data.BathroomsCount);

            return new ClusterData() {
                Cost = cost,
                AreaSize = area,
                RoomsCount = rooms,
                BathroomsCount = bathrooms
            };
        }  
    }
}