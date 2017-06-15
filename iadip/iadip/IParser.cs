using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iadip
{
    interface IParser
    {
        List<Apartament> ReadFile(string path);
    }
}
