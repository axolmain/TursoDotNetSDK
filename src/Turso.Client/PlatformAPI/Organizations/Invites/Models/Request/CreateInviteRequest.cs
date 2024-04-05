using System.Text.Json.Serialization;
using Turso.Client.PlatformAPI.Organizations.Members.Enums;

namespace Turso.Client.PlatformAPI.Organizations.Invites.Models.Request;

/// <summary>
/// The body of the request to create an invite for a member to join an organization.
/// </summary>
public class CreateInviteRequest
{
    /// <summary>
    /// The role of the member to invite, will be admin, or member (cannot set Owner in request).
    /// </summary>
    [JsonPropertyName("role")]
    public OrganizationRole Role { get; set; }
    
    /// <summary>
    /// The email of the user to invite.
    /// </summary>
    [JsonPropertyName("email")]
    public string Eamil { get; set; }
}