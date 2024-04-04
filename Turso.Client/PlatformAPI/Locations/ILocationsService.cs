using Turso.Client.PlatformAPI.Locations.Models.Response;

namespace Turso.Client.PlatformAPI.Locations;

public interface ILocationsService
{
    Task<ListLocationsResponse> ListLocationsAsync();
    Task<ClosestRegionResponse> GetClosestRegionAsync(string latitude, string longitude);
}