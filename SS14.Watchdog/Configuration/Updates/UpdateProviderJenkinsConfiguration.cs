namespace SS14.Watchdog.Configuration.Updates
{
    /// <summary>
    /// Configuration for <see cref="SS14.Watchdog.Components.Updates.UpdateProviderJenkins"/>.
    /// </summary>
    public sealed class UpdateProviderJenkinsConfiguration
    {
        public string BaseUrl { get; set; } = null!;
        public string JobName { get; set; } = null!;
    }
}
