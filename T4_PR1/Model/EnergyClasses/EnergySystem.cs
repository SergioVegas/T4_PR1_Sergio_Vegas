using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3._PR1._Practica_1.EnegyClass
{
    public abstract class EnergySystem
    {
        protected abstract DateTime Date {  get; set; }

        protected EnergySystem(DateTime date) { Date = date; }
        public abstract void ShowEnergyCalculated( double energy);
    }
}
