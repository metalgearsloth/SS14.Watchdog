namespace SS14.Watchdog.Configuration.Updates
{
    /// <summary>
    /// Configuration for <see cref="SS14.Watchdog.Components.Updates.UpdateProviderGit"/>.
    /// </summary>
    public class UpdateProviderGitConfiguration
    {
        /// <summary> Git repository URL. Not to be confused with the other BaseUrl. </summary>
        public string BaseUrl { get; set; } = null!;
        /// <summary> Git repository branch. </summary>
        public string Branch { get; set; } = "master";
        /// <summary> Hybrid ACZ hosts the client zip on the status host for easier port forwarding (no need to forward the watchdog port). </summary>
        public bool HybridACZ { get; set; } = true;
    }
}
