namespace NorthStar.Infrastructure.Authentication;
public sealed class AuthenticationOptions
{
    public string Audience { get; init; } = string.Empty;

    public string MetadataUrl { get; init; } = string.Empty;

    public bool RequireHttpsMetadata { get; set; }

    public string Issuer { get; set; } = string.Empty;
}
