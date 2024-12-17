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
                    public partial class WalkerClass
                    {
                        public class InitClass
                        {
                            public int Sample_size { get; init; }
                            public int Ping_interval { get; init; }
                            public float Inactive_time { get; init; }
                            public float Drop_time { get; init; }
                            public int Timeout { get; init; }
                        }
                    }
                }
            }
        }
    }
}