using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3._PR1.EnergyClasses;

namespace T3._PR1._Practica_1.EnegyClass
{
    public class WindSystem : EnergySystem
    {

        private string minimumMsg = "La velocitat del vent no pot ser menor a {0}, torna a introduir un número.";
        private double _limit =5;
        public double WindVelocity { get; set; }

        public WindSystem (double windVelocity, DateTime date) : base(date)
        {
            WindVelocity = WindVelocity;
        }
        public override void ConfigurateParameters()
        {
            while (WindVelocity < _limit)
            {
                Console.WriteLine(string.Format(minimumMsg, _limit));
                Console.WriteLine();
                WindVelocity = Tools.CheckValues.CheckTypeDouble();
            } 
        }
        public override void CalculateEnergy( )
        {
            GeneratedEnergy= Math.Round(Math.Pow(WindVelocity, 3) * Rati); 
        }
       
        public override bool Equals(object? obj) 
        {
            if (obj == null) return false;
            if (!(obj is WindSystem)) return false;

            return (this.WindVelocity == ((WindSystem)obj).WindVelocity) && (this.Date ==((WindSystem)obj).Date);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(WindVelocity, Date);
        }
        public override string ToString()
        {
            return $"Es {WindVelocity} i {Date}";
        }

    }
}
