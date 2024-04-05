using Turso.Client.PlatformAPI.APITokens;
using Turso.Client.PlatformAPI.AuditLogs;
using Turso.Client.PlatformAPI.Database;
using Turso.Client.PlatformAPI.Groups;
using Turso.Client.PlatformAPI.Locations;
using Turso.Client.PlatformAPI.Organizations;

namespace Turso.Client.Clients;

public interface ITursoClient
{
    IDatabaseService Database { get; }
    IApiTokenService ApiTokens { get; }
    IAuditLogService AuditLogs { get; }
    IGroupsService Groups { get; }
    ILocationsService Locations { get; }
    IOrganizationsServiceClient Organizations { get; }
}