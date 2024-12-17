using Newtonsoft.Json;

namespace Tribler.API
{
    public partial class Settings
    {
        private static readonly string ConfigJSON = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\Roaming\.Tribler\8.0\configuration.json");
        private readonly Configuration Config;

        public ApiClass Api { get; init; }
        public Ipv8Class Ipv8 { get; init; }
        public bool Statistics { get; init; }
        public ContentDiscoveryCommunityClass ContentDiscoveryCommunity { get; init; }
        public DatabaseClass Database { get; init; }
        public DhtDiscoveryClass DhtDiscovery { get; init; }
        public KnowledgeCommunityClass KnowledgeCommunity { get; init; }
        public LibtorrentClass Libtorrent { get; init; }
        public RendezvousClass Rendezvous { get; init; }
        public TorrentCheckerClass TorrentChecker { get; init; }
        public TunnelCommunityClass TunnelCommunity { get; init; }
        public UserActivityClass UserActivity { get; init; }
        public VersioningClass? Versioning { get; init; }
        public string StateDirectory { get; init; }
        public bool MemoryDB { get; init; }
        public UiClass Ui { get; init; }
        public bool Loaded { get; private set; }

        public Settings()
        {
            if (File.Exists(ConfigJSON))
            {
                Config = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(ConfigJSON));
                if (Config != null)
                {
                    Api = new()
                    {
                        Http = new()
                        {
                            Enabled = String.Equals(Config.Api.Http_enabled, "True"),
                            Host = Config.Api.Http_host,
                            Port = new()
                            {
                                Setting = Convert.ToInt32(Config.Api.Http_port),
                                Running = Convert.ToInt32(Config.Api.Http_port_running)
                            }
                        },
                        Key = Config.Api.Key
                    };
                    Ipv8 = new()
                    {
                        Interfaces = Config.Ipv8.Interfaces.Select(item => new Ipv8Class.InterfaceBase() { Interface = item.Interface, Ip = item.Ip, Port = item.Port, WorkerThread = item.Worker_threads }).ToList(),
                        Keys = Config.Ipv8.Keys.Select(item => new Ipv8Class.KeyBase() { Alias = item.Alias, Generation = item.Generation, File = item.File }).ToList(),
                        Logger = new() { Level = Config.Ipv8.Logger.Level },
                        WorkingDirectory = Config.Ipv8.Working_directory,
                        WalkerInterval = Config.Ipv8.Walker_interval,
                        Overlays = Config.Ipv8.Overlays.Select(overlay => new Ipv8Class.OverlayBase()
                        {
                            Class = overlay.Class,
                            Key = overlay.Key,
                            Workers = overlay.Walkers.Select(worker => new Ipv8Class.OverlayBase.WorkerBase()
                            {
                                Strategy = worker.Strategy,
                                Peers = worker.Peers,
                                Init = new Ipv8Class.OverlayBase.WorkerBase.InitClass() { SampleSize = worker.Init.Sample_size, PingInterval = worker.Init.Ping_interval, InactiveTime = worker.Init.Inactive_time, DropTime = worker.Init.Drop_time }
                            }).ToList(),
                            Bootstrappers = overlay.Bootstrappers.Select(bootstrapper => new Ipv8Class.OverlayBase.BootstrapperBase()
                            {
                                Class = bootstrapper.Class,
                                Init = new Ipv8Class.OverlayBase.BootstrapperBase.InitClass()
                                {
                                    IpAddresses = bootstrapper.Init.Ip_addresses.Select(address => new Ipv8Class.OverlayBase.BootstrapperBase.InitClass.IpAddressClass() { Ip = address.Ip, Port = address.Port }).ToList(),
                                    DnsAddresses = bootstrapper.Init.Dns_addresses.Select(address => new Ipv8Class.OverlayBase.BootstrapperBase.InitClass.DnsAddressClass() { Ip = address.Ip, Port = address.Port }).ToList(),
                                    BootstrapTimeout = bootstrapper.Init.Bootstrap_timeout
                                },
                            }).ToList(),
                            Initialize = new Ipv8Class.OverlayBase.InitializeClass() { },
                            OnStart = overlay.On_start.Select(onstart => new Ipv8Class.OverlayBase.OnStartBase() { }).ToList()
                        }).ToList()
                    };
                    Statistics = Config.Statistics;
                    ContentDiscoveryCommunity = new() { Enabled = Config.Content_discovery_community.Enabled };
                    Database = new() { Enabled = Config.Database.Enabled };
                    DhtDiscovery = new() { Enabled = Config.Dht_discovery.Enabled };
                    KnowledgeCommunity = new() { Enabled = Config.Knowledge_community.Enabled };
                    Libtorrent = new()
                    {
                        SocksListenPorts = Config.Libtorrent.Socks_listen_ports,
                        Port = Config.Libtorrent.Port,
                        Proxy = new() { Type = Config.Libtorrent.Proxy_type, Server = Config.Libtorrent.Proxy_server, Authority = Config.Libtorrent.Proxy_auth },
                        MaxConnectionsDownload = Config.Libtorrent.Max_connections_download,
                        MaxDownloadRate = Config.Libtorrent.Max_download_rate,
                        MaxUploadRate = Config.Libtorrent.Max_upload_rate,
                        Utp = Config.Libtorrent.Utp,
                        Dht = Config.Libtorrent.Dht,
                        DhtReadinessTimeout = Config.Libtorrent.Dht_readiness_timeout,
                        Upnp = Config.Libtorrent.Upnp,
                        Natpmp = Config.Libtorrent.Natpmp,
                        Lsd = Config.Libtorrent.Lsd,
                        DownloadDefaults = new()
                        {
                            AnonymityEnabled = Config.Libtorrent.Download_defaults.Anonymity_enabled,
                            HopsNumber = Config.Libtorrent.Download_defaults.Number_hops,
                            SafeSeedingEnabled = Config.Libtorrent.Download_defaults.Safeseeding_enabled,
                            SaveAs = Config.Libtorrent.Download_defaults.Saveas,
                            Seeding = new() { Mode = Config.Libtorrent.Download_defaults.Seeding_mode, Ratio = Config.Libtorrent.Download_defaults.Seeding_ratio, Time = Config.Libtorrent.Download_defaults.Seeding_time },
                            ChannelDownload = Config.Libtorrent.Download_defaults.Channel_download,
                            AddDownloadToChannel = Config.Libtorrent.Download_defaults.Add_download_to_channel
                        }
                    };
                    Rendezvous = new() { Enabled = Config.Rendezvous.Enabled };
                    TorrentChecker = new() { Enabled = Config.Torrent_checker.Enabled };
                    TunnelCommunity = new() { Enabled = Config.Tunnel_community.Enabled, Circuits = new() { Max = Config.Tunnel_community.Max_circuits, Min = Config.Tunnel_community.Min_circuits } };
                    UserActivity = new() { Enabled = Config.User_activity.Enabled, MaxQueryHistory = Config.User_activity.Max_query_history, HealthCheckInterval = Config.User_activity.Health_check_interval };
                    Versioning = new() { Enabled = Config.Versioning.Enabled };
                    StateDirectory = Config.State_dir;
                    MemoryDB = Config.Memory_db;
                    Ui = new()
                    {
                        DevelopmentMode = Config.Ui.Dev_mode,
                        AskDownloadSettings = Config.Ui.Ask_download_settings,
                        Language = Config.Ui.Lang
                    };
                    Loaded = true;
                }
            }
        }
    }
}
