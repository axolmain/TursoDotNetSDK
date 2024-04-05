// Turso.Client/Configuration/TursoClientServiceExtensions.cs

using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Turso.Client.Clients;
using Turso.Client.PlatformAPI.APITokens;
using Turso.Client.PlatformAPI.AuditLogs;
using Turso.Client.PlatformAPI.Database;
using Turso.Client.PlatformAPI.Groups;
using Turso.Client.PlatformAPI.Locations;
using Turso.Client.PlatformAPI.Organizations;

namespace Turso.Client.Configuration;

public static class TursoClientServiceExtensions
{
    public static IServiceCollection AddTursoClient(this IServiceCollection services, string baseAddress,
        string authToken)
    {
        services.AddHttpClient("TursoClient", client =>
        {
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
        });

        services.AddSingleton<ITursoClient, TursoClient>();

        // Singleton services
        services.AddSingleton<IApiTokenService, ApiTokenService>();
        services.AddSingleton<ILocationsService, LocationsService>();

        // Scoped services
        services.AddScoped<IDatabaseService, DatabaseService>();
        services.AddScoped<IGroupsService, GroupsService>();
        services.AddScoped<IOrganizationsService, OrganizationsService>();

        // Transient services
        services.AddTransient<IAuditLogService, AuditLogService>();

        return services;
    }
}