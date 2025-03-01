using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3._PR1.EnergyClasses
{
    interface  IEnergyCalculate
    {
        public abstract double CalculateEnergy(double energy);
        public abstract void ConfigurarParametres(double energy);
        public abstract void MostrarInforme(double energy);
    }
}
