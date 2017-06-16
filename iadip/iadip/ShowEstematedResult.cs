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

        public void Init(Cluster cluster) {            
            gridResultCluster.DataSource = GetResultsTable(cluster);
            (this as IResultShower).Show(output.Calculate(cluster));
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
