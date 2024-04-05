using System.Text;
using System.Text.Json;
using Turso.Client.Configuration;
using Turso.Client.PlatformAPI.Organizations.Invites.Models.Request;
using Turso.Client.PlatformAPI.Organizations.Invites.Models.Response;

namespace Turso.Client.PlatformAPI.Organizations.Invites;

public class InvitesService : IInvitesService
{
    private readonly HttpClient _httpClient;

    public InvitesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <inheritoc />
    public async Task<ListInvitesResponse> ListInvitesAsync(string organizationName)
    {
        var requestUri = $"organizations/{organizationName}/invites";
        
        try
        {
            var response = await _httpClient.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();

            var listInvitesResponse = await JsonResponseHandler.DeserializeResponseAsync<ListInvitesResponse>(jsonResponse);

            return listInvitesResponse ??
                   throw new InvalidOperationException("Failed to deserialize the list of invites.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while getting the list of invites.", e);
        }
    }

    /// <inheritoc />
    public async Task<CreateInviteResponse> CreateInviteAsync(string organizationName, CreateInviteRequest inviteRequest)
    {
        var requestUri = $"organizations/{organizationName}/invites";
        
        try
        {
            var content = new StringContent(JsonSerializer.Serialize(inviteRequest), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(requestUri, content);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();

            var createInviteResponse = await JsonResponseHandler.DeserializeResponseAsync<CreateInviteResponse>(jsonResponse);

            return createInviteResponse ??
                   throw new InvalidOperationException("Failed to deserialize the created invite.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while creating the invite.", e);
        }
    }
}