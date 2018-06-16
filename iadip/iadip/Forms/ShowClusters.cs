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
            grid.ScrollBars = ScrollBars.Both;
        }

        DataTable GetResultsTable(List<Cluster> clusters)
        {
            DataTable table = new DataTable();

            string keyCluster = "Cluster";
            string keyId = "Id";

            table.Columns.Add(keyCluster);
            table.Columns.Add(keyId);

            ClusterData example = Program.DataExample;
            foreach (var pair in example.ParamValues)
            {
                string column = Localization.Instance.ClusterDataParamName(pair.Key);
                table.Columns.Add(column);
            }

            foreach (var a in Program.AdditionalParams)
            {
                string column = Localization.Instance.AdditonalDataName(a);
                table.Columns.Add(column);
            }

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

                foreach (var a in Program.AdditionalParams)
                {
                    string column = Localization.Instance.AdditonalDataName(a);
                    r[column] = "-";
                }

                table.Rows.Add(r);

                for (int j = 0; j < c.Apartaments.Count; j++)
                {
                    var a = c.Apartaments[j];
                    //var data = a.Data;
                    var data = a.OtherData;

                    r = table.NewRow();
                    r[keyId] = a.Id;
                    r[keyCluster] = i;

                    foreach (var pair in example.ParamValues)
                    {
                        string column = Localization.Instance.ClusterDataParamName(pair.Key);
                        r[column] = data[pair.Key];
                    }

                    foreach (var t in Program.AdditionalParams)
                    {
                        string column = Localization.Instance.AdditonalDataName(t);
                        r[column] = a.GetOtherData(t);
                    }

                    table.Rows.Add(r);
                }

                r = table.NewRow();
                table.Rows.Add(r);
            }
            
            return table;
        }
    }
}
