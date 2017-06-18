using System.Collections.Generic;

namespace iadip
{
    interface IClusterize
    {
        List<Cluster> Clasterize(List<SourceDataRow> apartaments);
    }
}
