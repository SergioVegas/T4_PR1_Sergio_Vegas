using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4._PR1.EnergyClasses;

namespace T4._PR1._Practica_1.EnegyClass
{
    public  class SolarSystem : EnergySystem
    {
        private double sunHours;
        private string minimumMsg = "Les hores de sol no poden ser menors a {0}, torna a introduir un número.";
        private double _limit = 1;
        public double SunHours {
            get { return sunHours; }
            set
            {
                if (!(value >= _limit)) throw new ArgumentException(minimumMsg);
                sunHours = value;
            }
        }

        public SolarSystem() { }

        public SolarSystem(double sunHours, DateTime date, TypeEnergy name, double costEnergy, double priceEnergy, double rati, double generatedEnergy, double totalCost, double totalPrice) :base(date, name, costEnergy, priceEnergy, rati, generatedEnergy, totalCost, totalPrice)
        {
            SunHours = sunHours;
        }
        public  override double CalculateEnergy()
        {
            return GeneratedEnergy= Math.Round(SunHours * Rati, 2);
        }  

    }
}
