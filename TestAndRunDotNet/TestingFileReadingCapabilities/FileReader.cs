using System.Collections.Concurrent;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Files;

public class FileReader
{
    public List<Iris> GetIrises()
    {
        var path = "../iris.csv";

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => args.Header.Replace("_", "").ToLowerInvariant(),
        };

        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, config);
        return csv.GetRecords<Iris>().ToList();
    }

    public  Task<List<Country>> GetCountries()
    {
        var httpClient = new HttpClient();
        var data =  httpClient.GetFromJsonAsync<List<Country>>("https://restcountries.com/v3.1/all?fields=name,capital,currencies");
        return data;
    }

    
}
