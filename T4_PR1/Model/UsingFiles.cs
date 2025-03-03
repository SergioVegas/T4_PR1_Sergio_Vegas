using CsvHelper.Configuration;
using System.Globalization;

namespace T4_PR1.Model
{
    public class UsingFiles
    {
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
                    Console.WriteLine($"Error reading CSV file: {ex.Message}");
                    throw; 
                }
            }
        }
        public static class XMLHelperTool
        {
            public static List<T> ReadXMLFile<T>(string filePath, CsvConfiguration? config = null)
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
                    Console.WriteLine($"Error reading CSV file: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
