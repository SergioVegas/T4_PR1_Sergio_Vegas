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

        public List<EnergeticIndicator> EnergeticIndicator { get; set; } = new List<EnergeticIndicator>();
        public List<EnergeticIndicator> CurrentPageEnergeticIndicators { get; set; } = new List<EnergeticIndicator>(); // Dades de la pàgina actual
        public int PageNumber { get; set; } = 1; // Pàgina actual del registres
        public int PageSize { get; set; } = 50;
        public int TotalPages { get; set; }
        public EnergeticIndicator HeaderRow { get; set; } = new EnergeticIndicator();

        // Propietats per less estadistiques
        public List<EnergeticIndicator> Top10Municipalities { get; set; } = new List<EnergeticIndicator>();
        public List<(string? Comarca, double AverageConsumption)> AverageConsumptionByRegion { get; set; } = new List<(string, double)>();
        public List<EnergeticIndicator> SuspiciousConsumptionMunicipalities { get; set; } = new List<EnergeticIndicator>();
        public List<EnergeticIndicator> IncreasingTrendMunicipalities { get; set; } = new List<EnergeticIndicator>();

        public List<EnergeticIndicator> XmlEnergeticIndicator { get; set; } = new List<EnergeticIndicator>();
        public bool XmlFileExists { get; set; } = false;
        public void OnGet(int? pageNumber)
        {
            if (pageNumber.HasValue)
            {
                PageNumber = pageNumber.Value;
            }

            string filePathCsv = Path.Combine("ModelData", "consum_aigua_cat_per_comarques.csv");
            string xmlFilePath = Path.Combine("ModelData", "water_consumption_data.xml");
            try
            {
                if (System.IO.File.Exists(xmlFilePath))
                {
                    try
                    {
                        XmlEnergeticIndicator = UsingFiles.XMLHelperTool.ReadXMLFile<EnergeticIndicator>(xmlFilePath);
                        XmlFileExists = true;
                    }
                    catch (Exception xmlEx)
                    {
                        _logger.LogError(xmlEx, "Error en llegir el fitxer XML.");
                        ModelState.AddModelError(string.Empty, "Error al carregar les dades del fitxer XML.");
                        XmlEnergeticIndicator = new List<EnergeticIndicator>();
                        XmlFileExists = false;
                    }
                }
                EnergeticIndicator = UsingFiles.CsvHelperTool.ReadCsvFile<EnergeticIndicator>(filePathCsv);

                EnergeticIndicator.AddRange(XmlEnergeticIndicator); //Afegim el llistat xml a la llista del csv

                TotalPages = (int)Math.Ceiling((double)EnergeticIndicator.Count / PageSize);

                // Obte les dades de la pagina actual
                CurrentPageEnergeticIndicators = EnergeticIndicator
                    .Skip((PageNumber - 1) * PageSize)
                    .Take(PageSize)
                    .ToList();

                HeaderRow = CurrentPageEnergeticIndicators.FirstOrDefault() ?? new EnergeticIndicator(); //  Assegurem que sempre hi hagui una capçalera, agafant la primera linea del archiu o tornant una nova instancia


               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al llegir l'archiu CSV.");
                ModelState.AddModelError(string.Empty, "Error al carrega les dades.");
            }
        }
    }
}
