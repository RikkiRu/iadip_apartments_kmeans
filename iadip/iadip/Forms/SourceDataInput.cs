using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace iadip
{
    public partial class SourceDataInput : Form {

        IEstimator estimator = new SimpleEstimator();
        List<Cluster> clustersForEstimator = new List<Cluster>();

        public SourceDataInput() {
            InitializeComponent();

            labelInputText.Text = Localization.Instance.Get("param.label.enterOptionValue");
            buttonStart.Text = Localization.Instance.Get("param.label.startEstimateProcessButton");
        }

        internal SimpleEstimator estimatorData {
            get => default(SimpleEstimator);
            set {
            }
        }

        public Cluster clustersForEstimatorListData {
            get => default(Cluster);
            set {
            }
        }

        public void Init(List<Cluster> clusters) {
            clustersForEstimator = clusters;
        }

        private void buttonStart_Click(object sender, EventArgs e) {
            double parsedValue = 0;
            if (!Double.TryParse(tbInput.Text, out parsedValue)) {
                MessageBox.Show("Неверное значение, введите число");
                return;
            } else {
                ClusterSearchOptions data = new ClusterSearchOptions() {
                    ParamValue = parsedValue
                };

                Hide();
                ShowEstematedResult ser = new ShowEstematedResult();
                ser.Init(estimator.Estimate(clustersForEstimator, data), data);
                ser.ShowDialog();
                Close();
            }
        }
    }
}
