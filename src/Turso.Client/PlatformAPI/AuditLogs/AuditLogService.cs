using Turso.Client.Configuration;
using Turso.Client.PlatformAPI.AuditLogs.Models.Response;

namespace Turso.Client.PlatformAPI.AuditLogs;

public class AuditLogService : IAuditLogService
{
    private readonly HttpClient _httpClient;

    public AuditLogService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ListAuditLogsResponse> ListAuditLogsAsync(string organizationName)
    {
        var requestUri = $"organizations/{organizationName}/audit-logs";

        try
        {
            var response = await _httpClient.GetAsync(requestUri);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();

            var listInvitesResponse = await JsonResponseHandler.DeserializeResponseAsync<ListAuditLogsResponse>(jsonResponse);

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
}