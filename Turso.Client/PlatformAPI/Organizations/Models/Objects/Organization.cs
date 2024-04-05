namespace Turso.Client.PlatformAPI.Organizations.Models.Objects;

public class Organization
{
    /// <summary>
    /// Returns the current status for blocked reads.
    /// </summary>
    public bool BlockedReads { get; set; }
    
    /// <summary>
    /// Returns the current status for blocked writes.
    /// </summary>
    public bool BlockedWrites { get; set; }
    
    /// <summary>
    /// The organization name. Every user has a personal organization for their own account.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// The name of the organization. Every user has a personal organization for their own account.
    /// </summary>
    public bool Overages { get; set; }
    
    /// <summary>
    /// The organization slug. This will be your username for personal accounts.
    /// </summary>
    public string Slug { get; set; }
    
    /// <summary>
    /// The type of account this organization is. Will always be personal or team.
    /// </summary>
    public string Type { get; set; }
}