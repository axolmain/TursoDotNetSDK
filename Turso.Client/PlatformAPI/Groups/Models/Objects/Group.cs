namespace Turso.Client.PlatformAPI.Groups.Models.Objects;

public class Group
{
    public bool Archived { get; set; }
    public string[] Locations { get; set; }
    public string Name { get; set; }
    public string Primary { get; set; }
    public string Uuid { get; set; }
    public string? Version { get; set; }
}