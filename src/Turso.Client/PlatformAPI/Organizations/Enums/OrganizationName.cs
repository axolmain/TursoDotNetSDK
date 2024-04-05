using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Turso.Client.PlatformAPI.Organizations.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrganizationName
{
    [EnumMember(Value = "personal")]
    Personal,
    [EnumMember(Value = "team")]
    Team
}