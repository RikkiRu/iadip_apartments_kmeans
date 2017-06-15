using System.Collections.Generic;

namespace iadip {

    interface IParser {
        List<Apartament> ReadFile(string path);
    }    
}
