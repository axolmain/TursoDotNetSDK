using Turso.Client.PlatformAPI.Groups.Models.Objects;

namespace Turso.Client.PlatformAPI.Groups.Models.Request;

/// <summary>
/// Represents a request to create a group.
/// </summary>
public class CreateGroupRequest
{
    /// <summary>
    /// Initializes a new instance of this class.
    /// </summary>
    /// <param name="location">The location key for the new group.</param>
    /// <param name="name">The name of the new group.</param>
    public CreateGroupRequest(string location, string name)
    {
        Location = location;
        Name = name;
    }

    /// <summary>
    /// Gets or sets the extensions to enable for new databases created in this group.
    /// </summary>
    public List<GroupExtension> Extensions { get; set; } = new();

    /// <summary>
    /// Gets the location key for the new group.
    /// </summary>
    public string Location { get; }

    /// <summary>
    /// Gets the name of the new group.
    /// </summary>
    public string Name { get; }
}