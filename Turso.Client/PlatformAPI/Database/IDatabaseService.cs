using Turso.Client.PlatformAPI.Database.Models;
using Turso.Client.PlatformAPI.Database.Models.Request;
using Turso.Client.PlatformAPI.Database.Models.Response;

namespace Turso.Client.PlatformAPI.Database;

public interface IDatabaseService
{
    Task<ListDatabasesResponse> ListDatabasesAsync(string organizationName);
    Task<CreateDatabaseResponse> CreateDatabaseAsync(string organizationName, CreateDatabaseRequest createRequest);
    Task<Models.Database> RetrieveDatabaseAsync(string organizationName, string databaseName);
    Task<UpdateDatabaseResponse> UpdateDatabaseConfigurationAsync(string organizationName, string databaseName, UpdateConfigurationRequest updateRequest);
    Task<UsageResponse> GetDatabaseUsageAsync(string organizationName, string databaseName);
    Task<StatsResponse> GetDatabaseStatsAsync(string organizationName, string databaseName);
    Task DeleteDatabaseAsync(string organizationName, string databaseName);
    Task<ListInstancesResponse> ListInstancesAsync(string organizationName);
    Task<InstanceResponse> RetrieveInstanceAsync(string organizationName, string instanceId);
    Task<TokenResponse> CreateTokenAsync(CreateTokenRequest tokenRequest);
    Task InvalidateTokensAsync(InvalidateTokensRequest invalidateRequest);
    Task<UploadDumpResponse> UploadDumpAsync(string organizationName, UploadDumpRequest uploadRequest);
    
}