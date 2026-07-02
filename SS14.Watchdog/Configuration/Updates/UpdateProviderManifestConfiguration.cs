namespace SS14.Watchdog.Configuration.Updates
{
    /// <summary>
    /// Configuration for <see cref="SS14.Watchdog.Components.Updates.UpdateProviderManifest"/>.
    /// </summary>
    public class UpdateProviderManifestConfiguration
    {
        public string ManifestUrl { get; set; } = null!;
        public ManifestAuthenticationConfiguration? Authentication { get; set; }
    }

    public sealed class ManifestAuthenticationConfiguration
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
