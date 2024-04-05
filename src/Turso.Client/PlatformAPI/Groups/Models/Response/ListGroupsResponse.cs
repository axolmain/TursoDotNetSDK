using Turso.Client.PlatformAPI.Groups.Models.Objects;

namespace Turso.Client.PlatformAPI.Groups.Models.Response;

public class ListGroupsResponse
{
    public Group[] Groups { get; set; }
}