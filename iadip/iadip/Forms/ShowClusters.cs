using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace iadip
{
    public partial class ShowClusters : Form
    {
        public ShowClusters()
        {
            InitializeComponent();
        }

        public void Init(List<Cluster> clusters)
        {
            grid.DataSource = GetResultsTable(clusters);
        }

        DataTable GetResultsTable(List<Cluster> clusters)
        {
            DataTable table = new DataTable();

            string keyCluster = "Cluster";
            string keyId = "Id";
            string keyCity = "City";
            string keyCompany = "Company";

            table.Columns.Add(keyCluster);
            table.Columns.Add(keyId);

            ClusterData example = Program.DataExample;
            foreach (var pair in example.ParamValues)
            {
                string column = Localization.Instance.ClusterDataParamName(pair.Key);
                table.Columns.Add(column);
            }

            table.Columns.Add(keyCity);
            table.Columns.Add(keyCompany);

            DataRow r = null;

            for (int i = 0; i < clusters.Count; i++)
            {
                Cluster c = clusters[i];

                r = table.NewRow();
                r[keyCluster] = "CENTER";
                r[keyId] = i;

                foreach (var pair in example.ParamValues)
                {
                    string column = Localization.Instance.ClusterDataParamName(pair.Key);
                    r[column] = string.Format("{0:0.00}", c.Center.Get(pair.Key));
                }

                r[keyCity] = "-";
                r[keyCompany] = "-";
                table.Rows.Add(r);

                for (int j = 0; j < c.Apartaments.Count; j++)
                {
                    var a = c.Apartaments[j];
                    var data = a.Data;

                    r = table.NewRow();
                    r[keyId] = a.Id;
                    r[keyCluster] = i;

                    foreach (var pair in example.ParamValues)
                    {
                        string column = Localization.Instance.ClusterDataParamName(pair.Key);
                        r[column] = data.Get(pair.Key);
                    }

                    r[keyCity] = a.City;
                    r[keyCompany] = a.Company;
                    table.Rows.Add(r);
                }

                r = table.NewRow();
                table.Rows.Add(r);
            }
            
            return table;
        }
    }
}
