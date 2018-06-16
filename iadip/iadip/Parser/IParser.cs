using System.Collections.Generic;

namespace iadip {

    interface IParser {
        ClasterizeData ReadFile (string path);
    }    
}
