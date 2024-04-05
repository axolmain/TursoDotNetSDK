using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Turso.Client.PlatformAPI.Organizations.Members.Enums;

/// <summary>
/// An enum representing all possible roles a member can have in an organization.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrganizationRole
{
    [EnumMember(Value = "owner")]
    Owner,
    [EnumMember(Value = "admin")]
    Admin,
    [EnumMember(Value = "member")]
    Member
}