using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4._PR1.EnergyClasses;

namespace T4._PR1._Practica_1.EnegyClass
{
    public class HidroelectricSystem : EnergySystem
    {

        [Required, Range(20, double.MaxValue, ErrorMessage = "El caudal de l'aigua no pot ser menor a 20, torna a introduir un número.")]
        public double WaterFlow { set; get; }
        //Constructor amb més carga logica
        public HidroelectricSystem(double waterFlow, DateTime date, TypeEnergy name, double costEnergy, double priceEnergy, double rati, double generatedEnergy, double totalCost, double totalPrice) : base(date, name, costEnergy, priceEnergy, rati, generatedEnergy, totalCost, totalPrice)
        {
            WaterFlow = waterFlow;
        }
        public HidroelectricSystem() { }
        
       
        public override double CalculateEnergy()
        {
           return Math.Round(WaterFlow * 9.8 * Rati, 2);
        }
    }
}
