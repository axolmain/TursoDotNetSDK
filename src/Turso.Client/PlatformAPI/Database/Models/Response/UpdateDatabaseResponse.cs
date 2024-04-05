using System.Text.Json.Serialization;

namespace Turso.Client.PlatformAPI.Database.Models.Response;

public class UpdateDatabaseResponse
{
    /// <summary>
    /// Allow or disallow attaching databases to the current database.
    /// </summary>
    [JsonPropertyName("allow_attach")]
    public bool AllowAttach { get; set; }
    
    /// <summary>
    /// The maximum size of the database in bytes. Values with units are also accepted, e.g. 1mb, 256mb, 1gb.
    /// </summary>
    [JsonPropertyName("group")]
    public string SizeLimit { get; set; }
}