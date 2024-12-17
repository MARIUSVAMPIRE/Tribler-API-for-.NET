namespace Tribler.API
{
    public partial class Settings
    {
        public partial class Configuration
        {
            public partial class LibtorrentClass
            {
                public List<int> Socks_listen_ports { get; set; }
                public int Port { get; init; }
                public int Proxy_type { get; init; }
                public string Proxy_server { get; init; }
                public string Proxy_auth { get; init; }
                public int Max_connections_download { get; init; }
                public int Max_download_rate { get; init; }
                public int Max_upload_rate { get; init; }
                public bool Utp { get; init; }
                public bool Dht { get; init; }
                public int Dht_readiness_timeout { get; init; }
                public bool Upnp { get; init; }
                public bool Natpmp { get; init; }
                public bool Lsd { get; init; }
                public DownloadDefaultsClass Download_defaults { get; init; }
            }
        }
    }
}