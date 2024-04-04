using Turso.Client.PlatformAPI.Database.Enums;

namespace Turso.Client.PlatformAPI.Database.Models;

/// <summary>
/// The individual primary or replica databases in each region defined by the group.
/// </summary>
public class DatabaseInstance
{
    /// <summary>
    /// The DNS hostname used for client libSQL and HTTP connections (specific to this instance only).
    /// </summary>
    public string Hostname { get; set; }
    
    /// <summary>
    /// The name of the instance (location code).
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// The location code for the region this instance is located.
    /// </summary>
    public string Region { get; set; }
    
    /// <summary>
    /// The type of database instance this, will be primary or replica.
    /// </summary>
    public DatabaseInstanceType Type { get; set; }
    
    /// <summary>
    /// The instance universal unique identifier (UUID).
    /// </summary>
    public string Uuid { get; set; }
}