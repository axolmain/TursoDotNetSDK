using System.Text;
using System.Text.Json;
using Turso.Client.Configuration;
using Turso.Client.PlatformAPI.Organizations.Invites;
using Turso.Client.PlatformAPI.Organizations.Members;
using Turso.Client.PlatformAPI.Organizations.Models;
using Turso.Client.PlatformAPI.Organizations.Models.Request;
using Turso.Client.PlatformAPI.Organizations.Models.Response;

namespace Turso.Client.PlatformAPI.Organizations;

public class OrganizationsService : IOrganizationsService
{
    private HttpClient _httpClient;

    public OrganizationsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public IInvitesService Invites => _invitesService ??= new InvitesService(_httpClient);
    public IMembersService Members => _membersService ??= new MembersService(_httpClient);

    private IInvitesService _invitesService;
    private IMembersService _membersService;

    public async Task<ListOrganizationsResponse> ListOrganizationsAsync()
    {
        var requestUri = "organizations";
        
        try
        {
            var response = await _httpClient.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();

            var listOrganizationsResponse = await JsonResponseHandler.DeserializeResponseAsync<ListOrganizationsResponse>(jsonResponse);

            return listOrganizationsResponse ??
                   throw new InvalidOperationException("Failed to deserialize the list of organizations.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while getting the list of organizations.", e);
        }
    }

    public async Task<UpdateOrganizationResponse> UpdateOrganizationAsync(string organizationName, UpdateOrganizationRequest updateRequest)
    {
        var requestUri = $"organizations/{organizationName}";

        try
        {
            var content = new StringContent(JsonSerializer.Serialize(updateRequest), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(requestUri, content);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();

            var updateOrganizationResponse =
                await JsonResponseHandler.DeserializeResponseAsync<UpdateOrganizationResponse>(jsonResponse);

            return updateOrganizationResponse ??
                   throw new InvalidOperationException("Failed to deserialize the update organization response.");

        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while updating the organization.", e);
        }
    }
}