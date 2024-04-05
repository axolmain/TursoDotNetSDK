using Turso.Client.PlatformAPI.AuditLogs.Models.Objects;

namespace Turso.Client.PlatformAPI.AuditLogs.Models.Response;

public class ListAuditLogsResponse
{
    public AuditLog[] AuditLogs { get; set; }
    
}