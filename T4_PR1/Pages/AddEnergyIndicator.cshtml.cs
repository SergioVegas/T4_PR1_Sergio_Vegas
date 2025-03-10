using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T4_PR1.Model;

namespace T4_PR1.Pages
{
    public class AddEnergyIndicatorModel : PageModel
    {
        private readonly ILogger<AddEnergyIndicatorModel> _logger;
      
        public AddEnergyIndicatorModel(ILogger<AddEnergyIndicatorModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public EnergeticIndicator NewWEnergeticIndicator { get; set; } = new EnergeticIndicator();
        public string Message { get; set; } //variable per donar més detalls als errors


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string JsonFilePath = Path.Combine("ModelData", "indicadors_energetics_cat.json"); 
            try
            {
                List<EnergeticIndicator> energeticIndicators = new List<EnergeticIndicator> { NewWEnergeticIndicator };
                UsingFiles.JSONHelperTool.WriteJsonFile(JsonFilePath, energeticIndicators);
                

                return RedirectToPage("/EnergyIndicator");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar l'archiu JSON.");
                Message = "Error al guardar indicador d'energia.";
                return Page();
            }
        }
    }
}
