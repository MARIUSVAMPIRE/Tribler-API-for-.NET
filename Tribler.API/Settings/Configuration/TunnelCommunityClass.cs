namespace Tribler.API
{
    public partial class Settings
    {
        public partial class Configuration
        {
            public class TunnelCommunityClass
            {
                public bool Enabled { get; init; }
                public int Min_circuits { get; init; }
                public int Max_circuits { get; init; }
            }
        }
    }
}