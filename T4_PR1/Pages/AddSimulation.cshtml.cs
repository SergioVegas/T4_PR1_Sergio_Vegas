using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using T4._PR1._Practica_1.EnegyClass;
using T4_PR1.Model.EnergyClasses;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace T4_PR1.Pages
{
    public class AddSimulationModel : PageModel
    {
        private static readonly string fileCSVPath = Path.Combine("ModelData", "simulations.csv");
        [BindProperty]
        public string EnergySelected { get; set; }
        [BindProperty]
        public EnergySystem SistemaEnergia { get; set; } 

        [BindProperty]
        public SolarSystem SistemaSolar { get; set; }

        [BindProperty]
        public WindSystem SistemaEolic { get; set; }

        [BindProperty]
        public HidroelectricSystem SistemaHidroelectric { get; set; }

        public List<SelectListItem> Options { get; set; }

        

        public void OnGet()
        {
            // Inicialitza les opcions del desplegable
            Options = new List<SelectListItem>
            {
                new SelectListItem { Value = "solar", Text = "Sitema solar" },
                new SelectListItem { Value = "wind", Text = "Sistema hidroelectric" },
                new SelectListItem { Value = "hidro", Text = "Sistema eolic" }
            };
        }

        public IActionResult OnPost()
        {
            Simulation simulacio;
            switch (EnergySelected)
            {
                case "solar":
                    simulacio = new Simulation
                    {
                        DateSimulation = SistemaEnergia.DateSimulation,
                        EnergyType = TypeEnergy.Solar,
                        EnergyNeeded = SistemaSolar.SunHours,
                        CostEnergy = SistemaEnergia.CostEnergy,
                        PriceEnergy = SistemaEnergia.PriceEnergy,
                        Rati = SistemaEnergia.Rati,
                        GeneratedEnergy = SistemaEnergia.CalculateEnergy(),
                        TotalPrice = SistemaEnergia.CalculateTotalPrice(),
                        TotalCost = SistemaEnergia.CalculateTotalCost()
                    };

                    break;
                case "wind":
                     simulacio = new Simulation
                    {
                        DateSimulation = SistemaEnergia.DateSimulation,
                        EnergyType = TypeEnergy.Eolica,
                        EnergyNeeded = SistemaEolic.WindVelocity,
                        CostEnergy = SistemaEnergia.CostEnergy,
                        PriceEnergy = SistemaEnergia.PriceEnergy,
                        Rati = SistemaEnergia.Rati,
                        GeneratedEnergy = SistemaEolic.CalculateEnergy(),
                        TotalPrice = SistemaEnergia.CalculateTotalPrice(),
                        TotalCost = SistemaEnergia.CalculateTotalCost()
                    };
                    break;
                case "hidro":
                    simulacio = new Simulation
                    {
                        DateSimulation = SistemaEnergia.DateSimulation,
                        EnergyType = TypeEnergy.Hidroelectrica,
                        EnergyNeeded = SistemaHidroelectric.WaterFlow,
                        CostEnergy = SistemaEnergia.CostEnergy,
                        PriceEnergy = SistemaEnergia.PriceEnergy,
                        Rati = SistemaEnergia.Rati,
                        GeneratedEnergy = SistemaHidroelectric.CalculateEnergy(),
                        TotalPrice = SistemaEnergia.CalculateTotalPrice(),
                        TotalCost = SistemaEnergia.CalculateTotalCost()
                    };
                    break;
                default:
                    return Page();
            }
          
            System.IO.Directory.CreateDirectory("Files");

            var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = !System.IO.File.Exists(fileCSVPath),
                Delimiter = ";"
            };

            using (var stream = new StreamWriter(fileCSVPath, append: true))
            using (var csv = new CsvWriter(stream, config))
            {
                if (config.HasHeaderRecord)
                {
                    csv.WriteHeader<Simulation>();
                    csv.NextRecord();
                }
                csv.WriteRecord(simulacio);
                csv.NextRecord();
            }

            return RedirectToPage("/Simulations");

        }
    }
}
