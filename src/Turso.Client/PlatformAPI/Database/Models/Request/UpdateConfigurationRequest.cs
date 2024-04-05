namespace Turso.Client.PlatformAPI.Database.Models.Request;

public class UpdateConfigurationRequest
{
    /// <summary>
    /// Allow or disallow attaching databases to the current database.
    /// </summary>
    public bool AllowAttach { get; set; }
    
    /// <summary>
    /// The maximum size of the database in bytes. Values with units are also accepted, e.g. 1mb, 256mb, 1gb.
    /// </summary>
    public string SizeLimit { get; set; }
}