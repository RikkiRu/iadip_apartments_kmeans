namespace iadip
{
    public class SourceDataRow
    {
        public ClusterData Data;
        public int Id;
        public string City;
        public string Company;

        public override string ToString()
        {
            return string.Format("SourceDataRow {0}", Data.ToString());
        }

        public SourceDataRow() {
            Data = new ClusterData();
        }

        public SourceDataRow(SourceDataRow row) {
            Data = new ClusterData() {
                P1 = row.Data.P1,
                P2 = row.Data.P2,
                P3 = row.Data.P3,
                P4 = row.Data.P4
            };
            Id = row.Id;
            City = row.City;
            Company = row.Company;
        }
    }
}
