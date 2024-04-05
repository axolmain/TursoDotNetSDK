using System.Text.Json.Serialization;
using Turso.Client.PlatformAPI.Organizations.Members.Enums;

namespace Turso.Client.PlatformAPI.Organizations.Members.Models.Response;

public class AddMemberResponse
{
    /// <summary>
    /// The role assigned to the member, Will be owner, admin, or member.
    /// </summary>
    [JsonPropertyName("role")]
    public OrganizationRole Role { get; set; }
    
    /// <summary>
    /// The username for the member.
    /// </summary>
    [JsonPropertyName("username")]
    public string Username { get; set; }
}