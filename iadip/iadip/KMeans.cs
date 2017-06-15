using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iadip
{
    class KMeans : IClusterize
    {
        private static Random random = new Random(0);

        private class ClusterDataPair
        {
            public ClusterData AbsDist;
            public ClusterData Original;
            public double relativeDist;
        }

        public List<Cluster> Clasterize(List<Apartament> apartaments)
        {
            List<ClusterData> data = apartaments.ToClusterData();
            ClusterData a = data.ClusterAverage();

            List<ClusterDataPair> absoluteDistances = new List<ClusterDataPair>();
            foreach (var i in data)
            {
                ClusterData absDist = ClusterDataExtension.GetAbsoluteDistanceBetween(i, a);
                absoluteDistances.Add(new ClusterDataPair() { AbsDist = absDist, Original = i } );
            }

            return null;
        }
        
        private List<Cluster> InitialClusterize()
        {
            return null;
        }

        public static void Test()
        {
            List<Apartament> apartaments = new List<Apartament>();

            for (int i = 0; i < 30; i++)
            {
                Apartament a1 = new Apartament();
                a1.City = "Г" + random.Next(0, 4);
                a1.Company = "К" + random.Next(0, 4);
                a1.Data = new ClusterData()
                {
                    AreaSize = random.Next(50, 100),
                    BathroomsCount = random.Next(0, 4),
                    Cost = random.Next(50, 100),
                    RoomsCount = random.Next(1, 10)
                };
                a1.Id = i;
                apartaments.Add(a1);
            }
        }
    }
}
