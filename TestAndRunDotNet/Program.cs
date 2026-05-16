using Files;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var fileReader = new FileReader();
// var irises = fileReader.GetIrises();
// Console.WriteLine($"Number of rows: {irises.Count}");

var top10Countries = (await fileReader.GetCountries()).Take(10).ToList();

var countryNames = string.Join("\n",top10Countries.Select(country => country.Name.Common));

app.MapGet("/", () => $"{countryNames}");

app.Run();

