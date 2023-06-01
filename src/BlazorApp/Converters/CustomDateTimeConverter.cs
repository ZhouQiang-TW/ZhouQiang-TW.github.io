using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorApp.Converters;

public class CustomDateTimeConverter : JsonConverter<DateTime>
{
    private readonly string _format;

    public CustomDateTimeConverter(string format)
    {
        _format = format;
    }

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.ParseExact(reader.GetString() ?? throw new ArgumentNullException(nameof(reader)), _format,
            new CultureInfo("en-US", true));
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_format));
    }
}