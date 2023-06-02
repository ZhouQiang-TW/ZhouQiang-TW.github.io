using System.Text.Json;

namespace BlazorApp.Core.Utils;

public static class JsonHelper
{
    public static string JsonPrettify(string json)
    {
        using var jDoc = JsonDocument.Parse(json);
        return JsonSerializer.Serialize(jDoc, new JsonSerializerOptions { WriteIndented = true });
    }
}