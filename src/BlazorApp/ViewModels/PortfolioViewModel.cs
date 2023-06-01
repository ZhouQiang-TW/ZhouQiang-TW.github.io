using System.Net.Http.Json;
using BlazorApp.Models;

namespace BlazorApp.ViewModels;

public class PortfolioViewModel
{
    private readonly HttpClient _http;

    public PortfolioViewModel(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<WeatherForecast>> FetchDataAsync()
    {
        return await _http.GetFromJsonAsync<IEnumerable<WeatherForecast>>("sample-data/weather.json");
    }
}