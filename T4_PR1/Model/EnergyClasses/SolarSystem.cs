using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3._PR1.EnergyClasses;

namespace T3._PR1._Practica_1.EnegyClass
{
    public  class SolarSystem : EnergySystem, IEnergyCalculate
    {
        private string minimumMsg = "Les hores de sol no poden ser menors a {0}, torna a introduir un número.";
        private double _limit = 1;
        public double SunHours { get; set; }
         
        public SolarSystem(double sunHours, DateTime date) : base(date)
        {
            while (sunHours < _limit)
            {
                Console.WriteLine(string.Format(minimumMsg, _limit));
                Console.WriteLine();
                sunHours = Tools.CheckValues.CheckTypeDouble();
            }
            SunHours = sunHours;
        }
        public  double CalculateEnergy(double energy)
        {
            return Math.Round(energy * 1.5, 2);
        }  
        public override void ShowEnergyCalculated(double energy)
        {
            Console.WriteLine();
            Console.WriteLine($"La energia calculada és {energy} Juls");
        }
        public string GetInfoRegistre(DateTime data, double resultenergy)
        {
            return $"| {data} |       Solar       |    {resultenergy} Juls    |";
        }
    }
}
