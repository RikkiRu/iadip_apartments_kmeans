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
            return string.Format("{0} {1} {2} {3}", Id, Data.ToString(), City, Company);
        }

        public SourceDataRow() {
            Data = new ClusterData();
        }

        public SourceDataRow(SourceDataRow row) {
            Data = row.Data.Clone();
            Id = row.Id;
            City = row.City;
            Company = row.Company;
        }
    }
}
