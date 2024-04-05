using Turso.Client.PlatformAPI.Organizations.Models.Objects;

namespace Turso.Client.PlatformAPI.Organizations.Models.Response;

/// <summary>
/// The response object of the UpdateOrganizationAsync method.
/// See <a href="https://docs.turso.tech/api-reference/organizations/update">Turso API reference</a> for more information.
/// </summary>
public class UpdateOrganizationResponse
{
    /// <summary>
    /// The updated organization.
    /// </summary>
    public Organization Organization { get; set; }
}