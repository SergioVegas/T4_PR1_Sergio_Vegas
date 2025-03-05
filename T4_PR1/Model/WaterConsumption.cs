using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace T4_PR1.Model
{
    public class WaterConsumption
    {
        [Required(ErrorMessage = "L'any és obligatori.")]
        [Name("Any")]
        public int Year { get; set; }

        [Required(ErrorMessage = "El codi de la comarca és obligatori.")]
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
