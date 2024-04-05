using Turso.Client.PlatformAPI.Organizations.Invites.Models.Request;
using Turso.Client.PlatformAPI.Organizations.Invites.Models.Response;

namespace Turso.Client.PlatformAPI.Organizations.Invites;

public interface IInvitesService
{
    /// <summary>
    /// Gets a list of invites for the organization.
    /// </summary>
    /// <param name="organizationName">The name of the organization or user.</param>
    /// <returns>A list of invites for the organization.</returns>
    Task<ListInvitesResponse> ListInvitesAsync(string organizationName);
    
    /// <summary>
    /// Invite a user to an organization.
    /// If you want to invite someone who is already a registered Turso user, you can add them instead. <see cref="Turso.Client.PlatformAPI.Organizations.Members.MembersService.AddMemberAsync">AddMemberAsync</see>
    /// You must be an owner or admin to invite other users. You can only invite users to a team and not your personal account.
    /// </summary>
    /// <param name="organizationName">The name of the organization or user.</param>
    /// <param name="inviteRequest">The body of the invite user request.</param>
    /// <returns>The invited user data object.</returns>
    Task<CreateInviteResponse> CreateInviteAsync(string organizationName, CreateInviteRequest inviteRequest);
}