using System.Collections.Generic;

namespace iadip
{
    class ClusterOutputData
    {
        public ClusterData Min;
        public ClusterData Max;
        public ClusterData Average;

        public Dictionary<int, List<string>> Additional;
    }
}
