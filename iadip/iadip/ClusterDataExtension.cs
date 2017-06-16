using System;
using System.Collections.Generic;
using System.Linq;

namespace iadip
{
    public class ClusterDataLerp
    {
        public double Cost;
        public double AreaSize;
        public double RoomsCount;
        public double BathroomsCount;

        public override string ToString()
        {
            return
                string.Format(
                    "ClusterDataLerp. Cost: {0:0.00}, AreaSize: {1:0.00}, RoomsCount: {2:0.00}, BathroomsCount: {3:0.00}",
                    Cost,
                    AreaSize,
                    RoomsCount,
                    BathroomsCount
                    );
        }
    }

    static class ClusterDataExtension
    {
        public static ClusterDataLerp ToLerp(this ClusterData source)
        {
            ClusterDataLerp lerp = new ClusterDataLerp();
            lerp.Cost = source.Cost;
            lerp.AreaSize = source.AreaSize;
            lerp.RoomsCount = source.RoomsCount;
            lerp.BathroomsCount = source.BathroomsCount;
            return lerp;
        }

        public static double Distance(ClusterDataLerp c1, ClusterDataLerp c2, ClusterData max)
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
            int area = data.Max(c => c.AreaSize);
            int rooms = data.Max(c => c.RoomsCount);
            int bathrooms = data.Max(c => c.BathroomsCount);

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
            int area = data.Max(c => c.Data.AreaSize);
            int rooms = data.Max(c => c.Data.RoomsCount);
            int bathrooms = data.Max(c => c.Data.BathroomsCount);

            return new ClusterData() {
                Cost = cost,
                AreaSize = area,
                RoomsCount = rooms,
                BathroomsCount = bathrooms
            };
        }

        public static ClusterData ClusterMin(this List<Apartament> data) {
            double cost = data.Min(c => c.Data.Cost);
            int area = data.Min(c => c.Data.AreaSize);
            int rooms = data.Min(c => c.Data.RoomsCount);
            int bathrooms = data.Min(c => c.Data.BathroomsCount);

            return new ClusterData() {
                Cost = cost,
                AreaSize = area,
                RoomsCount = rooms,
                BathroomsCount = bathrooms
            };
        }  
    }
}