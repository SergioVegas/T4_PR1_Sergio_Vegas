using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4._PR1.EnergyClasses;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace T4._PR1._Practica_1.EnegyClass
{
    public enum TypeEnergy { Solar, Eolica, Hidroelectrica }
    public  class EnergySystem : IEnergyCalculate
    {

        public DateTime DateSimulation {  get; set; }
        public TypeEnergy Name { get; set; }
        public double CostEnergy { get; set; }
        public double PriceEnergy { get; set; }
        public double Rati { get; set; }
        public double GeneratedEnergy { get;  set; }
        public double TotalPrice { set; get; }
        public double TotalCost { set; get; }
        public  EnergySystem() { }
        public EnergySystem (DateTime date, TypeEnergy name, double costEnergy,double priceEnergy, double rati, double generatedEnergy, double totalCost, double totalPrice) 
        { DateSimulation = date;  Name = name; CostEnergy = costEnergy; PriceEnergy = priceEnergy; Rati = rati; GeneratedEnergy = generatedEnergy; TotalPrice = totalPrice; TotalCost = totalCost; }
     
        public virtual double CalculateEnergy()=>0;

        public double CalculateTotalCost() => CostEnergy * GeneratedEnergy;
        public double CalculateTotalPrice()=> CostEnergy * PriceEnergy;
        public virtual string GetInfoRegistre()
        {
            return $"| {DateSimulation} |      {Name}     |    {GeneratedEnergy} Juls    |";
        }

    }
}
