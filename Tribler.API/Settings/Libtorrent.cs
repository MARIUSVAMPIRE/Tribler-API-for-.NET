namespace Tribler.API
{
    public partial class Settings
    {
        public partial class LibtorrentClass
        {
            internal List<int> SocksListenPorts { get; init; }
            internal int Port { get; init; }
            internal ProxyClass Proxy { get; init; }
            internal int MaxConnectionsDownload { get; init; }
            internal int MaxDownloadRate { get; init; }
            internal int MaxUploadRate { get; init; }
            internal bool Utp { get; init; }
            internal bool Dht { get; init; }
            internal int DhtReadinessTimeout { get; init; }
            internal bool Upnp { get; init; }
            internal bool Natpmp { get; init; }
            internal bool Lsd { get; init; }
            internal DownloadDefaultsClass DownloadDefaults { get; init; }
        }
    }
}
