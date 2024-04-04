using System.ComponentModel;

namespace Turso.Client.PlatformAPI.Database.Enums;

public enum DatabaseAuthorization
{
    [Description("full-access")]
    FullAcccess,
    
    [Description("full-access")]
    ReadOnly,
}