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
        public List<EnergeticIndicator> CurrentPageEnergeticIndicators { get; set; } = new List<EnergeticIndicator>();
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 50;
        public int TotalPages { get; set; }

        public void OnGet(int? pageNumber)
        {
            if (pageNumber.HasValue)
            {
                PageNumber = pageNumber.Value;
            }

            string filePathCsv = Path.Combine("ModelData", "indicadors_energetics_cat.csv");

            try
            {
                EnergeticIndicators = UsingFiles.CsvHelperTool.ReadCsvFile<EnergeticIndicator>(filePathCsv);

                TotalPages = (int)Math.Ceiling((double)EnergeticIndicators.Count / PageSize);

                // Obten las datos de la pagina actual
                CurrentPageEnergeticIndicators = EnergeticIndicators
                    .Skip((PageNumber - 1) * PageSize)
                    .Take(PageSize)
                    .ToList();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error al cargar los datos: " + ex.Message);
            }
        }
    }
}
