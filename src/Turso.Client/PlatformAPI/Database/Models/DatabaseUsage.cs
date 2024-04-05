namespace Turso.Client.PlatformAPI.Database.Models;

public class DatabaseUsage
{
    public DatabaseUsageInstances[] Instances { get; set; }
    public Total Total { get; set; }
    public string Uuid { get; set; }
}