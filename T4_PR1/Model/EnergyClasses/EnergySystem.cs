using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3._PR1.EnergyClasses;

namespace T3._PR1._Practica_1.EnegyClass
{
    public abstract class EnergySystem : IEnergyCalculate
    {
        protected abstract DateTime Date {  get; set; }
        protected abstract string Name { get; set; }
        protected EnergySystem() { }
        protected EnergySystem(DateTime date) { Date = date; }
        public abstract void ShowEnergyCalculated( double energy);

        public abstract void ConfigurarParametres();
        public abstract void CalcularEnergia();
      
    }
}
