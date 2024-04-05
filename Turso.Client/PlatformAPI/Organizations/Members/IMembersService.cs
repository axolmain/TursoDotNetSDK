using Turso.Client.PlatformAPI.Organizations.Members.Models.Request;
using Turso.Client.PlatformAPI.Organizations.Members.Models.Response;

namespace Turso.Client.PlatformAPI.Organizations.Members;

public interface IMembersService
{
    /// <summary>
    /// Gets a list of members part of the organization.
    /// </summary>
    /// <param name="organizationName">The name of the organization or user.</param>
    /// <returns>A list of members part of the organization.</returns>
    Task<ListMembersResponse> ListMembersAsync(string organizationName);
    
    /// <summary>
    /// Add an existing Turso user to an organization.
    /// </summary>
    /// <param name="organizationName">The name of the organization or user.</param>
    /// <param name="memberRequest">The body of the request to add a Turso member to your organization. Reminder: You cannot add an Owner via the API.</param>
    /// <returns>The added member and their role.</returns>
    Task<AddMemberResponse> AddMemberAsync(string organizationName, AddMemberRequest memberRequest);
    
    /// <summary>
    /// Removes a user from the organization by username.
    /// </summary>
    /// <param name="organizationName">The name of the organization or user.</param>
    /// <param name="username">The username of a Turso user or organization member.</param>
    /// <returns>The username of the deleted user.</returns>
    Task<RemoveMemberResponse> RemoveMemberAsync(string organizationName, string username);
}