namespace Turso.Client.PlatformAPI.AuditLogs;

public interface IAuditLogService
{
    Task<ListAuditLogsResponse> ListAuditLogsAsync();
}