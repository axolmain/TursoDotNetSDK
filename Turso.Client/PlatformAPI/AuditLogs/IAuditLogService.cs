using Turso.Client.PlatformAPI.AuditLogs.Models.Response;

namespace Turso.Client.PlatformAPI.AuditLogs;

public interface IAuditLogService
{
    /// <summary>
    /// Gets the audit logs for the given organization, ordered by the created_at field in descending order.
    /// </summary>
    /// <param name="organizationName">The name of the organization or the user.</param>
    /// <returns>An list of audit logs ordered by the creation date.</returns>
    Task<ListAuditLogsResponse> ListAuditLogsAsync(string organizationName);
}