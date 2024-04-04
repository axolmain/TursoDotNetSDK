namespace Turso.Client.PlatformAPI.APITokens.Models;

public class ListApiTokenResponse
{
    public Tokens[] Tokens { get; set; }
}

public class Tokens
{
    public string Id { get; set; }
    public string Name { get; set; }
}