using Turso.Client.PlatformAPI.Organizations.Invites;
using Turso.Client.PlatformAPI.Organizations.Members;

namespace Turso.Client.Clients;

public class OrganizationsServiceClient : IOrganizationsServiceClient
{
    public IMembersService Member { get; }
    public IInvitesService Invite { get; }

    public OrganizationsServiceClient(HttpClient httpClient)
    {
        Member = new MembersService(httpClient);
        Invite = new InvitesService(httpClient);
    }
}