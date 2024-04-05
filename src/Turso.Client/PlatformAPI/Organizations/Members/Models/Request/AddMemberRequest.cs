using System.Text.Json.Serialization;
using Turso.Client.PlatformAPI.Organizations.Members.Enums;

namespace Turso.Client.PlatformAPI.Organizations.Members.Models.Request;

/// <summary>
/// The body of the request to add a member to an organization.
/// </summary>
public class AddMemberRequest
{
    /// <summary>
    /// The role assigned to the member, Will be admin, or member (cannot set Owner in request).
    /// </summary>
    [JsonPropertyName("role")]
    public OrganizationRole Role { get; set; }
    
    /// <summary>
    /// The username for the member.
    /// </summary>
    [JsonPropertyName("username")]
    public string Username { get; set; }
}