using Turso.Client.PlatformAPI.Groups.Models.Objects;
using Group = System.Text.RegularExpressions.Group;

namespace Turso.Client.PlatformAPI.Groups.Models.Response;

public class CreateGroupResponse
{
    public Group Group { get; set; }
}