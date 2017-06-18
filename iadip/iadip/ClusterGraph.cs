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

            xFunc = data => (double)data.P1;
            yFunc = data => (double)data.P2;
            xFuncMax = xFunc;
            yFuncMax = yFunc;

            CreatePoints();
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

        private void btnXCost_Click(object sender, EventArgs e)
        {
            xFunc = data => (double)data.P1;
            xFuncMax = xFunc;
            CreatePoints();
            Draw();
        }

        private void btnXArea_Click(object sender, EventArgs e)
        {
            xFunc = data => (double)data.P2;
            xFuncMax = xFunc;
            CreatePoints();
            Draw();
        }

        private void btnXBath_Click(object sender, EventArgs e)
        {
            xFunc = data => (double)data.P4;
            xFuncMax = xFunc;
            CreatePoints();
            Draw();
        }

        private void btnXRooms_Click(object sender, EventArgs e)
        {
            xFunc = data => (double)data.P3;
            xFuncMax = xFunc;
            CreatePoints();
            Draw();
        }

        private void btnYCost_Click(object sender, EventArgs e)
        {
            yFunc = data => (double)data.P1;
            yFuncMax = yFunc;
            CreatePoints();
            Draw();
        }

        private void btnYArea_Click(object sender, EventArgs e)
        {
            yFunc = data => (double)data.P2;
            yFuncMax = yFunc;
            CreatePoints();
            Draw();
        }

        private void btnYBath_Click(object sender, EventArgs e)
        {
            yFunc = data => (double)data.P4;
            yFuncMax = yFunc;
            CreatePoints();
            Draw();
        }

        private void btnYRooms_Click(object sender, EventArgs e)
        {
            yFunc = data => (double)data.P3;
            yFuncMax = yFunc;
            CreatePoints();
            Draw();
        }

        private void btnXConst_Click(object sender, EventArgs e)
        {
            xFunc = data => 0.5;
            xFuncMax = data => 1;
            CreatePoints();
            Draw();
        }

        private void btnYConst_Click(object sender, EventArgs e)
        {
            yFunc = data => 0.5;
            yFuncMax = data => 1;
            CreatePoints();
            Draw();
        }
    }
}
