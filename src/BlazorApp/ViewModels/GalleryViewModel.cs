using System.Net.Http.Json;
using System.Text.Json;
using BlazorApp.Converters;
using BlazorApp.Models;

namespace BlazorApp.ViewModels;

public class GalleryViewModel
{
    private readonly HttpClient _http;

    public GalleryViewModel(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<Wallpaper>> FetchDataAsync()
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters =
            {
                new CustomDateTimeConverter("yyyyMMddHHmm"),
                new CustomDateOnlyConverter("yyyyMMdd")
            }
        };
        var response = await _http.GetFromJsonAsync<WallpaperRoot>("sample-data/image.json", jsonSerializerOptions);
        return response.Images;
    }
}