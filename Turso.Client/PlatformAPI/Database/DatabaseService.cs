using System.Text;
using System.Text.Json;
using Turso.Client.Configuration;
using Turso.Client.PlatformAPI.Database.Models;
using Turso.Client.PlatformAPI.Database.Models.Request;
using Turso.Client.PlatformAPI.Database.Models.Response;

namespace Turso.Client.PlatformAPI.Database;

/// <summary>
/// A C# service for interacting with the Turso Database API.
/// See <a href="https://docs.turso.tech/api-reference/databases/">Turso Database API</a>
/// </summary>
public class DatabaseService : IDatabaseService
{
    public DatabaseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    /// <summary>
    /// Returns a list of databases belonging to the organization or user.
    /// </summary>
    /// <param name="organizationName">The name of the organization or user.</param>
    /// <returns>
    /// A list of all Databases and their identities found in
    /// <a href="https://docs.turso.tech/api-reference/databases/list">Turso Documentation</a>
    /// </returns>
    public async Task<ListDatabasesResponse> ListDatabasesAsync(string organizationName)
    {
        var requestUri = $"/organizations/{organizationName}/databases";

        try
        {
            var response = await _httpClient.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var tokenResponse =
                await JsonResponseHandler.DeserializeResponseAsync<ListDatabasesResponse>(jsonResponse);

            return tokenResponse ??
                   throw new InvalidOperationException("Failed to deserialize the API token response.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while creating the API token.", e);
        }
    }

    /// <summary>
    /// Creates a new database in a group for the organization or user.
    /// </summary>
    /// <param name="organizationName">The name of the organization or user.</param>
    /// <param name="createRequest">The body of a Database API request with all desired specifications set.</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="ApplicationException"></exception>
    public async Task<CreateDatabaseResponse> CreateDatabaseAsync(string organizationName, CreateDatabaseRequest createRequest)
    {
        var requestUri = $"/organizations/{organizationName}/databases";
        
        var content = new StringContent(JsonSerializer.Serialize(createRequest), Encoding.UTF8, "application/json");

        JsonSerializer.Serialize(createRequest);

        try
        {
            var response = await _httpClient.PostAsync(requestUri, content);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var tokenResponse =
                await JsonResponseHandler.DeserializeResponseAsync<CreateDatabaseResponse>(jsonResponse);

            return tokenResponse ??
                   throw new InvalidOperationException("Failed to deserialize the API token response.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while creating the API token.", e);
        }
    }

    /// <summary>
    /// Returns a database belonging to the organization or user.
    /// </summary>
    /// <param name="organizationName">The name of the organization or the user.</param>
    /// <param name="databaseName">The name of the database.</param>
    /// <returns>A TursoDB Database.</returns>
    public async Task<Models.Database> RetrieveDatabaseAsync(string organizationName, string databaseName)
    {
        var requestUri = $"/organizations/{organizationName}/databases/{databaseName}";
        
        try
        {
            var response = await _httpClient.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var tokenResponse =
                await JsonResponseHandler.DeserializeResponseAsync<Models.Database>(jsonResponse);

            return tokenResponse ??
                   throw new InvalidOperationException("Failed to deserialize the API token response.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while creating the API token.", e);
        }
    }

    public async Task<UpdateDatabaseResponse> UpdateDatabaseConfigurationAsync(string organizationName, string databaseName,
        UpdateConfigurationRequest updateRequest)
    {
        var requestUri = $"/organizations/{organizationName}/databases/{databaseName}/configuration";
        var content = JsonSerializer.Serialize(updateRequest);
        
        try
        {
            var response = await _httpClient.PatchAsync(requestUri, new StringContent(content, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var tokenResponse =
                await JsonResponseHandler.DeserializeResponseAsync<UpdateDatabaseResponse>(jsonResponse);

            return tokenResponse ??
                   throw new InvalidOperationException("Failed to deserialize the API token response.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while creating the API token.", e);
        }
    }

    public async Task<RetrieveDatabaseUsageResponse> GetDatabaseUsageAsync(string organizationName, string databaseName, 
        DateTime from, DateTime to)
    {
        string fromFormatted = from.ToUniversalTime().ToString("u").Replace(" ", "T");
        string toFormatted = to.ToUniversalTime().ToString("u").Replace(" ", "T");
        var requestUri = $"/organizations/{organizationName}/databases/{databaseName}/usage?from={fromFormatted}&to={toFormatted}";
        
        try
        {
            var response = await _httpClient.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var tokenResponse =
                await JsonResponseHandler.DeserializeResponseAsync<RetrieveDatabaseUsageResponse>(jsonResponse);

            return tokenResponse ??
                   throw new InvalidOperationException("Failed to deserialize the API token response.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while creating the API token.", e);
        }
    }

    public async Task<StatsResponse> GetDatabaseStatsAsync(string organizationName, string databaseName)
    {
        throw new NotImplementedException();
    }

    public Task DeleteDatabaseAsync(string organizationName, string databaseName)
    {
        throw new NotImplementedException();
    }

    public async Task<ListInstancesResponse> ListInstancesAsync(string organizationName)
    {
        throw new NotImplementedException();
    }

    public async Task<InstanceResponse> RetrieveInstanceAsync(string organizationName, string instanceId)
    {
        throw new NotImplementedException();
    }

    public async Task<TokenResponse> CreateTokenAsync(CreateTokenRequest tokenRequest)
    {
        throw new NotImplementedException();
    }

    public Task InvalidateTokensAsync(InvalidateTokensRequest invalidateRequest)
    {
        throw new NotImplementedException();
    }

    public async Task<UploadDumpResponse> UploadDumpAsync(string organizationName, UploadDumpRequest uploadRequest)
    {
        throw new NotImplementedException();
    }

    private readonly HttpClient _httpClient;
}