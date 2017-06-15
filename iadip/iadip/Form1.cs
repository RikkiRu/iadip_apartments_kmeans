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
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            dialogOpenDataFile.ShowDialog();
        }

        private void dialogOpenDataFile_FileOk(object sender, CancelEventArgs e) {
            IParser parser = new TxtParser();
            List<Apartament> apartments = parser.ReadFile(dialogOpenDataFile.FileName);
        }

        private void bTestEstimate_Click(object sender, EventArgs e) {
            double[] costs = new double [1000];
            for (int i = 0; i < costs.Length; i++) {
                costs[i] = i;
            }
            List<Cluster> clusters = new List<Cluster>();
            clusters.Add(new Cluster() {
                Center = new ClusterData() {
                    Cost = 500
                }
            });
            clusters.Add(new Cluster() {
                Center = new ClusterData() {
                    Cost = 700
                }
            });
            clusters.Add(new Cluster() {
                Center = new ClusterData() {
                    Cost = 100
                }
            });
            clusters.Add(new Cluster() {
                Center = new ClusterData() {
                    Cost = 300
                }
            });
            clusters.Add(new Cluster() {
                Center = new ClusterData() {
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
    }
}
