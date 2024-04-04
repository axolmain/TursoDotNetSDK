using System.Text.Json;

namespace Turso.Client.Configuration;

public static class JsonResponseHandler
{
    public static async Task<T> DeserializeResponseAsync<T>(Stream jsonResponse)
    {
        try
        {
            var responseObject = await JsonSerializer.DeserializeAsync<T>(jsonResponse,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return responseObject ??
                   throw new InvalidOperationException("Failed to deserialize the API token response.");
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while creating the API token.", e);
        }
    }

    public static T DeserializeResponse<T>(string jsonResponse)
    {
        try
        {
            var responseObject = JsonSerializer.Deserialize<T>(jsonResponse,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return responseObject ??
                   throw new InvalidOperationException("Failed to deserialize the API token response.");
        }
        catch (Exception e)
        {
            throw new ApplicationException("An error occurred while creating the API token.", e);
        }
    }
}