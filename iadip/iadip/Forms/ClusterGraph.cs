using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace iadip
{
    public partial class ClusterGraph : Form
    {
        public ClusterGraph()
        {
            InitializeComponent();
        }

        public Cluster clustersData {
            get => default(Cluster);
            set {
            }
        }

        private class DPoint
        {
            public double x;
            public double y;
            public Color color;
        }

        private List<DPoint> poins;
        private List<Cluster> clusters;

        private Func<ClusterData, double> xFunc;
        private Func<ClusterData, double> yFunc;
        private Func<ClusterData, double> xFuncMax;
        private Func<ClusterData, double> yFuncMax;

        public void Init(List<Cluster> clusters)
        {
            this.clusters = clusters;

            xFunc = data => 0.5;
            yFunc = data => 0.5;
            yFuncMax = data => 1;
            xFuncMax = data => 1;

            CreatePoints();

            ClusterData example = Program.DataExample;
            foreach (var pair in example.ParamValues)
            {
                comboBoxX.Items.Add(Localization.Instance.ClusterDataParamName(pair.Key));
                comboBoxY.Items.Add(Localization.Instance.ClusterDataParamName(pair.Key));
            }

            comboBoxX.Items.Add(Localization.Instance.Get("words.constant"));
            comboBoxY.Items.Add(Localization.Instance.Get("words.constant"));
            comboBoxX.Text = Localization.Instance.Get("words.constant");
            comboBoxY.Text = Localization.Instance.Get("words.constant");
        }
        
        private ClusterData GetMax()
        {
            List<SourceDataRow> all = new List<SourceDataRow>();

            foreach (var c in clusters)
                all = all.Concat(c.Apartaments).ToList();

            return all.Select(c => c.Data).ToList().ClusterMax();
        }

        private void CreatePoints()
        {
            var max = GetMax();

            Random rand = new Random(0);
            poins = new List<DPoint>();

            foreach (var c in clusters)
            {
                Color color = Color.FromArgb(rand.Next(0, 200), rand.Next(0, 200), rand.Next(0, 200));

                foreach (var a in c.Apartaments)
                {
                    double x = xFunc(a.Data) / xFuncMax(max);
                    double y = yFunc(a.Data) / yFuncMax(max);

                    DPoint p = new DPoint();
                    p.x = x;
                    p.y = y;
                    p.color = color;
                    poins.Add(p);
                }
            }
        }

        private void Draw()
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bm;
            Graphics g = Graphics.FromImage(bm);

            foreach (var p in poins)
            {
                g.FillEllipse(new SolidBrush(p.color), (float)p.x * bm.Width, (float)p.y * bm.Height, 10, 10);
            }

            pictureBox1.Invalidate();
        }

        private void ClusterGraph_Resize(object sender, EventArgs e)
        {
            Draw();
        }

        private void ClusterGraph_Load(object sender, EventArgs e)
        {
            Draw();
        }

        private void comboBoxX_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClusterData example = Program.DataExample;

            object selection = comboBoxX.Text;
            string v = selection == null ? string.Empty : selection.ToString();
            foreach (var pair in example.ParamValues)
            {
                string name = Localization.Instance.ClusterDataParamName(pair.Key);

                if (name.Equals(v))
                {
                    int k = pair.Key;
                    xFunc = data => data.Get(k);
                    xFuncMax = xFunc;
                    CreatePoints();
                    Draw();
                    return;
                }
            }

            xFunc = data => 0.5;
            xFuncMax = data => 1;
            CreatePoints();
            Draw();
        }

        private void comboBoxY_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClusterData example = Program.DataExample;

            object selection = comboBoxY.Text;
            string v = selection == null ? string.Empty : selection.ToString();
            foreach (var pair in example.ParamValues)
            {
                string name = Localization.Instance.ClusterDataParamName(pair.Key);

                if (name.Equals(v))
                {
                    int k = pair.Key;
                    yFunc = data => data.Get(k);
                    yFuncMax = yFunc;
                    CreatePoints();
                    Draw();
                    return;
                }
            }

            yFunc = data => 0.5;
            yFuncMax = data => 1;
            CreatePoints();
            Draw();
        }
    }
}
