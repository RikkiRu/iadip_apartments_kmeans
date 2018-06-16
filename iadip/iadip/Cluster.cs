using System.Collections.Generic;

namespace iadip
{
    public class Cluster
    {
        public ClusterData Center;
        public List<SourceDataRow> Apartaments;

        public SourceDataRow ApartmentsListData {
            get => default(SourceDataRow);
            set {
            }
        }

        public ClusterData CenterData {
            get => default(ClusterData);
            set {
            }
        }
    }
}
