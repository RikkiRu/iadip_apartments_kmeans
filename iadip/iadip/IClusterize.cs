using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iadip
{
    interface IClusterize
    {
        List<Cluster> Clasterize(List<Apartament> apartaments);
    }
}
