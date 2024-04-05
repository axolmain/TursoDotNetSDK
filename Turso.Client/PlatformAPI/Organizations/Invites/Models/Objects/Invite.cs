using Turso.Client.PlatformAPI.Organizations.Models;
using Turso.Client.PlatformAPI.Organizations.Models.Objects;

namespace Turso.Client.PlatformAPI.Organizations.Invites.Models.Objects;

public class Invite
{
    public bool Accepted { get; set; }
    public string CreatedAt { get; set; }
    public string DeletedAt { get; set; }
    public string Email { get; set; }
    public int ID { get; set; }
    public Organization Organization { get; set; }
    public int OrganizationID { get; set; }
    public string Role { get; set; }
    public string Token { get; set; }
    public string UpdatedAt { get; set; }
}