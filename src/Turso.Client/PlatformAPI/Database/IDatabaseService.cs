using Turso.Client.PlatformAPI.Database.Enums;
using Turso.Client.PlatformAPI.Database.Models;
using Turso.Client.PlatformAPI.Database.Models.Request;
using Turso.Client.PlatformAPI.Database.Models.Response;
using Turso.Client.PlatformAPI.GenericModels;

namespace Turso.Client.PlatformAPI.Database;

public interface IDatabaseService
{
    /// <summary>
    /// Returns a list of databases belonging to the organization or user.
    /// </summary>
    /// <param name="organizationName">The name of the organization or user.</param>
    /// <returns>
    /// A list of all Databases and their identities found in
    /// <a href="https://docs.turso.tech/api-reference/databases/list">Turso Documentation</a>
    /// </returns>
    Task<ListDatabasesResponse> ListDatabasesAsync(string organizationName);
    
    /// <summary>
    /// Creates a new database in a group for the organization or user.
    /// </summary>
    /// <param name="organizationName">The name of the organization or user.</param>
    /// <param name="createRequest">The body of a Database API Request with all desired specifications set.</param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="ApplicationException"></exception>
    Task<CreateDatabaseResponse> CreateDatabaseAsync(string organizationName, CreateDatabaseRequest createRequest);
    
    /// <summary>
    /// Gets a database belonging to the organization or user.
    /// </summary>
    /// <param name="organizationName">The name of the organization or the user.</param>
    /// <param name="databaseName">The name of the database.</param>
    /// <returns>A TursoDB Database.</returns>
    Task<Models.Database> GetDatabaseAsync(string organizationName, string databaseName);
    Task<UpdateDatabaseResponse> UpdateDatabaseConfigurationAsync(string organizationName, string databaseName, 
        UpdateConfigurationRequest updateRequest);
    Task<GetDatabaseUsageResponse> GetDatabaseUsageAsync(string organizationName, string databaseName, DateTime from, 
        DateTime to);
    Task<GetDatabaseStatsResponse> GetDatabaseStatsAsync(string organizationName, string databaseName);
    Task<DeleteDatabaseResponse> DeleteDatabaseAsync(string organizationName, string databaseName);
    
    /// <summary>
    /// Returns a list of instances of a database. Instance are the individual primary or replica databases in each
    /// region defined by the group.
    /// </summary>
    /// <param name="organizationName">The name of the organization or user</param>
    /// <param name="databaseName">The name of the database</param>
    /// <returns>A list of instances of a database.</returns>
    Task<ListInstancesResponse> ListInstancesAsync(string organizationName, string databaseName);
    Task<RetrieveInstanceResponse> GetInstanceAsync(string organizationName, string databaseName, string instanceName);
    Task<CreateTokenResponse> CreateTokenAsync(string organizationName, string databaseName, CreateTokenRequest tokenRequest);
    
    /// <summary>
    /// Invalidates all authorization tokens for the specified database.
    /// **Warning:** A short period of downtime is required while the tokens are being invalidated.
    /// </summary>
    /// <param name="organizationName">The name of the organization or user.</param>
    /// <param name="databaseName">The name of the database</param>
    /// <returns></returns>
    Task InvalidateTokensAsync(string organizationName, string databaseName);
    Task<UploadDumpResponse> UploadDumpAsync(string organizationName, string databaseName, UploadDumpRequest uploadDumpRequest);
    
}