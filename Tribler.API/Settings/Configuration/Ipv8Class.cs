namespace Tribler.API
{
    public partial class Settings
    {
        public partial class Configuration
        {
            public partial class Ipv8Class
            {
                public InterfaceClass[] Interfaces { get; init; }
                public KeyClass[] Keys { get; init; }
                public LoggerClass Logger { get; init; }
                public float Walker_interval { get; init; }
                public string Working_directory { get; init; }
                public OverlayClass[] Overlays { get; init; }
            }
        }
    }
}