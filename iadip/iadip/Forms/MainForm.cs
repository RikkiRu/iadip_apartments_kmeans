using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace iadip {
    public partial class MainForm : Form {

        IClusterize clusterize = new KMeansV2();
        IParser parser = new TxtParser();
        List<SourceDataRow> apartments;
        ClasterizeData fullData;
        List<Cluster> clusters;

        public MainForm() {
            InitializeComponent();
            TxtParser.StartReadFile += offClasterizationBtn;
            TxtParser.EndReadFile += onClasterizationBtn;
        }

        private void bLoadData_Click(object sender, EventArgs e) {
            dialogOpenDataFile.ShowDialog();
        }

        private void dialogOpenDataFile_FileOk(object sender, CancelEventArgs e)
        {
            Text = "Чтение файла...";
            fullData = parser.ReadFile(dialogOpenDataFile.FileName);
            apartments = fullData.apartments;
            Text = "Файл прочитан";
        }

        private void bTestEstimate_Click(object sender, EventArgs e) {
            if (clusters == null || clusters.Count < 1) {
                MessageBox.Show("Кластеры отсутствуют");
                return;
            }
            Hide();
            SourceDataInput di = new SourceDataInput();
            di.Init(clusters);
            di.ShowDialog();
            Show();
        }
        
        private void offClasterizationBtn() {
            bBeginClasterize.Enabled = false;
            btnShowClusters.Enabled = false;
            showClusterGraph.Enabled = false;
            bTestEstimate.Enabled = false;
            btnSummary.Enabled = false;
        }

        private void onClasterizationBtn() {
            bBeginClasterize.Enabled = true;
            btnShowClusters.Enabled = true;
            showClusterGraph.Enabled = true;
            bTestEstimate.Enabled = true;
            btnSummary.Enabled = true;
        }

        private void bBeginClasterize_Click(object sender, EventArgs e)
        {
            if (apartments == null || apartments.Count < 1)
            {
                MessageBox.Show("Апартаменты не найдены");
                return;
            }

            Text = "Кластеризация...";
            List<SourceDataRow> clusterableData = fuzy(apartments);
            clusters = clusterize.Clasterize(clusterableData);
            Text = "Кластеризация завершена";
        }

        private struct FuzyTableColumn {
            string paramName;
            public Dictionary<string, int> parametres;

            public FuzyTableColumn (string name) {
                paramName = name;
                parametres = new Dictionary<string, int>();
            }
        }
        private struct DefuzyTableColumn {
            string paramName;
            public Dictionary<int, string> parametres;

            public DefuzyTableColumn (string name) {
                paramName = name;
                parametres = new Dictionary<int, string>();
            }
        }

        private Dictionary<int, string> param = new Dictionary<int, string>();
        private List<FuzyTableColumn> paramList = new List<FuzyTableColumn>();
        private List<DefuzyTableColumn> defuzyList = new List<DefuzyTableColumn>();

        private List<SourceDataRow> fuzy (List<SourceDataRow> data) {
            foreach (var i in fullData.titles) {
                paramList.Add(new FuzyTableColumn(i));
                defuzyList.Add(new DefuzyTableColumn(i));
            }

            List<SourceDataRow> fuzied = new List<SourceDataRow>();
            foreach (var i in data) {
                SourceDataRow temp = new SourceDataRow();
                for (int j = 0; j < i.OtherData.Count; j++) {
                    double parsedResult = 0;
                    //if (i.OtherData[j] == "") {
                    //    i.OtherData[j] = "0";
                    //}
                    if (Double.TryParse(i.OtherData[j], out parsedResult)) {
                        temp.Data.Set(j, parsedResult);
                    } else {
                        if (paramList[j].parametres.ContainsKey(i.OtherData[j])) {
                            temp.Data.Set(j, paramList[j].parametres[i.OtherData[j]]);
                        } else {
                            paramList[j].parametres.Add(i.OtherData[j], paramList[j].parametres.Count+1);
                            defuzyList[j].parametres.Add(defuzyList[j].parametres.Count+1, i.OtherData[j]);
                            temp.Data.Set(j, paramList[j].parametres[i.OtherData[j]]);
                        }
                    }
                }
                fuzied.Add(temp);
            }
            return fuzied;
        }

        private List<Cluster> defuzy (List<Cluster> clusters) {
            List<Cluster> defuzied = new List<Cluster>();

            foreach (var i in clusters) {
                Cluster temp = new Cluster();
                temp.Apartaments = new List<SourceDataRow>(i.Apartaments);
                temp.Center = i.Center.Clone();
                for (int j = 0; j < i.Apartaments.Count; j++) {
                    for (int k = 0; k < i.Apartaments[j].Data.ParamValues.Count; k++) {
                        try {
                            temp.Apartaments[j].SetOtherData(k, defuzyList[k].parametres[(int)i.Apartaments[j].Data.Get(k)]);
                        } catch (Exception e) {
                            temp.Apartaments[j].SetOtherData(k, i.Apartaments[j].Data.Get(k).ToString());
                        }
                        //Добавить айди для строк вместо названий.
                        //Разобраться с дефазификацией.
                    }
                }
                defuzied.Add(temp);
            }

            return defuzied;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            TxtParser.StartReadFile -= offClasterizationBtn;
            TxtParser.EndReadFile -= onClasterizationBtn;
        }

        private void btnShowClusters_Click(object sender, EventArgs e)
        {
            if (clusters == null || clusters.Count < 1)
            {
                MessageBox.Show("Кластеров нет");
                return;
            }

            Hide();
            ShowClusters w = new ShowClusters();
            w.Init(defuzy(clusters));
            w.ShowDialog();
            Show();
        }

        private void showClusterGraph_Click(object sender, EventArgs e)
        {
            if (clusters == null || clusters.Count < 1)
            {
                MessageBox.Show("Кластеров нет");
                return;
            }

            Hide();
            ClusterGraph w = new ClusterGraph();
            w.Init(clusters);
            w.ShowDialog();
            Show();
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            if (clusters == null || clusters.Count < 1)
            {
                MessageBox.Show("Кластеров нет");
                return;
            }

            Hide();
            Summary w = new Summary();
            w.Init(clusters);
            w.ShowDialog();
            Show();
        }

        public Cluster clustersData {
            get => default(Cluster);
            set {
            }
        }

        public TxtParser parserData {
            get => default(TxtParser);
            set {
            }
        }

        internal KMeansV2 clusterizeData {
            get => default(KMeansV2);
            set {
            }
        }

        public ClasterizeData FullDataListData {
            get => default(ClasterizeData);
            set {
            }
        }

        public SourceDataRow apartmentsListData {
            get => default(SourceDataRow);
            set {
            }
        }
    }
}
