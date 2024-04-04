using System.Net.Http.Headers;
using Turso.Client.PlatformAPI.APITokens;
using Turso.Client.PlatformAPI.AuditLogs;
using Turso.Client.PlatformAPI.Database;
using Turso.Client.PlatformAPI.Groups;
using Turso.Client.PlatformAPI.Locations;
using Turso.Client.PlatformAPI.Organizations;

namespace Turso.Client.Clients;

public class TursoClient : ITursoClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    private HttpClient HttpClient => _httpClientFactory.CreateClient("TursoClient");

    public TursoClient(IHttpClientFactory httpClientFactory, string apiToken, string baseAddress = "https://api.turso.tech")
    {
        _httpClientFactory = httpClientFactory;
        HttpClient.BaseAddress = new Uri(baseAddress);
        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
    }

    public IDatabaseService Database => _databaseService ??= new DatabaseService(HttpClient);
    public IApiTokenService ApiTokens => _apiTokenService ??= new ApiTokenService(HttpClient);
    public IAuditLogService AuditLogs => _auditLogService ??= new AuditLogService(HttpClient);
    public IGroupsService Groups => _groupsService ??= new GroupsService(HttpClient);
    public ILocationsService Locations => _locationsService ??= new LocationsService(HttpClient);
    public IOrganizationsService Organizations => _organizationsService ??= new OrganizationsService(HttpClient);

    public void Dispose()
    {
        HttpClient.Dispose();
    }

    private IDatabaseService _databaseService;

    private IApiTokenService _apiTokenService;

    private IAuditLogService _auditLogService;

    private IGroupsService _groupsService;

    private ILocationsService _locationsService;

    private IOrganizationsService _organizationsService;

    private static readonly int DefaultMaxRetries = 3;
    private static readonly TimeSpan DefaultRequestTimeout = TimeSpan.FromMilliseconds(30000);
    private static string DefaultBaseUrl = "https://api.turso.tech";
}