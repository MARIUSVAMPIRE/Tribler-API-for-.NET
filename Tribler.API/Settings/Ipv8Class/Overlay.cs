namespace Tribler.API
{
    public partial class Settings
    {
        public partial class Ipv8Class
        {
            public partial class OverlayBase
            {
                internal string Class { get; init; }
                internal string Key { get; init; }
                internal List<WorkerBase> Workers { get; init; }
                internal List<BootstrapperBase> Bootstrappers { get; init; }
                internal InitializeClass Initialize { get; init; }
                internal List<OnStartBase> OnStart { get; init; }
            }
        }
    }
}