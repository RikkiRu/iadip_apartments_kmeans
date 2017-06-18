using System.Collections.Generic;

namespace iadip {

    interface IParser {
        List<SourceDataRow> ReadFile(string path);
    }    
}
