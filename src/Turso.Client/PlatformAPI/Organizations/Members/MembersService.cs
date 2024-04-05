using System.Text;
using System.Text.Json;
using Turso.Client.Configuration;
using Turso.Client.PlatformAPI.Organizations.Members.Enums;
using Turso.Client.PlatformAPI.Organizations.Members.Models.Request;
using Turso.Client.PlatformAPI.Organizations.Members.Models.Response;

namespace Turso.Client.PlatformAPI.Organizations.Members;

public class MembersService : IMembersService
{
    private readonly HttpClient _httpClient;

    public MembersService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <inheritdoc />
    public async Task<ListMembersResponse> ListMembersAsync(string organizationName)
    {
        var requestUri = $"organizations/{organizationName}/members";

        try
        {
            var response = await _httpClient.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();

            var listOrganizationsResponse = await JsonResponseHandler.DeserializeResponseAsync<ListMembersResponse>(jsonResponse);

            return listOrganizationsResponse ??
                   throw new InvalidOperationException("Failed to deserialize the list of members.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while getting the list of members.", e);
        }
    }

    /// <inheritdoc />
    public async Task<AddMemberResponse> AddMemberAsync(string organizationName, AddMemberRequest memberRequest)
    {
        if (memberRequest.Role == OrganizationRole.Owner)
            throw new ArgumentException("Cannot set Owner as a role for a member.");
        
        var requestUri = $"organizations/{organizationName}/members";
        
        try
        {
            var content = new StringContent(JsonSerializer.Serialize(memberRequest), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(requestUri, content);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();

            var addMemberResponse = await JsonResponseHandler.DeserializeResponseAsync<AddMemberResponse>(jsonResponse);

            return addMemberResponse ??
                   throw new InvalidOperationException("Failed to deserialize the add member response.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while adding a member.", e);
        }
    }

    /// <inheritdoc />
    public async Task<RemoveMemberResponse> RemoveMemberAsync(string organizationName, string username)
    {
        var requestUri = $"organizations/{organizationName}/members/{username}";
        
        try
        {
            var response = await _httpClient.DeleteAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();

            var removeMemberResponse = await JsonResponseHandler.DeserializeResponseAsync<RemoveMemberResponse>(jsonResponse);

            return removeMemberResponse ??
                   throw new InvalidOperationException("Failed to deserialize the remove member response.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while removing a member.", e);
        }
    }
}