using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3._PR1.EnergyClasses
{
    interface  IEnergyCalculate
    {
        void CalculateEnergy();
        void ConfigurateParameters();
        string GetInfoRegistre();
    }
}
