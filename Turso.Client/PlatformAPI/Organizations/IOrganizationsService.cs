namespace Turso.Client.PlatformAPI.Organizations;

public interface IOrganizationsService
{
    Task<ListOrganizationsResponse> ListOrganizationsAsync();
    Task<UpdateOrganizationResponse> UpdateOrganizationAsync(string organizationId, UpdateOrganizationRequest updateRequest);
}