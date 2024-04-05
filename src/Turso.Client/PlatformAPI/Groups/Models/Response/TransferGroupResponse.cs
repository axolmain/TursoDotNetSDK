namespace Turso.Client.PlatformAPI.Groups.Models.Response;

public class TransferGroupResponse
{
    public bool Archived { get; set; }
    public string[] Locations { get; set; }
    public string Name { get; set; }
    public string Primary { get; set; }
    public string Uuid { get; set; }
    public string Version { get; set; }
}