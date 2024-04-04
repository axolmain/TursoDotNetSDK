namespace Turso.Client.PlatformAPI.Database.Models;

/// <summary>
/// DatabaseUsageInstances of the current database.
/// </summary>
public class DatabaseUsageInstances
{
    public Usage Usage { get; set; }
    public string Uuid { get; set; }
}