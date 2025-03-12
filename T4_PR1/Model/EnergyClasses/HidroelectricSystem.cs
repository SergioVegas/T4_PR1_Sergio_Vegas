using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4._PR1.EnergyClasses;

namespace T4._PR1._Practica_1.EnegyClass
{
    public class HidroelectricSystem : EnergySystem
    {
        private double waterFlow;
        private string minimumMsg = "El caudal de l'aigua no pot ser menor a {0}, torna a introduir un número.";
        private double _limit = 20;

        public double WaterFlow {
            get { return waterFlow; }
            set
            {
                if (!(value >= _limit)) throw new ArgumentException(minimumMsg);
                waterFlow = value;
            }
        }  
        public HidroelectricSystem() { }
        
       
        public override double CalculateEnergy()
        {
           return  GeneratedEnergy= Math.Round(WaterFlow * 9.8 * Rati, 2);
        }
    }
}
