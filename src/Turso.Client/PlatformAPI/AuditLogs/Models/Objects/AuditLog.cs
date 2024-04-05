using System.Text.Json;
using Turso.Client.PlatformAPI.AuditLogs.Enum;

namespace Turso.Client.PlatformAPI.AuditLogs.Models.Objects;

public class AuditLog
{
    public string Author { get; set; }
    public AuditLogCodes Code { get; set; }
    public string CreatedAt { get; set; }
    public JsonElement Data { get; set; }
    public string Message { get; set; }
    public string Origin { get; set; }
}
