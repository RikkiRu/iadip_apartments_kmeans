using System;
using System.Collections.Generic;
using System.Linq;

namespace iadip
{
    static class ClusterDataExtension
    {
        public static ClusterData GetAbsoluteDistanceBetween(ClusterData data1, ClusterData data2)
        {
            return new ClusterData()
            {
                Cost = Math.Abs(data1.Cost - data2.Cost),
                AreaSize = Math.Abs(data1.AreaSize - data1.AreaSize),
                RoomsCount = Math.Abs(data1.RoomsCount - data2.RoomsCount),
                BathroomsCount = Math.Abs(data1.BathroomsCount - data2.BathroomsCount)
            };
        }

        public static List<ClusterData> ToClusterData(this List<Apartament> data)
        {
            return data.Select(c => c.Data).ToList();
        }

        public static ClusterData ClusterAverage(this List<ClusterData> data)
        {
            ClusterData min = data.ClusterMin();
            ClusterData max = data.ClusterMax();

            return new ClusterData()
            {
                Cost = (min.Cost + max.Cost) / 2,
                AreaSize = (min.AreaSize + max.AreaSize) / 2,
                RoomsCount = (min.RoomsCount + max.RoomsCount) / 2,
                BathroomsCount = (min.BathroomsCount + max.BathroomsCount) / 2
            };
        }

        public static ClusterData ClusterMin(this List<ClusterData> data)
        {
            double cost = data.Min(c => c.Cost);
            double area = data.Min(c => c.AreaSize);
            int rooms = data.Min(c => c.RoomsCount);
            int bathrooms = data.Min(c => c.BathroomsCount);

            return new ClusterData()
            {
                Cost = cost,
                AreaSize = area,
                RoomsCount = rooms,
                BathroomsCount = bathrooms
            };
        }

        public static ClusterData ClusterMax(this List<ClusterData> data)
        {
            double cost = data.Max(c => c.Cost);
            double area = data.Max(c => c.AreaSize);
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
    }
}