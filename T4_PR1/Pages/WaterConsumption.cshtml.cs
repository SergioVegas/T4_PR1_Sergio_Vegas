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
        public List<(string Comarca, double AverageConsumption)> AverageConsumptionByRegion { get; set; } = new List<(string, double)>();
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
                _logger.LogError(ex, "Error al leer el archivo CSV.");
                ModelState.AddModelError(string.Empty, "Ocurrió un error al cargar los datos. Por favor, inténtalo de nuevo.");
            }
        }
        public void ConsumptionWaterAnalisis()
        {
            if (WaterConsumptions == null || WaterConsumptions.Count == 0)
            {
                return; 
            }

            int mostRecentYear = WaterConsumptions.Max(w => w.Year);
            Top10Municipalities = WaterConsumptions
                .Where(w=>w.Year == mostRecentYear)
                .OrderByDescending(w=>w.Total)
                .Take(10)
                .ToList();
        }
    }
}
