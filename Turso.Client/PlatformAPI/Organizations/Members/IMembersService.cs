namespace Turso.Client.PlatformAPI.Organizations.Members;

public interface IMembersService
{
    Task<ListMembersResponse> ListMembersAsync(string organizationId);
    Task<AddMemberResponse> AddMemberAsync(string organizationId, AddMemberRequest memberRequest);
    Task<RemoveMemberResponse> RemoveMemberAsync(string organizationId, string memberId);
}