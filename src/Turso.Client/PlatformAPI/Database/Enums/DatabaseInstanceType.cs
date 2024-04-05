using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Turso.Client.PlatformAPI.Database.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DatabaseInstanceType
{
    [EnumMember(Value = "primary")]
    Primary,
    [EnumMember(Value = "replica")]
    Replica
}