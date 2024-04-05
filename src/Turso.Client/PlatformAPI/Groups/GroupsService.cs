using System.Text;
using System.Text.Json;
using Turso.Client.Configuration;
using Turso.Client.PlatformAPI.Database.Models.Request;
using Turso.Client.PlatformAPI.GenericModels;
using Turso.Client.PlatformAPI.Groups.Models.Objects;
using Turso.Client.PlatformAPI.Groups.Models.Request;
using Turso.Client.PlatformAPI.Groups.Models.Response;
using Turso.Client.PlatformAPI.Locations.Enums;
using ApplicationException = System.ApplicationException;
using CreateTokenResponse = Turso.Client.PlatformAPI.Groups.Models.Response.CreateTokenResponse;

namespace Turso.Client.PlatformAPI.Groups;

public class GroupsService : IGroupsService
{
    private readonly HttpClient _httpClient;

    public GroupsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <inheritdoc />
    public async Task<ListGroupsResponse> ListGroupsAsync(string organizationName)
    {
        var requestUri = $"organizations/{organizationName}/groups";

        try
        {
            var response = await _httpClient.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var tokenResponse = await JsonResponseHandler.DeserializeResponseAsync<ListGroupsResponse>(jsonResponse);

            return tokenResponse ??
                   throw new InvalidOperationException("Failed to deserialize the list of groups belonging to a user.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while getting the list of groups belonging to the organization or user.", e);
        }
    }

    /// <inheritdoc />
    public async Task<CreateGroupResponse> CreateGroupAsync(string organizationName, CreateGroupRequest createRequest)
    {
        var requestUri = $"organizations/{organizationName}/groups";

        try
        {
            var jsonContent = JsonSerializer.Serialize(createRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            using var response = await _httpClient.PostAsync(requestUri, content);

            response.EnsureSuccessStatusCode();

            await using var jsonResponse = await response.Content.ReadAsStreamAsync();
            var groupResponse = await JsonResponseHandler.DeserializeResponseAsync<CreateGroupResponse>(jsonResponse);

            return groupResponse ?? throw new InvalidOperationException("Failed to deserialize the response for creating a new group.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException($"A network error occurred while creating a new group for '{organizationName}'.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while processing the response.", e);
        }
    }

    /// <inheritdoc />
    public async Task<Group> RetrieveGroupAsync(string organizationName, string groupName)
    {
        var requestUri = $"organizations/{organizationName}/groups/{groupName}";

        try
        {
            var response = await _httpClient.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var group = await JsonResponseHandler.DeserializeResponseAsync<Group>(jsonResponse);

            return group ?? throw new InvalidOperationException("Failed to deserialize the response for retrieving a group.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException($"A network error occurred while retrieving a group for '{organizationName}'.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while processing the response.", e);
        }
    }

    /// <inheritdoc />
    public async Task<DeleteGroupResponse> DeleteGroupAsync(string organizationName, string groupName)
    {
        var requestUri = $"organizations/{organizationName}/groups/{groupName}";

        try
        {
            var response = await _httpClient.DeleteAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var deleteResponse = await JsonResponseHandler.DeserializeResponseAsync<DeleteGroupResponse>(jsonResponse);

            return deleteResponse ?? throw new InvalidOperationException("Failed to deserialize the response for deleting a group.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException($"A network error occurred while deleting a group for '{organizationName}'.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while processing the response.", e);
        }
    }

    /// <inheritdoc />
    public async Task<TransferGroupResponse> TransferGroupAsync(string organizationName, string groupName, TransferGroupRequest transferRequest)
    {
        var requestUri = $"organizations/{organizationName}/groups/{groupName}/transfer";

        try
        {
            var jsonContent = JsonSerializer.Serialize(transferRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            using var response = await _httpClient.PostAsync(requestUri, content);

            response.EnsureSuccessStatusCode();

            await using var jsonResponse = await response.Content.ReadAsStreamAsync();
            var transferResponse = await JsonResponseHandler.DeserializeResponseAsync<TransferGroupResponse>(jsonResponse);

            return transferResponse ?? throw new InvalidOperationException("Failed to deserialize the response for transferring a group.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException($"A network error occurred while transferring a group for '{organizationName}'.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while processing the response.", e);
        }
    }

    /// <inheritdoc />
    public async Task<AddGroupLocationResponse> AddGroupLocationAsync(string organizationName, string groupName, LocationCode locationRequest)
    {
        var requestUri = $"organizations/{organizationName}/groups/{groupName}/locations/{locationRequest.ToString()}";

        try
        {
            var response = await _httpClient.PostAsync(requestUri, null);

            response.EnsureSuccessStatusCode();

            await using var jsonResponse = await response.Content.ReadAsStreamAsync();
            var locationResponse = await JsonResponseHandler.DeserializeResponseAsync<AddGroupLocationResponse>(jsonResponse);

            return locationResponse ?? throw new InvalidOperationException("Failed to deserialize the response for adding a location to a group.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException($"A network error occurred while adding a location to a group for '{organizationName}'.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while processing the response.", e);
        }
    }

    /// <inheritdoc />
    public async Task<RemoveGroupLocationResponse> RemoveGroupLocationAsync(string organizationName, string groupName, LocationCode locationCode)
    {
        var requestUri = $"organizations/{organizationName}/groups/{groupName}/locations/{locationCode.ToString()}";

        try
        {
            var response = await _httpClient.DeleteAsync(requestUri);

            response.EnsureSuccessStatusCode();

            await using var jsonResponse = await response.Content.ReadAsStreamAsync();
            var removeLocationResponse = await JsonResponseHandler.DeserializeResponseAsync<RemoveGroupLocationResponse>(jsonResponse);

            return removeLocationResponse ?? throw new InvalidOperationException("Failed to deserialize the response for removing a location from a group.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException($"A network error occurred while removing a location from a group for '{organizationName}'.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while processing the response.", e);
        }
    }

    /// <inheritdoc />
    public async Task UpdateVersionsAsync(string organizationName, string groupName)
    {
        var requestUri = $"organizations/{organizationName}/groups/{groupName}/update";

        try
        {
            using var response = await _httpClient.PostAsync(requestUri, null);

            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException($"A network error occurred while updating versions for '{organizationName}'.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while processing the response.", e);
        }
    }

    /// <inheritdoc />
    public async Task<CreateTokenResponse> CreateTokenAsync(string organizationName, string groupName, CreateTokenRequest tokenRequest)
    {
        var requestUri = $"organizations/{organizationName}/groups/{groupName}/auth/tokens";
        var jsonContent = JsonSerializer.Serialize(tokenRequest);
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        try
        {
            using var response = await _httpClient.PostAsync(requestUri, content);

            response.EnsureSuccessStatusCode();

            await using var jsonResponse = await response.Content.ReadAsStreamAsync();
            var tokenResponse = await JsonResponseHandler.DeserializeResponseAsync<CreateTokenResponse>(jsonResponse);

            return tokenResponse ?? throw new InvalidOperationException("Failed to deserialize the response for creating a token.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException($"A network error occurred while creating a token for '{organizationName}'.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while processing the response.", e);
        }
    }

    /// <inheritdoc />
    public async Task InvalidateTokensAsync(string organizationName, string groupName)
    {
        var requestUri = $"organizations/{organizationName}/groups/{groupName}/auth/rotate";

        try
        {
            var response = await _httpClient.PostAsync(requestUri, null);

            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException($"A network error occurred while invalidating tokens for '{organizationName}'.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while processing the response.", e);
        }
    }
}