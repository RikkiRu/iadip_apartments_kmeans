using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iadip
{
    static class ListClusterDataExtension
    {
        public static ClusterData ClusterAverage(this List<ClusterData> data)
        {
            //data.ClusterMin()

            return null;
        }

        public static ClusterData ClusterMin(this List<ClusterData> data, Func<int ,int> f)
        {
            int minCost = data.Min(c => c.Cost);
            //int minArea = data.Min(c => c.AreaSize);
            int minRooms = data.Min(c => c.RoomsCount);
            int minBathrooms = data.Min(c => c.BathroomsCount);

            return new ClusterData()
            {
                Cost = minCost,
                //AreaSize = minArea,
                RoomsCount = minRooms,
                BathroomsCount = minBathrooms
            };
        }
    }
}