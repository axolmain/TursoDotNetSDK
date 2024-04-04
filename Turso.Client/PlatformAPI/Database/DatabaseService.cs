using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Turso.Client.Configuration;
using Turso.Client.PlatformAPI.Database.Enums;
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
    
    /// <inheritdoc />
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

    /// <inheritdoc />
    public async Task<CreateDatabaseResponse> CreateDatabaseAsync(string organizationName, CreateDatabaseRequest createRequest)
    {
        var requestUri = $"/organizations/{organizationName}/databases";
        
        var content = new StringContent(JsonSerializer.Serialize(createRequest), Encoding.UTF8, "application/json");

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

    public async Task<Models.Database> GetDatabaseAsync(string organizationName, string databaseName)
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
                   throw new InvalidOperationException($"Failed to deserialize the UpdateDatabase response for {databaseName}.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"An error occurred while updating the database {databaseName}.", e);
        }
    }

    public async Task<GetDatabaseUsageResponse> GetDatabaseUsageAsync(string organizationName, string databaseName, 
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
                await JsonResponseHandler.DeserializeResponseAsync<GetDatabaseUsageResponse>(jsonResponse);

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

    public async Task<GetDatabaseStatsResponse> GetDatabaseStatsAsync(string organizationName, string databaseName)
    {
        var requestUri = $"/organizations/{organizationName}/databases/{databaseName}/stats";
        
        try
        {
            var response = await _httpClient.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var tokenResponse =
                await JsonResponseHandler.DeserializeResponseAsync<GetDatabaseStatsResponse>(jsonResponse);

            return tokenResponse ??
                   throw new InvalidOperationException($"Failed to get the database stats for {databaseName}.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"An error occurred while getting the database stats for {databaseName}.", e);
        }
    }

    public async Task<DeleteDatabaseResponse> DeleteDatabaseAsync(string organizationName, string databaseName)
    {
        var requestUri = $"/organizations/{organizationName}/database/{databaseName}";

        try
        {
            var response = await _httpClient.DeleteAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var tokenResponse =
                await JsonResponseHandler.DeserializeResponseAsync<DeleteDatabaseResponse>(jsonResponse);

            return tokenResponse ??
                   throw new InvalidOperationException("Failed to deserialize the DeleteDatabase response.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"An error occurred while deleting the database {databaseName} " +
                                           $"from the organization {organizationName}.", e);
        }
    }
    
    public async Task<ListInstancesResponse> ListInstancesAsync(string organizationName, string databaseName)
    {
        var requestUri = $"/organizations/{organizationName}/databases/{databaseName}/instances";
        
        try
        {
            var response = await _httpClient.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var tokenResponse =
                await JsonResponseHandler.DeserializeResponseAsync<ListInstancesResponse>(jsonResponse);

            return tokenResponse ??
                   throw new InvalidOperationException($"Failed to get the list of {databaseName} instances.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"An error occurred while getting the list of {databaseName} instances.", e);
        }
    }

    public async Task<RetrieveInstanceResponse> GetInstanceAsync(string organizationName, string databaseName, string instanceName)
    {
        var requestUri = $"/organizations/{organizationName}/databases/{databaseName}/instances/{instanceName}";
        
        try
        {
            var response = await _httpClient.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var tokenResponse =
                await JsonResponseHandler.DeserializeResponseAsync<RetrieveInstanceResponse>(jsonResponse);

            return tokenResponse ??
                   throw new InvalidOperationException($"Failed to get the database stats for {databaseName}.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"An error occurred while getting the database stats for {databaseName}.", e);
        }
    }

    public async Task<CreateTokenResponse> CreateTokenAsync(string organizationName, string databaseName, 
        CreateTokenRequest createTokenRequest)
    {
        var requestUri = $"/organizations/{organizationName}/databases/{databaseName}/auth/tokens";
        var content = new StringContent(JsonSerializer.Serialize(createTokenRequest), Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync(requestUri, content);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var tokenResponse = await JsonResponseHandler.DeserializeResponseAsync<CreateTokenResponse>(jsonResponse);

            return tokenResponse ?? throw new InvalidOperationException("Failed to deserialize the CreateToken response.");
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred while creating a token.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"An error occurred while creating a token for the database {databaseName}.", e);
        }
    }


    public async Task InvalidateTokensAsync(string organizationName, string databaseName)
    {
        var requestUri = $"/organizations/{organizationName}/databases/{databaseName}/auth/rotate";

        try
        {
            var response = await _httpClient.PostAsync(requestUri, null); // Assuming no body is required
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred while invalidating tokens.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"An error occurred while invalidating tokens for the database {databaseName}.", e);
        }
    }


    public async Task<UploadDumpResponse> UploadDumpAsync(string organizationName, string databaseName,
        UploadDumpRequest uploadDumpRequest)
    {
        var requestUri = $"/organizations/{organizationName}/databases/{databaseName}/dumps";

        try
        {
            using (var content = new MultipartFormDataContent())
            {
                var fileContent = new ByteArrayContent(uploadDumpRequest.DumpFileContent);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                content.Add(fileContent, "file", uploadDumpRequest.FileName);
                var response = await _httpClient.PostAsync(requestUri, content);

                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStreamAsync();
                var dumpResponse = await JsonResponseHandler.DeserializeResponseAsync<UploadDumpResponse>(jsonResponse);
                return dumpResponse ??
                       throw new InvalidOperationException("Failed to deserialize the UploadDump response.");
            }
        }
        catch (HttpRequestException e)
        {
            throw new ApplicationException("A network error occurred while uploading a dump.", e);
        }
        catch (Exception e)
        {
            throw new ApplicationException($"An error occurred while uploading a dump to the database {databaseName}.",
                e);
        }
    }

    private readonly HttpClient _httpClient;
}