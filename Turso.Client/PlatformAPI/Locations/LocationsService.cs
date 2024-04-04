using System.Text.Json;
using Turso.Client.Configuration;
using Turso.Client.PlatformAPI.Locations.Models.Response;

namespace Turso.Client.PlatformAPI.Locations;

public class LocationsService : ILocationsService
{
    private readonly HttpClient _httpClient;

    public LocationsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<ListLocationsResponse> ListLocationsAsync()
    {
        var requestUri = $"locations";

        try
        {
            var response = await _httpClient.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            
            var options = new JsonSerializerOptions
            {
                Converters = { new ListLocationsResponseConverter() }
            };
            
            var listLocationsResponse = JsonSerializer.Deserialize<ListLocationsResponse>(jsonResponse, options);

            return listLocationsResponse ??
                   throw new InvalidOperationException("Failed to deserialize the list of locations where you can create or replicate databases.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while getting the list of locations where you can create or replicate databases.", e);
        }
    }

    public async Task<ClosestRegionResponse> GetClosestRegionAsync(string latitude, string longitude)
    {
        try
        {
            var response = await _httpClient.GetAsync("https://region.turso.io");
            
            response.EnsureSuccessStatusCode();
            
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var closestRegionResponse = JsonSerializer.Deserialize<ClosestRegionResponse>(jsonResponse);
            
            return closestRegionResponse ??
                   throw new InvalidOperationException("Failed to deserialize the closest region response.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while getting the closest region to your location.", e);
        }
    }
}