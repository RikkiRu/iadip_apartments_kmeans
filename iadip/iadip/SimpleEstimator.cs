using System;
using System.Collections.Generic;

namespace iadip {

    class SimpleEstimator : IEstimator {

        public Cluster Estimate(List<Cluster> clusters, ClusterSearchOptions sourceData) {

            Cluster resultCluster = new Cluster();
            double minDistanceBetweenDots = double.MaxValue;

            foreach (var singleCluster in clusters)
            {
                double m = Math.Abs(sourceData.ParamValue - singleCluster.Center.Get(sourceData.ParamIndex));

                if (m < minDistanceBetweenDots)
                {
                    resultCluster = singleCluster;
                    minDistanceBetweenDots = m;
                }
            }

            return resultCluster;
        }

    }

}
