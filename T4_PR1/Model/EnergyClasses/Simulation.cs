using System.ComponentModel.DataAnnotations;
using T4._PR1._Practica_1.EnegyClass;

namespace T4_PR1.Model.EnergyClasses
{
    public class Simulation
    {
        [Required(ErrorMessage = "La data és obligatoria")]
        public DateTime DateSimulation { get; set; }
        [Required(ErrorMessage = "El tipus d'energia es obligatori")]
        public TypeEnergy EnergyType { get; set; }
        [Required(ErrorMessage = "Aquest camp es obligatori")]
        public double EnergyNeeded { get; set; }
        [Required(ErrorMessage = "Introdueix un valor o el valor automaticament será 1")]
        public double CostEnergy { get; set; }
        [Required(ErrorMessage = "Introdueix un valor o el valor automaticament será 1")]
        public double PriceEnergy { get; set; }
        [Required(ErrorMessage = "L'any és obligatori.")]
        public double Rati { get; set; }
        public double GeneratedEnergy { get; set; }
        public double TotalPrice { set; get; }
        public double TotalCost { set; get; }
    }
}
