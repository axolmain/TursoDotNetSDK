using Turso.Client.PlatformAPI.Locations.Enums;

namespace Turso.Client.PlatformAPI.Locations.Models.Response;

public class ListLocationsResponse
{
    /// <summary>
    /// The list of locations.
    /// </summary>
    public Dictionary<LocationCode, string> Locations { get; set; }
}