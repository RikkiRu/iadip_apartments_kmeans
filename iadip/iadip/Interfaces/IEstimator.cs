using System.Collections.Generic;

namespace iadip {

    interface IEstimator {
        Cluster Estimate(List<Cluster> clusters, ClusterSearchOptions sourceData);
    }
}
