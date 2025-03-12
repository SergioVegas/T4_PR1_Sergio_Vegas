﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4._PR1.EnergyClasses;

namespace T4._PR1._Practica_1.EnegyClass
{
    public class WindSystem : EnergySystem
    {
        [Required, Range(5, double.MaxValue, ErrorMessage = "La velocitat del vent no pot ser menor a 5, torna a introduir un número.")]
        public double WindVelocity { set; get; }

        //Constructor amb més carga logica
        public WindSystem(double windVelocity, DateTime date, TypeEnergy name, double costEnergy, double priceEnergy, double rati, double generatedEnergy, double totalCost, double totalPrice) : base(date, name, costEnergy, priceEnergy, rati, generatedEnergy, totalCost, totalPrice)
        {
            WindVelocity = windVelocity;
        }
        public WindSystem() { }
      
        
        public override double CalculateEnergy( )
        {
           return  GeneratedEnergy= Math.Round(Math.Pow(WindVelocity, 3) * Rati); 
        }
    }
}
