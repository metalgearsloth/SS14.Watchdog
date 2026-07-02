namespace SS14.Watchdog.Configuration.Updates
{
    /// <summary>
    /// Configuration for <see cref="SS14.Watchdog.Components.Updates.UpdateProviderLocal"/>.
    /// </summary>
    public sealed class UpdateProviderLocalConfiguration
    {
        public string CurrentVersion { get; set; } = null!;
    }
}
