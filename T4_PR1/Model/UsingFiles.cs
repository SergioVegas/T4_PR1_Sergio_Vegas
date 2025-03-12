using CsvHelper.Configuration;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace T4_PR1.Model
{
    public class UsingFiles
    {  /// <summary>
       /// Llegeix una llista d'objectes de tipus T des d'un fitxer CSV.
       /// </summary>
       /// <typeparam name="T">El tipus d'objecte a deserialitzar.</typeparam>
       /// <param name="filePath">El camí al fitxer CSV.</param>
       /// <param name="config">Configuració opcional per al lector CSV. Si és null, s'utilitzarà una configuració per defecte amb el delimitador ",".</param>
       /// <returns>Una llista d'objectes de tipus T deserialitzats del fitxer CSV.</returns>
       /// <exception cref="Exception">Es llança si hi ha un error durant la lectura del fitxer CSV.</exception>
        public static class CsvHelperTool
        {
            public static List<T> ReadCsvFile<T>(string filePath, CsvConfiguration? config = null)
            {
                try
                {
                   
                    var csvConfig = config ?? new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = "," };

                    using (var reader = new StreamReader(filePath))
                    
                    using (var csv = new CsvHelper.CsvReader(reader, csvConfig))
                    {
                        var records = csv.GetRecords<T>().ToList();
                        return records;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error lleguint l'arxiu CSV : {ex.Message}");
                    throw; 
                }
            }
        }
        public static class XMLHelperTool
        {
           
            /// <summary>
            /// Escriu una llista d'objectes de tipus T a un fitxer XML, sobreescrivint el fitxer si existeix.
            /// </summary>
            /// <typeparam name="T">El tipus d'objecte a serialitzar.</typeparam>
            /// <param name="objects">La llista d'objectes a serialitzar.</param>
            /// <param name="filePath">El camí al fitxer XML.</param>
            public static void WriteXMLFile<T>(List<T> objects, string filePath)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));

                try
                {
                    using (FileStream file = File.Create(filePath))
                    {
                        serializer.Serialize(file, objects);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error escribint en  el fitxer XML: {ex.Message}");
                    throw;
                }
            }
        }
        /// <summary>
        /// Afegeix dades a un fitxer JSON existent (si existeix) o crea un fitxer nou (si no existeix).
        /// </summary>
        /// <typeparam name="T">El tipus d'objecte a la llista.</typeparam>
        /// <param name="filePath">La ruta completa al fitxer JSON.</param>
        /// <param name="newData">La llista d'objectes a serialitzar i desar al fitxer.</param>
        /// <param name="logger">(Opcional) Un objecte ILogger per registrar esdeveniments i errors.</param>
        public static class JSONHelperTool
        {
            public static void WriteJsonFile<T>(string filePath, List<T> newData)
            {
                try
                {
                    List<T> existingData = new List<T>();

                    if (File.Exists(filePath))
                    {  
                            string existingJson = File.ReadAllText(filePath);
                            existingData = JsonConvert.DeserializeObject<List<T>>(existingJson) ?? new List<T>();
                    }
                    existingData.AddRange(newData);

                    string jsonData = JsonConvert.SerializeObject(existingData, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(filePath, jsonData);
                }
                catch (Exception ex)
                {
                    Console.WriteLine( $"\"Error escribint en  el fitxer JSON: {ex.Message}");
                    
                }
            }
            public static void ReadJsonFile<T>(string jsonFromFile, List<T> informationJson)
            {
                try
                {
                    informationJson = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(jsonFromFile));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\"Error lleguint el fitxer JSON: {ex.Message}");

                }
            }
        }

    }

}
