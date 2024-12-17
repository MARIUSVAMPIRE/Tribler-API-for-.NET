namespace Tribler.API
{
    public partial class Settings
    {
        public partial class Configuration
        {
            public partial class Ipv8Class
            {
                public partial class OverlayClass
                {
                    public string Class { get; init; }
                    public string Key { get; init; }
                    public WalkerClass[] Walkers { get; init; }
                    public BootstrapperClass[] Bootstrappers { get; init; }
                    public InitializeClass Initialize { get;init; }
                    public string[] On_start {  get; init; }
                }
            }
        }
    }
}