using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace iadip {
    public partial class Form1 : Form {

        IClusterize clusterize = new KMeansV2();
        IParser parser = new TxtParser();
        List<SourceDataRow> apartments;
        List<Cluster> clusters;

        public Form1() {
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
            apartments = parser.ReadFile(dialogOpenDataFile.FileName);
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
            clusters = clusterize.Clasterize(apartments);
            Text = "Кластеризация завершена";
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
            w.Init(clusters);
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
    }
}
