using Turso.Client.PlatformAPI.APITokens;
using Turso.Client.PlatformAPI.AuditLogs;
using Turso.Client.PlatformAPI.Database;
using Turso.Client.PlatformAPI.Groups;
using Turso.Client.PlatformAPI.Locations;
using Turso.Client.PlatformAPI.Organizations;

namespace Turso.Client.Clients;

public class TursoClient : ITursoClient
{
    public TursoClient(string apiToken, bool apiVersionOne = true)
    {
        if (apiVersionOne) DefaultBaseUrl = "https://api.turso.tech/v1";

        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(DefaultBaseUrl)
        };
        _httpClient.DefaultRequestHeaders.Add("Bearer", apiToken);
    }

    public IDatabaseService Database => _databaseService ??= new DatabaseService(_httpClient);
    public IApiTokenService ApiTokens => _apiTokenService ??= new ApiTokenService(_httpClient);
    public IAuditLogService AuditLogs => _auditLogService ??= new AuditLogService(_httpClient);
    public IGroupsService Groups => _groupsService ??= new GroupsService(_httpClient);
    public ILocationsService Locations => _locationsService ??= new LocationsService(_httpClient);
    public IOrganizationsService Organizations => _organizationsService ??= new OrganizationsService(_httpClient);

    public void Dispose()
    {
        _httpClient.Dispose();
    }

    private IDatabaseService _databaseService;

    private IApiTokenService _apiTokenService;

    private IAuditLogService _auditLogService;

    private IGroupsService _groupsService;

    private ILocationsService _locationsService;

    private IOrganizationsService _organizationsService;

    private readonly HttpClient _httpClient;
    private static readonly int DefaultMaxRetries = 3;
    private static readonly TimeSpan DefaultRequestTimeout = TimeSpan.FromMilliseconds(30000);
    private static string DefaultBaseUrl = "https://api.turso.tech";
}