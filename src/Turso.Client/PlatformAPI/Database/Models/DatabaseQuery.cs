using System.Text.Json.Serialization;

namespace Turso.Client.PlatformAPI.Database.Models;

public class DatabaseQuery
{
    [JsonPropertyName("query")]
    public string Query { get; set; }
    
    [JsonPropertyName("rows_read")]
    public int RowsRead { get; set; }
    
    [JsonPropertyName("rows_written")]
    public int RowsWritten { get; set; }
}