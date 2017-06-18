using System;
using System.Collections.Generic;
using System.Text;

namespace iadip
{
    public class ClusterData
    {
        public ClusterData()
        {
            ParamValues = new Dictionary<int, double>();
        }

        public Dictionary<int, double> ParamValues { get; private set; }

        public void Set(int paramIndex, double value)
        {
            ParamValues[paramIndex] = value;
        }

        public double Get(int paramIndex)
        {
            if (!ParamValues.ContainsKey(paramIndex))
                throw new Exception("Param not found: " + paramIndex + "; This: " + ToString());

            return ParamValues[paramIndex];
        }

        public ClusterData Clone()
        {
            ClusterData n = new ClusterData();

            foreach (var pair in ParamValues)
                n.Set(pair.Key, pair.Value);

            return n;
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            foreach (var pair in ParamValues)
            {
                b.Append(Localization.Instance.ClusterDataParamName(pair.Key));
                b.Append(": ");
                b.AppendFormat("{0:0.00}", pair.Value);
                b.Append("; ");
            }

            return b.ToString();
        }
    }
}
