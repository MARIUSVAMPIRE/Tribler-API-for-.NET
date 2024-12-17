namespace Tribler.API
{
    public partial class Settings
    {
        public partial class Ipv8Class
        {
            internal List<InterfaceBase> Interfaces { get; init; }
            internal List<KeyBase> Keys { get; init; }
            internal LoggerClass Logger { get; init; }
            internal string WorkingDirectory { get; init; }
            internal float WalkerInterval { get; init; }
            internal List<OverlayBase> Overlays { get; init; }
        }
    }
}
