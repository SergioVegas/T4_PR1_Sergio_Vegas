using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3._PR1.EnergyClasses;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace T3._PR1._Practica_1.EnegyClass
{
    public enum TypeEnergy { Solar, Eolica, Hidroelectrica }
    public abstract class EnergySystem : IEnergyCalculate
    {
        protected  DateTime Date {  get; set; }
        protected TypeEnergy Name { get; set; }
        protected double CostEnergy { get; set; }
        protected double PriceEnergy { get; set; }
        protected double Rati { get; set; }
        protected double GeneratedEnergy { get;  set; }
        EnergySystem() { }
        protected EnergySystem(DateTime date) { Date = date; }
        public abstract void ConfigurateParameters();
        public abstract void CalculateEnergy();
        public virtual string GetInfoRegistre()
        {
            return $"| {Date} |      {Name}     |    {GeneratedEnergy} Juls    |";
        }

    }
}
