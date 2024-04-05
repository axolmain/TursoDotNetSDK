using Turso.Client.PlatformAPI.Organizations.Invites;
using Turso.Client.PlatformAPI.Organizations.Members;
using Turso.Client.PlatformAPI.Organizations.Models;
using Turso.Client.PlatformAPI.Organizations.Models.Request;
using Turso.Client.PlatformAPI.Organizations.Models.Response;

namespace Turso.Client.PlatformAPI.Organizations;

public interface IOrganizationsService
{
    IInvitesService Invites { get; }
    IMembersService Members { get; }
    Task<ListOrganizationsResponse> ListOrganizationsAsync();
    
    Task<UpdateOrganizationResponse> UpdateOrganizationAsync(string organizationName, UpdateOrganizationRequest updateRequest);
}