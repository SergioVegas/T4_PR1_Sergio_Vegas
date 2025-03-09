using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using T4_PR1.Model;

namespace T4_PR1.Pages
{
    public class AddWaterConsumptionModel : PageModel
    {
        private readonly ILogger<AddWaterConsumptionModel> _logger;
        private static readonly string XmlFilePath = Path.Combine("ModelData", "water_consumption_data.xml"); //Utiltzo path.combine, per fer aquesta part per millorar la portabilitat del codi.
        public AddWaterConsumptionModel(ILogger<AddWaterConsumptionModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public WaterConsumption NewWaterConsumption { get; set; } = new WaterConsumption();
        public string Message { get; set; } //variable per donar més detalls als errors
      

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {               
                return Page();
            }

            try
            {
                List<WaterConsumption> waterConsumptions = UsingFiles.XMLHelperTool.ReadXMLFile<WaterConsumption>(XmlFilePath);
                waterConsumptions.Add(NewWaterConsumption);
                UsingFiles.XMLHelperTool.WriteXMLFile(waterConsumptions, XmlFilePath);

                return RedirectToPage("/WaterConsumption");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar l'archiu XML.");
                Message = "Error al guardar consum d'aigua.";
                return Page();
            }
        }
    }
}
