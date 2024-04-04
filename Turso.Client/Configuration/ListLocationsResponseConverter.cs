using System.Text.Json;
using System.Text.Json.Serialization;
using Turso.Client.PlatformAPI.Groups.Enums;
using Turso.Client.PlatformAPI.Locations.Models.Response;

namespace Turso.Client.Configuration;

public class ListLocationsResponseConverter : JsonConverter<ListLocationsResponse>
{
    public override ListLocationsResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("Expected StartObject token");
        }

        var response = new ListLocationsResponse();
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            if (reader.TokenType == JsonTokenType.PropertyName && reader.GetString() == "locations")
            {
                reader.Read(); // Move to StartObject or whatever the next token of the value is.
                var locations = new Dictionary<LocationCode, string>();

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                    {
                        break;
                    }

                    var keyAsString = reader.GetString();
                    reader.Read();
                    var valueAsString = reader.GetString();

                    if (Enum.TryParse<LocationCode>(keyAsString, true, out var key))
                    {
                        locations[key] = valueAsString;
                    }
                    else
                    {
                        throw new JsonException($"Unable to convert {keyAsString} to LocationCode enum.");
                    }
                }

                response.Locations = locations;
            }
        }

        return response;
    }

    public override void Write(Utf8JsonWriter writer, ListLocationsResponse value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("locations");
        writer.WriteStartObject();

        foreach (var location in value.Locations)
        {
            writer.WriteString(location.Key.ToString(), location.Value);
        }

        writer.WriteEndObject();
        writer.WriteEndObject();
    }
}