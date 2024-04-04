namespace Turso.Client.PlatformAPI.Organizations.Invites;

public interface IInvitesService
{
    Task<ListInvitesResponse> ListInvitesAsync(string organizationId);
    Task<CreateInviteResponse> CreateInviteAsync(string organizationId, CreateInviteRequest inviteRequest);
}