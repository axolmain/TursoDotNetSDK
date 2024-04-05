namespace Turso.Client.PlatformAPI.Organizations.Models.Request;

/// <summary>
/// The body of the request to update an organization.
/// </summary>
public class UpdateOrganizationRequest
{
    /// <summary>
    /// Enable or disable overages for the organization.
    /// </summary>
    public bool Overages { get; set; }
}