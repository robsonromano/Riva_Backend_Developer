namespace IntelSyncStarter.Domain.Entities
{
    /// <summary>
    /// Represents application-level settings loaded from configuration.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Number of items to process in each batch of sync jobs.
        /// </summary>
        public int BatchSize { get; set; }

        /// <summary>
        /// Maximum number of parallel threads to use for processing.
        /// </summary>
        public int ParallelProcess { get; set; }
    }
}
