using BlazorApp.Core.Utils;

namespace BlazorApp.Core.Extensions;

public static class HttpClientExtensions
{
    public static async Task<string> GetJsonWithPrettifyAsync(this HttpClient client, string requestUri)
    {
        var json = await client.GetStringAsync(requestUri);
        return JsonHelper.JsonPrettify(json);
    }
}