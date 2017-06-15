﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace iadip
{
    class ClusterDataLerp
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
        public static ClusterDataLerp Lerp(this ClusterData source, ClusterData min, ClusterData max)
        {
            return source.ToLerp().Lerp(min, max);
        }

        public static ClusterDataLerp Clone(this ClusterDataLerp source)
        {
            ClusterDataLerp lerp = new ClusterDataLerp();
            lerp.Cost = source.Cost;
            lerp.AreaSize = source.AreaSize;
            lerp.RoomsCount = source.RoomsCount;
            lerp.BathroomsCount = source.BathroomsCount;
            return lerp;
        }

        public static ClusterDataLerp ToLerp(this ClusterData source)
        {
            ClusterDataLerp lerp = new ClusterDataLerp();
            lerp.Cost = source.Cost;
            lerp.AreaSize = source.AreaSize;
            lerp.RoomsCount = source.RoomsCount;
            lerp.BathroomsCount = source.BathroomsCount;
            return lerp;
        }

        public static ClusterDataLerp Lerp(this ClusterDataLerp source, ClusterData min, ClusterData max)
        {
            ClusterDataLerp lerp = new ClusterDataLerp();
            double dCost = max.Cost == min.Cost ? 1 : max.Cost - min.Cost; 
            lerp.Cost = (double)(source.Cost - min.Cost) / dCost;
            double dArea = max.AreaSize == min.AreaSize ? 1 : max.AreaSize - min.AreaSize;
            lerp.AreaSize = (double)(source.AreaSize - min.AreaSize) / dArea;
            double dRooms = max.RoomsCount == min.RoomsCount ? 1 : max.RoomsCount - min.RoomsCount;
            lerp.RoomsCount = (double)(source.RoomsCount - min.RoomsCount) / dRooms;
            double dBath = max.BathroomsCount == min.BathroomsCount ? 1 : max.BathroomsCount - min.BathroomsCount;
            lerp.BathroomsCount = (double)(source.BathroomsCount - min.BathroomsCount) / dBath;
            return lerp;
        }

        public static List<ClusterData> ToClusterData(this List<Apartament> data)
        {
            return data.Select(c => c.Data).ToList();
        }

        public static double Distance(ClusterDataLerp c1, ClusterDataLerp c2)
        {
            double cost = Math.Pow(c1.Cost - c2.Cost, 2);
            double area = Math.Pow(c1.AreaSize - c2.AreaSize, 2);
            double rooms = Math.Pow(c1.RoomsCount - c2.RoomsCount, 2);
            double bath = Math.Pow(c1.BathroomsCount - c2.BathroomsCount, 2);
            return Math.Sqrt(cost + area + rooms + bath);
        }

        public static ClusterDataLerp ClusterAverage(ClusterData min, ClusterData max)
        {
            return ClusterAverage(min.ToLerp(), max.ToLerp());
        }

        public static ClusterDataLerp ClusterAverage(ClusterDataLerp min, ClusterDataLerp max)
        {
            return new ClusterDataLerp()
            {
                Cost = (double)(min.Cost + max.Cost) / 2,
                AreaSize = (double)(min.AreaSize + max.AreaSize) / 2,
                RoomsCount = (double)(min.RoomsCount + max.RoomsCount) / 2,
                BathroomsCount = (double)(min.BathroomsCount + max.BathroomsCount) / 2
            };
        }

        public static ClusterData ClusterMin(this List<ClusterData> data)
        {
            double cost = data.Min(c => c.Cost);
            int area = data.Min(c => c.AreaSize);
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
    }
}