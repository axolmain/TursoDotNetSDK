using Turso.Client.PlatformAPI.Organizations.Members.Enums;

namespace Turso.Client.PlatformAPI.Organizations.Members.Models.Objects;

/// <summary>
/// An object representing a member of an organization.
/// </summary>
public class OrganizationMember
{
    /// <summary>
    /// The email for the member.
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// The role assigned to the member. Will be owner, admin or member.
    /// </summary>
    public OrganizationRole Role { get; set; }
    
    /// <summary>
    /// The username for the member.
    /// </summary>
    public string Username { get; set; }
}