using System;
using System.Collections.Generic;

namespace iadip {

    class SimpleEstimator : IEstimator {

        public Cluster Estimate(List<Cluster> clusters, ClusterSearchOptions sourceData) {

            Cluster resultCluster = new Cluster();
            double minDistanceBetweenDots = double.MaxValue;

            foreach (var singleCluster in clusters) {
                if (Math.Abs(sourceData.P1 - singleCluster.Center.P1) < minDistanceBetweenDots) {
                    resultCluster = singleCluster;
                    minDistanceBetweenDots = Math.Abs(sourceData.P1 - singleCluster.Center.P1);
                }
            }

            return resultCluster;
        }

    }

}
