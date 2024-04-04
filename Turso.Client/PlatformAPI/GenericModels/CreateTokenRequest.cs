namespace Turso.Client.PlatformAPI.GenericModels;

/// <summary>
/// Represents a request to create a new API token for a Turso database.
/// </summary>
public class CreateTokenRequest
{
    /// <summary>
    /// Gets or sets the expiration of the token.
    /// This could be a time span (e.g., "2w" for two weeks, "3d" for three days) or "never" for tokens that do not expire.
    /// </summary>
    public string Expiration { get; set; }

    /// <summary>
    /// Gets or sets the authorization level of the token.
    /// This could be an enum or a string depending on how authorization levels are defined in your API.
    /// For example, "Read", "Write", "FullAccess", etc.
    /// </summary>
    public string Authorization { get; set; }

    // You might have additional properties here depending on your API's requirements.

    public CreateTokenRequest(string expiration, string authorization)
    {
        Expiration = expiration;
        Authorization = authorization;
    }
}