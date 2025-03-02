namespace T4_PR1.Model.EnergyClasses
{
    public class WaterConsumption
    {
        public int Year { get; set; }
        public int RegionCode { get; set; }
        public string Region { get; set; }
        public int Population { get; set; }
        public double DomesticNet { get; set; }
        public double EconomyActivity { get; set; }
        public double Total { get; set; }
        public double DomesticConsumptionCapita { get; set; }

        public override string ToString()
        {
            return $"Any: {Year}, Comarca: {Region}, Població: {Population}, Total: {Total}";
        }
    }
}
