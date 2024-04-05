namespace Turso.Client.PlatformAPI.APITokens.Models;

/// <summary>
/// Revokes the provided API token belonging to a user. See
/// <a href="https://docs.turso.tech/api-reference/tokens/revoke">Turso documentation</a>
/// </summary>
public class RevokedApiTokenResponse
{
    /// <summary>
    /// The revoked token name.
    /// </summary>
    public string Token { get; set; }
}