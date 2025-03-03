using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Serialization;
using T4_PR1.Model;

namespace T4_PR1.Pages
{
    public class AddWaterConsumptionModel : PageModel
    {
        private readonly ILogger<AddWaterConsumptionModel> _logger; 

        public AddWaterConsumptionModel(ILogger<AddWaterConsumptionModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public WaterConsumption NewWaterConsumption { get; set; } = new WaterConsumption();

        public string Message { get; set; } = "";
        public string MessageType { get; set; } = "alert-success"; 

        private string XmlFilePath = @"ModelData\water_consumption_data.xml"; 

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Message = "Por favor, corrige los errores en el formulario.";
                MessageType = "alert-danger";
                return Page();
            }

            List<WaterConsumption> waterConsumptions = LoadWaterConsumptionsFromXml();
            waterConsumptions.Add(NewWaterConsumption);
            SaveWaterConsumptionsToXml(waterConsumptions);

            
            return RedirectToPage("/WaterConsumption");
        }

        private List<WaterConsumption> LoadWaterConsumptionsFromXml()
        {
            List<WaterConsumption> waterConsumptions = new List<WaterConsumption>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<WaterConsumption>));

            if (System.IO.File.Exists(XmlFilePath))
            {
                try
                {
                    using (FileStream file = System.IO.File.OpenRead(XmlFilePath))
                    {
                        waterConsumptions = (List<WaterConsumption>)serializer.Deserialize(file);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al leer el archivo XML.");
                    // Handle the exception, perhaps by logging it and/or showing an error message to the user.
                    // For example:
                    Message = "Error al leer el archivo XML.";
                    MessageType = "alert-danger";
                    return new List<WaterConsumption>();
                }
            }

            return waterConsumptions;
        }


        private void SaveWaterConsumptionsToXml(List<WaterConsumption> waterConsumptions)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<WaterConsumption>));
            try
            {
                using (FileStream file = System.IO.File.Create(XmlFilePath))
                {
                    serializer.Serialize(file, waterConsumptions);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al guardar el archivo XML.");
                // Handle the exception, perhaps by logging it and/or showing an error message to the user.
                // For example:
                Message = "Error al guardar el archivo XML.";
                MessageType = "alert-danger";
            }
        }
    }
}
