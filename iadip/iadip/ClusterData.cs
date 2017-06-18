namespace iadip
{
    public class ClusterData
    {
        public double P1;
        public double P2;
        public double P3;
        public double P4;

        public override string ToString()
        {
            return
                string.Format(
                    "ClusterData. P1: {0}, P2: {1}, P3: {2}, P4: {3}",
                    P1,
                    P2,
                    P3,
                    P4
                    );
        }
    }
}
