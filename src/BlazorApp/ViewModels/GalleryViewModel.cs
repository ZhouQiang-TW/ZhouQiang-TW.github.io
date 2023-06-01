using BlazorApp.HttpClients;

namespace BlazorApp.ViewModels;

public class GalleryViewModel
{
    private readonly BingWallpaperHttpClient _http;

    public GalleryViewModel(BingWallpaperHttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<object>> FetchDataAsync()
    {
        var items = await _http.GetBingWallpapers();
        throw new NotImplementedException();
    }
}