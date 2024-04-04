using System.Text;
using Turso.Client.Configuration;
using Turso.Client.PlatformAPI.APITokens.Models;

namespace Turso.Client.PlatformAPI.APITokens;

public class ApiTokenService : IApiTokenService
{
    public ApiTokenService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CreateApiTokenResponse> CreateApiTokenAsync(string tokenName)
    {
        var requestUri = $"/auth/api-tokens/{tokenName}";
        var content = new StringContent("", Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync(requestUri, content);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var tokenResponse =
                await JsonResponseHandler.DeserializeResponseAsync<CreateApiTokenResponse>(jsonResponse);

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

    public async Task<ValidateApiTokenResponse> ValidateApiTokenAsync()
    {
        var requestUri = "/auth/validate";

        try
        {
            var response = await _httpClient.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var tokenResponse =
                await JsonResponseHandler.DeserializeResponseAsync<ValidateApiTokenResponse>(jsonResponse);

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

    public async Task<ListApiTokenResponse> ListApiTokensAsync()
    {
        var requestUri = "/auth/api-tokens";

        try
        {
            var response = await _httpClient.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var tokenResponse =
                await JsonResponseHandler.DeserializeResponseAsync<ListApiTokenResponse>(jsonResponse);

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

    public async Task<RevokedApiTokenResponse> RevokeApiTokensAsync(string tokenName)
    {
        var requestUri = $"/auth/api-tokens/{tokenName}";

        try
        {
            var response = await _httpClient.DeleteAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var tokenResponse =
                await JsonResponseHandler.DeserializeResponseAsync<RevokedApiTokenResponse>(jsonResponse);

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

    private readonly HttpClient _httpClient;
}