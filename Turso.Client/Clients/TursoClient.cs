using System.Net.Http.Headers;
using Turso.Client.PlatformAPI.APITokens;
using Turso.Client.PlatformAPI.AuditLogs;
using Turso.Client.PlatformAPI.Database;
using Turso.Client.PlatformAPI.Groups;
using Turso.Client.PlatformAPI.Locations;

namespace Turso.Client.Clients;

public class TursoClient : ITursoClient
{
    public TursoClient(IHttpClientFactory httpClientFactory, string apiToken, string baseAddress = "https://api.turso.tech/v1")
    {
        _httpClientFactory = httpClientFactory;
        _apiToken = apiToken;
        _baseAddress = baseAddress;

        InitializeServices();
    }

    private void InitializeServices()
    {
        _databaseService = new Lazy<IDatabaseService>(() => new DatabaseService(CreateConfiguredHttpClient()));
        _apiTokenService = new Lazy<IApiTokenService>(() => new ApiTokenService(CreateConfiguredHttpClient()));
        _auditLogService = new Lazy<IAuditLogService>(() => new AuditLogService(CreateConfiguredHttpClient()));
        _groupsService = new Lazy<IGroupsService>(() => new GroupsService(CreateConfiguredHttpClient()));
        _locationsService = new Lazy<ILocationsService>(() => new LocationsService(CreateConfiguredHttpClient()));
        _organizationsService = new Lazy<IOrganizationsServiceClient>(() => new OrganizationsServiceClient(CreateConfiguredHttpClient()));
    }

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _apiToken;
    private readonly string _baseAddress;
    
    public IDatabaseService Database => _databaseService.Value;
    public IApiTokenService ApiTokens => _apiTokenService.Value;
    public IAuditLogService AuditLogs => _auditLogService.Value;
    public IGroupsService Groups => _groupsService.Value;
    public ILocationsService Locations => _locationsService.Value;
    public IOrganizationsServiceClient Organizations => _organizationsService.Value;

    private HttpClient CreateConfiguredHttpClient()
    {
        var client = _httpClientFactory.CreateClient();
        client.BaseAddress = new Uri(_baseAddress);
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiToken);
        return client;
    }

    private Lazy<IDatabaseService> _databaseService;
    private Lazy<IApiTokenService> _apiTokenService;
    private Lazy<IAuditLogService> _auditLogService;
    private Lazy<IGroupsService> _groupsService;
    private Lazy<ILocationsService> _locationsService;
    private Lazy<IOrganizationsServiceClient> _organizationsService;

    private static readonly int DefaultMaxRetries = 3;
    private static readonly TimeSpan DefaultRequestTimeout = TimeSpan.FromMilliseconds(30000);
    private static string DefaultBaseUrl = "https://api.turso.tech";
}