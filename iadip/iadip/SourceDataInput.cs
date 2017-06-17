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
    public partial class SourceDataInput : Form {

        IEstimator estimator = new SimpleEstimator();
        List<Cluster> clustersForEstimator = new List<Cluster>();

        public SourceDataInput() {
            InitializeComponent();
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
                SourceData data = new SourceData() {
                    Cost = parsedValue
                };

                Hide();
                ShowEstematedResult ser = new ShowEstematedResult();
                ser.Init(estimator.Estimate(clustersForEstimator, data), data);
                ser.ShowDialog();
                Show();
            }
        }
    }
}
