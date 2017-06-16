using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace iadip {
    public partial class Form1 : Form {

        IClusterize clusterize = new KMeansV2();
        IParser parser = new TxtParser();
        List<Apartament> apartments;
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
            Text = "Reading file...";
            apartments = parser.ReadFile(dialogOpenDataFile.FileName);
            Text = "File readed";
        }

        private void bTestEstimate_Click(object sender, EventArgs e) {
            double[] costs = new double [1000];
            for (int i = 0; i < costs.Length; i++) {
                costs[i] = i;
            }
            List<Cluster> clusters = new List<Cluster>();
            clusters.Add(new Cluster() {
                Center = new ClusterDataLerp() {
                    Cost = 500
                }
            });
            clusters.Add(new Cluster() {
                Center = new ClusterDataLerp() {
                    Cost = 700
                }
            });
            clusters.Add(new Cluster() {
                Center = new ClusterDataLerp() {
                    Cost = 100
                }
            });
            clusters.Add(new Cluster() {
                Center = new ClusterDataLerp() {
                    Cost = 300
                }
            });
            clusters.Add(new Cluster() {
                Center = new ClusterDataLerp() {
                    Cost = 900
                }
            });
            IEstimator estimator = new SimpleEstimator();
            Cluster result = new Cluster();
            Dictionary<double, double> dict = new Dictionary<double, double>();
            foreach (var i in costs) {
                result = estimator.Estimate(clusters, new SourceData() { Cost = i });
                dict.Add(i, result.Center.Cost);
            }
        }
        
        private void offClasterizationBtn() { bBeginClasterize.Visible = false; }
        private void onClasterizationBtn() { bBeginClasterize.Visible = true; }

        private void bBeginClasterize_Click(object sender, EventArgs e)
        {
            if (apartments == null || apartments.Count < 1)
            {
                MessageBox.Show("Апартаменты не найдены");
                return;
            }

            Text = "Clusterizing...";
            clusters = clusterize.Clasterize(apartments);
            Text = "Clusterized";
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

            ShowClusters w = new ShowClusters();
            w.Init(clusters);
            w.ShowDialog();
        }
    }
}
