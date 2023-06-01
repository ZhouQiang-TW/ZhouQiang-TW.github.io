using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorApp.Converters;

public class CustomDateOnlyConverter : JsonConverter<DateOnly>
{
    private readonly string _format;

    public CustomDateOnlyConverter(string format)
    {
        _format = format;
    }

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.ParseExact(reader.GetString() ?? throw new ArgumentNullException(nameof(reader)), _format,
            new CultureInfo("en-US", true));
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(_format));
    }
}