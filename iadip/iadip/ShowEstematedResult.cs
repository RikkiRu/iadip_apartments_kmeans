using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iadip {
    public partial class ShowEstematedResult : Form, IResultShower {

        IClusterOutput output = new SimpleClusterOutput();

        public ShowEstematedResult() {
            InitializeComponent();
        }

        public void Init(Cluster cluster, SourceData sourceData) {            
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
                data.Min.AreaSize, data.Max.AreaSize, 
                data.Min.RoomsCount, data.Max.RoomsCount,
                data.Min.BathroomsCount, data.Max.BathroomsCount,
                cities,
                companies,
                data.Average.AreaSize,
                data.Average.RoomsCount,
                data.Average.BathroomsCount                
                );
        }

        void Mape(ClusterOutputData clusterData, SourceData sourceData, Cluster cluster)
        {
            if (Form1.apartments == null)
                return;

            var e = cluster.Apartaments.FirstOrDefault(c => c.Data.Cost == sourceData.Cost);

            if (e == null)
                return;

            // По центру
            double centerMapeArea = Math.Abs(e.Data.AreaSize - cluster.Center.AreaSize) / e.Data.AreaSize * 100;
            double centerMapeCost = Math.Abs(e.Data.Cost - cluster.Center.Cost) / e.Data.Cost * 100;
            double centerMapeRooms = Math.Abs(e.Data.RoomsCount - cluster.Center.RoomsCount) / e.Data.RoomsCount * 100;
            double centerMapeBaths = Math.Abs(e.Data.BathroomsCount - cluster.Center.BathroomsCount) / e.Data.BathroomsCount * 100;
            double centerAvg = (centerMapeArea + centerMapeCost + centerMapeRooms + centerMapeBaths) / 4;

            // По средним
            double avgMapeArea = Math.Abs(e.Data.AreaSize - clusterData.Average.AreaSize) / e.Data.AreaSize * 100;
            double avgMapeCost = Math.Abs(e.Data.Cost - clusterData.Average.Cost) / e.Data.Cost * 100;
            double avgMapeRooms = Math.Abs(e.Data.RoomsCount - clusterData.Average.RoomsCount) / e.Data.RoomsCount * 100;
            double avgMapeBaths = Math.Abs(e.Data.BathroomsCount - clusterData.Average.BathroomsCount) / e.Data.BathroomsCount * 100;
            double avgAvg = (avgMapeArea + avgMapeCost + avgMapeRooms + avgMapeBaths) / 4;

            StringBuilder b = new StringBuilder();
            b.AppendLine();
            b.AppendLine(e.ToString());

            b.AppendFormat("MAPE центр. площадь: {0}", centerMapeArea);
            b.AppendLine();
            b.AppendFormat("MAPE центр. цена: {0}", centerMapeCost);
            b.AppendLine();
            b.AppendFormat("MAPE центр. комнаты: {0}", centerMapeRooms);
            b.AppendLine();
            b.AppendFormat("MAPE центр. ванные: {0}", centerMapeBaths);
            b.AppendLine();
            b.AppendFormat("MAPE центр. общее: {0}", centerAvg);
            b.AppendLine();

            b.AppendFormat("MAPE среднее. площадь: {0}", avgMapeArea);
            b.AppendLine();
            b.AppendFormat("MAPE среднее. цена: {0}", avgMapeCost);
            b.AppendLine();
            b.AppendFormat("MAPE среднее. комнаты: {0}", avgMapeRooms);
            b.AppendLine();
            b.AppendFormat("MAPE среднее. ванные: {0}", avgMapeBaths);
            b.AppendLine();
            b.AppendFormat("MAPE среднее. общее: {0}", avgAvg);
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
            r[keyAreaSize] = string.Format("{0:0.00}", cluster.Center.AreaSize);
            r[keyBathrooms] = string.Format("{0:0.00}", cluster.Center.BathroomsCount);
            r[keyCost] = string.Format("{0:0.00}", cluster.Center.Cost);
            r[keyRooms] = string.Format("{0:0.00}", cluster.Center.RoomsCount);
            r[keyCity] = "-";
            r[keyCompany] = "-";
            table.Rows.Add(r);

            return table;
        }

    }
}
