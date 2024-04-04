using System.Text.Json.Serialization;

namespace Turso.Client.PlatformAPI.Database.Models.Response;

public class GetDatabaseStatsResponse
{
    [JsonPropertyName("top_queries")]
    DatabaseQuery[] TopQueries { get; set; }
}