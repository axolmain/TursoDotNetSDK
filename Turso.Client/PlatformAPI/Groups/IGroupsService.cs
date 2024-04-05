using Turso.Client.PlatformAPI.Database.Models.Request;
using Turso.Client.PlatformAPI.GenericModels;
using Turso.Client.PlatformAPI.Groups.Models.Objects;
using Turso.Client.PlatformAPI.Groups.Models.Request;
using Turso.Client.PlatformAPI.Groups.Models.Response;
using Turso.Client.PlatformAPI.Locations.Enums;
using CreateTokenResponse = Turso.Client.PlatformAPI.Groups.Models.Response.CreateTokenResponse;

namespace Turso.Client.PlatformAPI.Groups;

public interface IGroupsService
{
    /// <summary>
    /// Gets a list of groups belonging to the organization or user.
    /// </summary>
    /// <param name="organizationName">The name of the organization or user.</param>
    /// <returns>A list of groups belonging to the organization or user</returns>
    Task<ListGroupsResponse> ListGroupsAsync(string organizationName);

    /// <summary>
    /// Creates a new group for the organization or user.
    /// </summary>
    /// <param name="organizationName">The name of the organization or user.</param>
    /// <param name="createRequest">The body of the Request to create a new group.</param>
    /// <returns>The new group which has been created.</returns>
    Task<CreateGroupResponse> CreateGroupAsync(string organizationName, CreateGroupRequest createRequest);

    /// <summary>
    /// Gets a group belonging to the organization or user.
    /// </summary>
    /// <param name="organizationName">The name of the organization or user.</param>
    /// <param name="groupName">The name of the group.</param>
    /// <returns>The group belonging to the organization or user.</returns>
    Task<Group> RetrieveGroupAsync(string organizationName, string groupName);
    Task<DeleteGroupResponse> DeleteGroupAsync(string organizationName, string groupName);
    Task<TransferGroupResponse> TransferGroupAsync(string organizationName, string groupName, TransferGroupRequest transferRequest);
    Task<AddGroupLocationResponse> AddGroupLocationAsync(string organizationName, string groupName, LocationCode locationCode);
    Task<RemoveGroupLocationResponse> RemoveGroupLocationAsync(string organizationName, string groupName, LocationCode locationCode);
    Task UpdateVersionsAsync(string organizationName, string groupName);
    Task<CreateTokenResponse> CreateTokenAsync(string organizationName, string groupName, CreateTokenRequest tokenRequest);
    Task InvalidateTokensAsync(string organizationName, string groupName);
}