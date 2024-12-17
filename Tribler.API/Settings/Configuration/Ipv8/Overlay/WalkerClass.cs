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
                        public string Strategy { get; init; }
                        public int Peers { get; init; }
                        public InitClass Init { get; init; }
                    }
                }
            }
        }
    }
}