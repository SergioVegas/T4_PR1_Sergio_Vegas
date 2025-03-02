using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3._PR1.EnergyClasses;

namespace T3._PR1._Practica_1.EnegyClass
{
    public  class SolarSystem : EnergySystem
    {
        private string minimumMsg = "Les hores de sol no poden ser menors a {0}, torna a introduir un número.";
        private double _limit = 1;
        public double SunHours { get; set; }
         
        public SolarSystem(double sunHours, DateTime date) : base(date)
        {
            SunHours = sunHours;
        }
        public override void ConfigurateParameters()
        {
            while (SunHours < _limit)
            {
                Console.WriteLine(string.Format(minimumMsg, _limit));
                Console.WriteLine();
                SunHours = Tools.CheckValues.CheckTypeDouble();
            }
        }
        public  override void CalculateEnergy()
        {
            GeneratedEnergy= Math.Round(SunHours * 1.5, 2);
        }  

    }
}
