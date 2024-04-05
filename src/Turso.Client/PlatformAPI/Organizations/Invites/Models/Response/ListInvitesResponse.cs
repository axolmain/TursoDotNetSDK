using Turso.Client.PlatformAPI.Organizations.Invites.Models.Objects;

namespace Turso.Client.PlatformAPI.Organizations.Invites.Models.Response;

public class ListInvitesResponse
{
    public Invite[] Invites { get; set; }
}