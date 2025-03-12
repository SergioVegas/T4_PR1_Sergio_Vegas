using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4._PR1.EnergyClasses;

namespace T4._PR1._Practica_1.EnegyClass
{
    public class WindSystem : EnergySystem
    {
        private double windVelocity;
        private string minimumMsg = "La velocitat del vent no pot ser menor a {0}, torna a introduir un número.";
        private double _limit =5;
        public double WindVelocity {
            get { return windVelocity; }
            set
            {
                if (!(value >= _limit)) throw new ArgumentException(minimumMsg);
                windVelocity = value;
            }
        }
        public WindSystem() { }
      
        
        public override double CalculateEnergy( )
        {
           return  GeneratedEnergy= Math.Round(Math.Pow(WindVelocity, 3) * Rati); 
        }
              
        public override string ToString()
        {
            return $"Es {WindVelocity} i {DateSimulation}";
        }

    }
}
