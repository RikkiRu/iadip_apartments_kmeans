using System.Collections.Generic;

namespace iadip {

    interface IEstimator {
        Cluster Estimate(List<Cluster> clusters, SourceData sourceData);
    }
}
