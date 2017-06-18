using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iadip
{
    public partial class Summary : Form
    {
        IClusterOutput output = new SimpleClusterOutput();

        public Summary()
        {
            InitializeComponent();
        }

        public void Init(List<Cluster> clusters)
        {
            int elements = 0;

            int indexBigCluster = -1;
            int elementsBigCluster = int.MinValue;
            int indexSmallCluster = -1;
            int elemtntsSmallCluster = int.MaxValue;

            List<SourceDataRow> all = new List<SourceDataRow>();

            for (int i = 0; i < clusters.Count; i++)
            {
                Cluster c = clusters[i];

                all = all.Concat(c.Apartaments).ToList();

                elements += c.Apartaments.Count;

                if (elementsBigCluster < c.Apartaments.Count)
                {
                    indexBigCluster = i;
                    elementsBigCluster = c.Apartaments.Count;
                }

                if (elemtntsSmallCluster > c.Apartaments.Count)
                {
                    indexSmallCluster = i;
                    elemtntsSmallCluster = c.Apartaments.Count;
                }
            }

            StringBuilder b = new StringBuilder();
            b.AppendLine("Общая характеристика кластеров");
            b.AppendLine();
            b.AppendFormat("Общее количество исследуемых объектов равно {0}. Количество кластеров равно {1}.", elements, clusters.Count);
            b.AppendLine();
            b.AppendFormat("Большинство объектов ({0}) сгруппированы в кластере {1}.", elementsBigCluster, indexBigCluster);
            b.AppendLine();
            b.AppendFormat("Наименьшее количество объектов ({0}) сгруппированы в кластере {1}.", elemtntsSmallCluster, indexSmallCluster);
            b.AppendLine();
            b.AppendLine();

            for (int i = 0; i < clusters.Count; i++)
            {
                Cluster c = clusters[i];
                b.AppendFormat("***** Информация по кластеру {0} *****", i);
                b.AppendLine();
                b.AppendLine();

                ClusterOutputData data = output.Calculate(c);

                foreach (var pair in Program.DataExample.ParamValues)
                {
                    double min = data.Min.Get(pair.Key);
                    double avg = c.Center.Get(pair.Key);
                    double max = data.Max.Get(pair.Key);

                    b.Append(Localization.Instance.Get("words.min"));
                    b.Append(" ");
                    b.Append(Localization.Instance.ClusterDataParamName(pair.Key));
                    b.Append(" ");
                    b.AppendFormat("{0:0.00}", min);
                    b.AppendLine();

                    b.Append(Localization.Instance.Get("words.avg"));
                    b.Append(" ");
                    b.Append(Localization.Instance.ClusterDataParamName(pair.Key));
                    b.Append(" ");
                    b.AppendFormat("{0:0.00}", avg);
                    b.AppendLine();

                    b.Append(Localization.Instance.Get("words.max"));
                    b.Append(" ");
                    b.Append(Localization.Instance.ClusterDataParamName(pair.Key));
                    b.Append(" ");
                    b.AppendFormat("{0:0.00}", max);
                    b.AppendLine();

                    b.AppendLine();
                }
            }

            richTextBox1.Text = b.ToString();

            grid.DataSource = GetResultsTable(clusters, elements, all);
        }

        DataTable GetResultsTable(List<Cluster> clusters, int totalElems, List<SourceDataRow> all)
        {
            ClusterData globalMax = all.Select(c => c.Data).ToList().ClusterMax();

            DataTable table = new DataTable();
            string keyId = "ID";
            string keyElements = "Элементы";

            table.Columns.Add(keyId);
            table.Columns.Add(keyElements);

            ClusterData example = Program.DataExample;
            foreach (var pair in example.ParamValues)
            {
                string column = Localization.Instance.ClusterDataParamName(pair.Key);
                table.Columns.Add(column);
            }

            DataRow r = null;

            for (int i = 0; i < clusters.Count; i++)
            {
                Cluster c = clusters[i];

                r = table.NewRow();
                r[keyId] = "Кластер " + i.ToString();
                double percent = (double)c.Apartaments.Count / totalElems * 100; 
                r[keyElements] = string.Format("{0:0.00}% ({1})", percent, c.Apartaments.Count);
                table.Rows.Add(r);

                foreach (var pair in example.ParamValues)
                {
                    string column = Localization.Instance.ClusterDataParamName(pair.Key);

                    double relative = c.Center.Get(pair.Key) / globalMax.Get(pair.Key);

                    string s1 = Localization.Instance.Get("param.lingv." + pair.Key.ToString() + ".split.1");
                    string s2 = Localization.Instance.Get("param.lingv." + pair.Key.ToString() + ".split.2");
                    string w1 = Localization.Instance.Get("param.lingv." + pair.Key.ToString() + ".word.1");
                    string w2 = Localization.Instance.Get("param.lingv." + pair.Key.ToString() + ".word.2");
                    string w3 = Localization.Instance.Get("param.lingv." + pair.Key.ToString() + ".word.3");

                    double d1 = double.Parse(s1, CultureInfo.InvariantCulture.NumberFormat);
                    double d2 = double.Parse(s2, CultureInfo.InvariantCulture.NumberFormat);

                    string v = GetLingvisticEstimate(relative, d1, d2, w1, w2, w3);

                    r[column] = v;
                }
            }

            return table;
        }

        public string GetLingvisticEstimate(double v, double small, double big, string wordSmall, string wordMedium, string wordBig)
        {
            if (v < small)
                return wordSmall;

            if (v > big)
                return wordBig;

            return wordMedium;
        }
    }
}
