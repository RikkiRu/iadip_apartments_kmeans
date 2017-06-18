﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iadip
{
    public partial class Summary : Form
    {
        IClusterOutput output = new SimpleClusterOutput();

        public Summary()
        {
            InitializeComponent();
        }

        public void Init(List<Cluster> clusters)
        {
            int elements = 0;

            int indexBigCluster = -1;
            int elementsBigCluster = int.MinValue;
            int indexSmallCluster = -1;
            int elemtntsSmallCluster = int.MaxValue;

            List<SourceDataRow> all = new List<SourceDataRow>();

            for (int i = 0; i < clusters.Count; i++)
            {
                Cluster c = clusters[i];

                all = all.Concat(c.Apartaments).ToList();

                elements += c.Apartaments.Count;

                if (elementsBigCluster < c.Apartaments.Count)
                {
                    indexBigCluster = i;
                    elementsBigCluster = c.Apartaments.Count;
                }

                if (elemtntsSmallCluster > c.Apartaments.Count)
                {
                    indexSmallCluster = i;
                    elemtntsSmallCluster = c.Apartaments.Count;
                }
            }

            StringBuilder b = new StringBuilder();
            b.AppendLine("Общая характеристика кластеров");
            b.AppendLine();
            b.AppendFormat("Общее количество исследуемых объектов равно {0}. Количество кластеров равно {1}.", elements, clusters.Count);
            b.AppendLine();
            b.AppendFormat("Большинство объектов ({0}) сгруппированы в кластере {1}.", elementsBigCluster, indexBigCluster);
            b.AppendLine();
            b.AppendFormat("Наименьшее количество объектов ({0}) сгруппированы в кластере {1}.", elemtntsSmallCluster, indexSmallCluster);
            b.AppendLine();
            b.AppendLine();

            for (int i = 0; i < clusters.Count; i++)
            {
                Cluster c = clusters[i];
                b.AppendFormat("***** Информация по кластеру {0} *****", i);
                b.AppendLine();
                b.AppendLine();

                ClusterOutputData data = output.Calculate(c);

                b.AppendFormat("Минимальная площадь {0}", data.Min.P2);
                b.AppendLine();
                b.AppendFormat("Средняя площадь {0:0.00}", c.Center.P2);
                b.AppendLine();
                b.AppendFormat("Максимальная площадь {0}", data.Max.P2);
                b.AppendLine();
                b.AppendLine();

                b.AppendFormat("Минимальное число ванн {0}", data.Min.P4);
                b.AppendLine();
                b.AppendFormat("Среднее число ванн {0:0.00}", c.Center.P4);
                b.AppendLine();
                b.AppendFormat("Максимальное число ванн {0}", data.Max.P4);
                b.AppendLine();
                b.AppendLine();

                b.AppendFormat("Минимальная цена {0}", data.Min.P1);
                b.AppendLine();
                b.AppendFormat("Средняя цена {0:0.00}", c.Center.P1);
                b.AppendLine();
                b.AppendFormat("Максимальная цена {0}", data.Max.P1);
                b.AppendLine();
                b.AppendLine();

                b.AppendFormat("Минимальнаое число комнат {0}", data.Min.P3);
                b.AppendLine();
                b.AppendFormat("Среднее число комнат {0:0.00}", c.Center.P3);
                b.AppendLine();
                b.AppendFormat("Максимальное число комнат {0}", data.Max.P3);
                b.AppendLine();
                b.AppendLine();
            }

            richTextBox1.Text = b.ToString();

            grid.DataSource = GetResultsTable(clusters, elements, all);
        }

        DataTable GetResultsTable(List<Cluster> clusters, int totalElems, List<SourceDataRow> all)
        {
            ClusterData globalMax = all.Select(c => c.Data).ToList().ClusterMax();

            DataTable table = new DataTable();
            string keyId = "ID";
            string keyElements = "Элементы";
            string keyAreaSize = "Площадь";
            string keyBathrooms = "Ванные";
            string keyCost = "Цена";
            string keyRooms = "Комнаты";

            table.Columns.Add(keyId);
            table.Columns.Add(keyElements);
            table.Columns.Add(keyCost);
            table.Columns.Add(keyAreaSize);
            table.Columns.Add(keyRooms);
            table.Columns.Add(keyBathrooms);

            DataRow r = null;

            for (int i = 0; i < clusters.Count; i++)
            {
                Cluster c = clusters[i];

                r = table.NewRow();
                r[keyId] = "Кластер " + i.ToString();
                double percent = (double)c.Apartaments.Count / totalElems * 100; 
                r[keyElements] = string.Format("{0:0.00}% ({1})", percent, c.Apartaments.Count);
                table.Rows.Add(r);

                double relativeAreaSize = c.Center.P2 / globalMax.P2;
                double relativeBaths = c.Center.P4 / globalMax.P4;
                double relativeCost = c.Center.P1 / globalMax.P1;
                double relativeRooms = c.Center.P3 / globalMax.P3;

                r[keyAreaSize] = GetLingvisticEstimate(relativeAreaSize, 0.3, 0.7, "Маленькая", "Средняя", "Большая");
                r[keyBathrooms] = GetLingvisticEstimate(relativeBaths, 0.3, 0.7, "Мало", "Нормально", "Много");
                r[keyCost] = GetLingvisticEstimate(relativeCost, 0.3, 0.7, "Дёшево", "Нормально", "Дорого");
                r[keyRooms] = GetLingvisticEstimate(relativeRooms, 0.3, 0.7, "Мало", "Нормально", "Много");
            }

            return table;
        }

        public string GetLingvisticEstimate(double v, double small, double big, string wordSmall, string wordMedium, string wordBig)
        {
            if (v < small)
                return wordSmall;

            if (v > big)
                return wordBig;

            return wordMedium;
        }
    }
}
