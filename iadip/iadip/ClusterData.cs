using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iadip
{
    public class ClusterData
    {
        public double Cost;
        public int AreaSize;
        public int RoomsCount;
        public int BathroomsCount;

        public override string ToString()
        {
            return
                string.Format(
                    "ClusterData. Cost: {0}, AreaSize: {1}, RoomsCount: {2}, BathroomsCount: {3}",
                    Cost,
                    AreaSize,
                    RoomsCount,
                    BathroomsCount
                    );
        }
    }
}
