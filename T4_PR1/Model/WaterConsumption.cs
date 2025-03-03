using CsvHelper.Configuration.Attributes;

namespace T4_PR1.Model
{
    public class WaterConsumption
    {
        [Name("Any")]
        public int Year { get; set; }

        [Name("Codi comarca")]
        public int RegionCode { get; set; }

        [Name("Comarca")]
        public string? Region { get; set; }

        [Name("Població")]
        public int Population { get; set; }

        [Name("Domèstic xarxa")]
        public double DomesticNet { get; set; }

        [Name("Activitats econòmiques i fonts pròpies")]
        public double EconomyActivity { get; set; }

        [Name("Total")]
        public double Total { get; set; }

        [Name("Consum domèstic per càpita")]
        public double DomesticConsumptionCapita { get; set; }

        public override string ToString()
        {
            return $"Any: {Year}, Comarca: {Region}, Població: {Population}, Total: {Total}";
        }
    }
}
