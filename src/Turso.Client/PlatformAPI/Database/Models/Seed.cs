using System.Text.Json.Serialization;

namespace Turso.Client.PlatformAPI.Database.Models;

public class Seed
{
    /// <summary>
    /// The name of the existing database when database is used as a seed type.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// A formatted ISO 8601 recovery point to create a database from. This must be within the last 24 hours, or 30 days on the scaler plan.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public string Timestamp { get; set; }

    /// <summary>
    /// The type of seed to be used to create a new database.
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// The URL returned by upload dump can be used with the dump seed type.
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }
}