using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T4_PR1.Model;
using CsvHelper.Configuration;
using CsvHelper;

namespace T4_PR1.Pages
{
    public class WaterConsumptionModel : PageModel
    {
        private readonly ILogger<WaterConsumptionModel> _logger;
        public WaterConsumptionModel(ILogger<WaterConsumptionModel> logger)
        {
            _logger = logger;
        }

        public List<WaterConsumption> WaterConsumptions { get; set; } = new List<WaterConsumption>();
        public List<WaterConsumption> CurrentPageWaterConsumptions { get; set; } = new List<WaterConsumption>(); // Dades de la pàgina actual
        public int PageNumber { get; set; } = 1; // Pàgina actual del registres
        public int PageSize { get; set; } = 50; 
        public int TotalPages { get; set; } 
        public WaterConsumption HeaderRow { get; set; } = new WaterConsumption();

        // Propietats per less estadistiques
        public List<WaterConsumption> Top10Municipalities { get; set; } = new List<WaterConsumption>();
        public List<(string? Comarca, double AverageConsumption)> AverageConsumptionByRegion { get; set; } = new List<(string, double)>();
        public List<WaterConsumption> SuspiciousConsumptionMunicipalities { get; set; } = new List<WaterConsumption>();
        public List<WaterConsumption> IncreasingTrendMunicipalities { get; set; } = new List<WaterConsumption>();
        public void OnGet(int? pageNumber)
        {
            if (pageNumber.HasValue)
            {
                PageNumber = pageNumber.Value;
            }

            string filePath = @"ModelData\consum_aigua_cat_per_comarques.csv";
            try
            {
                WaterConsumptions = UsingFiles.CsvHelperTool.ReadCsvFile<WaterConsumption>(filePath);
                TotalPages = (int)Math.Ceiling((double)WaterConsumptions.Count / PageSize);

                // Obte les dades de la pagina actual
                CurrentPageWaterConsumptions = WaterConsumptions
                    .Skip((PageNumber - 1) * PageSize)
                    .Take(PageSize)
                    .ToList();

                
                HeaderRow = CurrentPageWaterConsumptions.FirstOrDefault() ?? new WaterConsumption(); //  Assegurem que sempre hi hagui una capçalera, agafant la primera linea del archiu o tornant una nova instancia

                ConsumptionWaterAnalisis();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al llegir l'archiu CSV.");
                ModelState.AddModelError(string.Empty, "Error al carrega les dades.");
            }
        }
        public void ConsumptionWaterAnalisis()
        {
            if (WaterConsumptions == null || WaterConsumptions.Count == 0)
            {
                return; 
            }
            //Top 10 Municipis amb major consum
            int mostRecentYear = WaterConsumptions.Max(w => w.Year);
            Top10Municipalities = WaterConsumptions
                .Where(w=>w.Year == mostRecentYear)
                .OrderByDescending(w=>w.Total)
                .Take(10)
                .ToList();
            //Consum mitjà per comarca
            AverageConsumptionByRegion = WaterConsumptions
                .GroupBy(w => w.Region)
                .Select(g =>( Comarca : g.Key, Average :Math.Round(g.Average(w => w.Total), 2)))
                .OrderByDescending(w => w.Average)
                .ToList();
            //Detecció de valors de consum sospitosos
            int suspiciusDigits = 99999999; //He posat 8 digits, perque no cupi tant espai a la pagina web
            SuspiciousConsumptionMunicipalities = WaterConsumptions
                .Where(w => ((long)w.Total) > suspiciusDigits)
                .ToList();
            //Detectar si el consum d'aigua d'un municipi ha anat augmentant en els últims 5 anys
            int lastYears = 5;
            int actualYear = DateTime.Now.Year;
            IncreasingTrendMunicipalities = WaterConsumptions
                .Where (w => w.Year >=(actualYear-lastYears))
                .GroupBy(w => w.Region)
                .Where(g =>
                {
                    var lastFiveYears = g.OrderBy(w => w.Year).TakeLast(5).ToList();
                    if (lastFiveYears.Count < lastYears) return false; 
                    return lastFiveYears.Zip(lastFiveYears.Skip(1), (a, b) => a.Total < b.Total).All(x => x); 
                })
                .SelectMany(g => g)
                .Distinct()
                .ToList();
        }
    }
    
}
