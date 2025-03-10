using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T4_PR1.Model;

namespace T4_PR1.Pages
{
    public class EnergyIndicatorModel : PageModel
    {
        private readonly ILogger<EnergyIndicatorModel> _logger;
        public EnergyIndicatorModel(ILogger<EnergyIndicatorModel> logger)
        {
            _logger = logger;
        }
        public List<EnergeticIndicator> EnergeticIndicators { get; set; } = new List<EnergeticIndicator>();

        public void OnGet()
        {
            string filePathCsv = Path.Combine("ModelData", "indicadors_energetics_cat.csv");

            try
            {
                EnergeticIndicators = UsingFiles.CsvHelperTool.ReadCsvFile<EnergeticIndicator>(filePathCsv); // sin csvConfig
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading the CSV file.");
                ModelState.AddModelError(string.Empty, "Error loading data: " + ex.Message);
            }
        }
    }
}
