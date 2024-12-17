namespace Tribler.API
{
    public partial class Settings
    {
        public partial class UserActivityClass
        {
            internal bool Enabled { get; init; }
            internal int MaxQueryHistory { get; init; }
            internal float HealthCheckInterval { get; init; }
        }
    }
}
