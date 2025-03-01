using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3._PR1.EnergyClasses;

namespace T3._PR1._Practica_1.EnegyClass
{
    public class HidroelectricSystem : EnergySystem, IEnergyCalculate
    {
        private string minimumMsg = "El caudal de l'aigua no pot ser menor a {0}, torna a introduir un número.";
        private double _limit = 20;
        public double WaterFlow {  get; set; }       
        public HidroelectricSystem(double waterFlow, DateTime date): base(date)
        {
            while (waterFlow < _limit)
            {
                Console.WriteLine(string.Format(minimumMsg, _limit));
                Console.WriteLine();
                waterFlow = Tools.CheckTypeDouble();
            }
            WaterFlow = waterFlow;
        }
        public double CalculateEnergy(double energy)
        {
            return Math.Round(energy * 9.8 * 0.8, 2);
        }
        public override void ShowEnergyCalculated(double energy)
        {
            Console.WriteLine();
            Console.WriteLine($"La energia calculada és {energy} Juls");
        }
        public string GetInfoRegistre (DateTime data, double resultenergy )
        {
            return $"| {data}  |   Hidroelèctric   |    {resultenergy} Juls    |";
        }

    }
}
