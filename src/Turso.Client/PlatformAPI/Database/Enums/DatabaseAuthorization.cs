using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Turso.Client.PlatformAPI.Database.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DatabaseAuthorization
{
    [Description("full-access")]
    [EnumMember(Value = "full-access")]
    FullAcccess,
    
    [Description("read-only")]
    [EnumMember(Value = "read-only")]
    ReadOnly,
}