using System;
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
            string cities = "";
            string companies = "";
            foreach(var i in data.Cities) {
                cities += i + "; ";
            }
            foreach (var i in data.Companies) {
                companies += i + "; ";
            }
            tbResult.Text = string.Format("{0,-50}{1,50}" + Environment.NewLine, "Возможные параметры квартиры: ", "Средние параметры квартиры: ");
            tbResult.Text += string.Format(
                "-Площадь: {0} - {1}кв.м\t\t\t\t-Площадь: {8}кв.м\n" + Environment.NewLine +
                "-Количество комнат: {2} - {3}шт.\t\t\t-Количество комнат: {9}шт.\n" + Environment.NewLine +
                "-Количество ванных комнат: {4} - {5}шт.\t\t\t-Количество ванных комнат: {10}шт.\n" + Environment.NewLine + Environment.NewLine +
                "-Города: {6}\n" + Environment.NewLine +
                "-Компании: {7}\n",
                data.Min.P2, data.Max.P2, 
                data.Min.P3, data.Max.P3,
                data.Min.P4, data.Max.P4,
                cities,
                companies,
                data.Average.P2,
                data.Average.P3,
                data.Average.P4                
                );
        }

        void Mape(ClusterOutputData clusterData, ClusterSearchOptions sourceData, Cluster cluster)
        {
            var e = cluster.Apartaments.FirstOrDefault(c => c.Data.P1 == sourceData.P1);

            if (e == null)
                return;

            // По центру
            double centerMapeArea = Math.Abs(e.Data.P2 - cluster.Center.P2) / e.Data.P2 * 100;
            double centerMapeCost = Math.Abs(e.Data.P1 - cluster.Center.P1) / e.Data.P1 * 100;
            double centerMapeRooms = Math.Abs(e.Data.P3 - cluster.Center.P3) / e.Data.P3 * 100;
            double centerMapeBaths = Math.Abs(e.Data.P4 - cluster.Center.P4) / e.Data.P4 * 100;
            double centerAvg = (centerMapeArea + centerMapeCost + centerMapeRooms + centerMapeBaths) / 4;

            // По средним
            double avgMapeArea = Math.Abs(e.Data.P2 - clusterData.Average.P2) / e.Data.P2 * 100;
            double avgMapeCost = Math.Abs(e.Data.P1 - clusterData.Average.P1) / e.Data.P1 * 100;
            double avgMapeRooms = Math.Abs(e.Data.P3 - clusterData.Average.P3) / e.Data.P3 * 100;
            double avgMapeBaths = Math.Abs(e.Data.P4 - clusterData.Average.P4) / e.Data.P4 * 100;
            double avgAvg = (avgMapeArea + avgMapeCost + avgMapeRooms + avgMapeBaths) / 4;

            StringBuilder b = new StringBuilder();
            b.AppendLine();
            b.AppendLine();
            b.AppendLine(e.ToString());

            b.AppendFormat("MAPE центр. площадь: {0:0.00}", centerMapeArea);
            b.AppendLine();
            b.AppendFormat("MAPE центр. цена: {0:0.00}", centerMapeCost);
            b.AppendLine();
            b.AppendFormat("MAPE центр. комнаты: {0:0.00}", centerMapeRooms);
            b.AppendLine();
            b.AppendFormat("MAPE центр. ванные: {0:0.00}", centerMapeBaths);
            b.AppendLine();
            b.AppendFormat("MAPE центр. общее: {0:0.00}", centerAvg);
            b.AppendLine();

            b.AppendFormat("MAPE среднее. площадь: {0:0.00}", avgMapeArea);
            b.AppendLine();
            b.AppendFormat("MAPE среднее. цена: {0:0.00}", avgMapeCost);
            b.AppendLine();
            b.AppendFormat("MAPE среднее. комнаты: {0:0.00}", avgMapeRooms);
            b.AppendLine();
            b.AppendFormat("MAPE среднее. ванные: {0:0.00}", avgMapeBaths);
            b.AppendLine();
            b.AppendFormat("MAPE среднее. общее: {0:0.00}", avgAvg);
            b.AppendLine();

            tbResult.Text += b.ToString();
        }

        DataTable GetResultsTable(Cluster cluster) {
            DataTable table = new DataTable();

            string keyCluster = "Cluster";
            string keyAreaSize = "Area size";
            string keyBathrooms = "Bathrooms";
            string keyCost = "Cost";
            string keyRooms = "Rooms";
            string keyCity = "City";
            string keyCompany = "Company";

            table.Columns.Add(keyCluster);
            table.Columns.Add(keyCost);
            table.Columns.Add(keyAreaSize);
            table.Columns.Add(keyRooms);
            table.Columns.Add(keyBathrooms);
            table.Columns.Add(keyCity);
            table.Columns.Add(keyCompany);

            DataRow r = null;

            r = table.NewRow();
            r[keyCluster] = "CENTER";
            r[keyAreaSize] = string.Format("{0:0.00}", cluster.Center.P2);
            r[keyBathrooms] = string.Format("{0:0.00}", cluster.Center.P4);
            r[keyCost] = string.Format("{0:0.00}", cluster.Center.P1);
            r[keyRooms] = string.Format("{0:0.00}", cluster.Center.P3);
            r[keyCity] = "-";
            r[keyCompany] = "-";
            table.Rows.Add(r);

            return table;
        }

    }
}
