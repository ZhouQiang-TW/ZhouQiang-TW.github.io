using System.Net.Http.Json;

namespace BlazorApp.Pages;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public string Summary { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public class PortfolioRazor
{
    private readonly HttpClient _httpClient;

    public PortfolioRazor(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<WeatherForecast>> FetchDataAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("sample-data/weather.json");
    }
}