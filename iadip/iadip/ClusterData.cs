namespace iadip
{
    public class ClusterData
    {
        public double Cost;
        public double AreaSize;
        public double RoomsCount;
        public double BathroomsCount;

        public override string ToString()
        {
            return
                string.Format(
                    "ClusterData. Cost: {0}, AreaSize: {1}, RoomsCount: {2}, BathroomsCount: {3}",
                    Cost,
                    AreaSize,
                    RoomsCount,
                    BathroomsCount
                    );
        }
    }
}
