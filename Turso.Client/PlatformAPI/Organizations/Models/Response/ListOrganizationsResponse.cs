using Turso.Client.PlatformAPI.Organizations.Models.Objects;

namespace Turso.Client.PlatformAPI.Organizations.Models.Response;

public class ListOrganizationsResponse
{
    public Organization[] Organizations { get; set; }
}