namespace Tribler.API
{
    public partial class Settings
    {
        public partial class Ipv8Class
        {
            public partial class OverlayBase
            {
                public partial class WorkerBase
                {
                    internal string Strategy { get; init; }
                    internal int Peers { get; init; }
                    internal InitClass Init {  get; set; }
                }
            }
        }
    }
}