namespace Turso.Client.PlatformAPI.Database.Models;

public class Database
{
    public string DbId { get; set; }
    public string Hostname { get; set; }
    public string Name { get; set; }
    public bool AllowAttach { get; set; }
    public bool BlockReads { get; set; }
    public bool BlockWrites { get; set; }
    public string Group { get; set; }
    public bool IsSchema { get; set; }
    public string PrimaryRegion { get; set; }
    public List<string> Regions { get; set; }
    public string Schema { get; set; }
    public bool Sleeping { get; set; }
    public string Type { get; set; }
    public string Version { get; set; }
}