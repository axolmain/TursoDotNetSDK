namespace Turso.Client.PlatformAPI.GenericModels;

public class CreateTokenResponse
{
    /// <summary>
    /// The generated authorization token (JWT).
    /// </summary>
    public string Jwt { get; set; }
}