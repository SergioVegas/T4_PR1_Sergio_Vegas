using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.X509Certificates;
using T4._PR1._Practica_1.EnegyClass;

namespace T4_PR1.Pages
{
    public class AddSimulationModel : PageModel
    {
        [BindProperty]
        public string EnergySelected { get; set; }

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
            switch (EnergySelected)
            {
                case "solar":
                    List<SolarSystem> solarSimulation;
                    break;
                case "wind":
                    List<WindSystem> windSystem;
                    break;
                case "hidro":
                   List<HidroelectricSystem> hidroelectricSystem;
                    break;
                default:
                    break;
            }
            return Page();
        }
    }
}
