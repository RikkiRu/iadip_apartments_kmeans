using System;
using System.Collections.Generic;

namespace iadip {

    class SimpleEstimator : IEstimator {

        public Cluster Estimate(List<Cluster> clusters, SourceData sourceData) {
            if (clusters == null) {
                return null;
            }

            Cluster resultCluster = new Cluster();
            double minDistanceBetweenDots = double.MaxValue;

            foreach (var singleCluster in clusters) {
                if (Math.Abs(sourceData.Cost - singleCluster.Center.Cost) < minDistanceBetweenDots) {
                    resultCluster = singleCluster;
                    minDistanceBetweenDots = Math.Abs(sourceData.Cost - singleCluster.Center.Cost);
                }
            }

            return resultCluster;
        }

    }

}
