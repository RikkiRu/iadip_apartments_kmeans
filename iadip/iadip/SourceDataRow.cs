using System;
using System.Collections.Generic;

namespace iadip
{
    public class SourceDataRow
    {
        public ClusterData Data;
        public int Id;
        public Dictionary<int, string> OtherData { get; private set; }

        public string GetOtherData(int index)
        {
            if (!OtherData.ContainsKey(index))
                throw new Exception("Other data not found: " + index);

            return OtherData[index];
        }

        public void SetOtherData(int index, string v)
        {
            OtherData[index] = v;
        }

        public override string ToString()
        {
            string log = string.Format("ID: {0}; DATA: {1}", Id, Data.ToString());
            foreach(var i in OtherData)
                log += Localization.Instance.AdditonalDataName(i.Key) + ": " + i.Value + "; ";

            return log;
        }

        public SourceDataRow() {
            Data = new ClusterData();
            OtherData = new Dictionary<int, string>();
        }

        public SourceDataRow(SourceDataRow row)
        {
            Data = row.Data.Clone();
            Id = row.Id;
            OtherData = new Dictionary<int, string>();

            foreach (var i in row.OtherData)
                SetOtherData(i.Key, i.Value);
        }
    }
}
