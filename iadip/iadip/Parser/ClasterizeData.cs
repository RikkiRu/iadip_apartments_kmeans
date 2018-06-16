using System.Collections.Generic;

namespace iadip {
    public class ClasterizeData {
        public List<SourceDataRow> apartments;
        public string[] titles;

        public ClasterizeData (List<SourceDataRow> apartments, string[] titles) {
            this.apartments = apartments;
            this.titles = titles;
        }
    }
}
