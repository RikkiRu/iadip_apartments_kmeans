using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iadip
{
    public partial class ShowEstematedResult : Form, IResultShower {

        IClusterOutput output = new SimpleClusterOutput();

        public ShowEstematedResult() {
            InitializeComponent();
        }

        public void Init(Cluster cluster, ClusterSearchOptions sourceData) {            
            gridResultCluster.DataSource = GetResultsTable(cluster);

            var calcResult = output.Calculate(cluster);

            (this as IResultShower).Show(calcResult);

            Mape(calcResult, sourceData, cluster);
        }

        void IResultShower.Show(ClusterOutputData data) {

            tbResult.Text = string.Format("{0,-50}{1,10}" + Environment.NewLine, "Возможные параметры: ", "Средние параметры: ");

            StringBuilder b = new StringBuilder();

            foreach (var pair in Program.DataExample.ParamValues)
            {
                string name = Localization.Instance.ClusterDataParamName(pair.Key);

                b.Append("-" + name);
                b.Append(": ");
                b.AppendFormat("{0:0.00}", data.Min.Get(pair.Key));
                b.Append(" - ");
                b.AppendFormat("{0:0.00}", data.Max.Get(pair.Key));

                while (b.Length < 50)
                    b.Append(" ");

                b.Append(Localization.Instance.Get("words.avg") + ": ");
                b.AppendFormat("{0:0.00}", data.Average.Get(pair.Key));
                b.AppendLine();

                tbResult.Text += b.ToString();
                b.Clear();
            }

            foreach (var i in data.Additional)
            {
                string name = Localization.Instance.AdditonalDataName(i.Key);

                tbResult.Text += name + ": ";

                foreach (var j in i.Value)
                {
                    if (!string.IsNullOrEmpty(j))
                        tbResult.Text += j + "; ";
                }

                tbResult.Text += Environment.NewLine;
            }
        }

        void Mape(ClusterOutputData clusterData, ClusterSearchOptions sourceData, Cluster cluster)
        {
            var e = cluster.Apartaments.FirstOrDefault(c => c.Data.Get(sourceData.ParamIndex) == sourceData.ParamValue);

            if (e == null)
            {
                tbResult.Text += Environment.NewLine;
                tbResult.Text += Localization.Instance.Get("words.noMapeData") + Environment.NewLine;
                return;
            }

            // По центру

            Dictionary<string, double> mapeCenter = new Dictionary<string, double>();
            double centerGeneral = 0;
            int centerCount = 0;
            foreach (var pair in e.Data.ParamValues)
            {
                double d = pair.Value;
                double cD = cluster.Center.Get(pair.Key);
                string key = Localization.Instance.Get("words.mape")
                    + " " + Localization.Instance.Get("words.center")
                    + " " + Localization.Instance.ClusterDataParamName(pair.Key);

                double res = Math.Abs(d - cD) / d * 100;
                mapeCenter.Add(key, res);
                centerGeneral += res;
                centerCount++;
            }
            centerGeneral = centerGeneral / centerCount;

            // По среднему

            Dictionary<string, double> mapeAvg = new Dictionary<string, double>();
            double avgGeneral = 0;
            int avgCount = 0;
            foreach (var pair in e.Data.ParamValues)
            {
                double d = pair.Value;
                double cD = clusterData.Average.Get(pair.Key);
                string key = Localization.Instance.Get("words.mape")
                    + " " + Localization.Instance.Get("words.average")
                    + " " + Localization.Instance.ClusterDataParamName(pair.Key);

                double res = Math.Abs(d - cD) / d * 100;
                mapeAvg.Add(key, res);
                avgGeneral += res;
                avgCount++;
            }
            avgGeneral = avgGeneral / avgCount;

            StringBuilder b = new StringBuilder();
            b.AppendLine();
            b.AppendLine(Localization.Instance.Get("words.mapeFound"));
            b.AppendLine(e.ToString());
            b.AppendLine();

            // Вывод по центру ------------

            foreach (var pair in mapeCenter)
            {
                b.Append(pair.Key);
                b.Append(": ");
                b.AppendFormat("{0:0.00}", pair.Value);
                b.AppendLine();
            }

            string genCen = 
                Localization.Instance.Get("words.mape") 
                + " " + Localization.Instance.Get("words.center") 
                + " " + Localization.Instance.Get("words.general") 
                + ": {0:0.00}";

            b.AppendFormat(genCen, centerGeneral);
            b.AppendLine();

            b.AppendLine();
            // Вывод по среднему ------------

            foreach (var pair in mapeAvg)
            {
                b.Append(pair.Key);
                b.Append(": ");
                b.AppendFormat("{0:0.00}", pair.Value);
                b.AppendLine();
            }

            string genAvg =
                Localization.Instance.Get("words.mape")
                + " " + Localization.Instance.Get("words.average")
                + " " + Localization.Instance.Get("words.general")
                + ": {0:0.00}";

            b.AppendFormat(genAvg, avgGeneral);
            b.AppendLine();

            tbResult.Text += b.ToString();
        }

        DataTable GetResultsTable(Cluster cluster) {
            DataTable table = new DataTable();

            string keyCluster = "Cluster";
            string keyCity = "City";
            string keyCompany = "Company";

            table.Columns.Add(keyCluster);

            ClusterData example = Program.DataExample;
            foreach (var pair in example.ParamValues)
            {
                string column = Localization.Instance.ClusterDataParamName(pair.Key);
                table.Columns.Add(column);
            }

            table.Columns.Add(keyCity);
            table.Columns.Add(keyCompany);

            DataRow r = null;

            r = table.NewRow();
            r[keyCluster] = "CENTER";

            foreach (var pair in example.ParamValues)
            {
                string column = Localization.Instance.ClusterDataParamName(pair.Key);
                r[column] = string.Format("{0:0.00}", cluster.Center.Get(pair.Key));
            }

            r[keyCity] = "-";
            r[keyCompany] = "-";
            table.Rows.Add(r);

            return table;
        }

    }
}
