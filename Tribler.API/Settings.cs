using Newtonsoft.Json;

namespace Tribler.API
{
    public partial class Settings
    {
        private static readonly string ConfigJSON = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\Roaming\.Tribler\8.0\configuration.json");
        private readonly Configuration Config;

        public ApiClass Api { get; init; }
        public bool Statistics { get; init; }
        public ContentDiscoveryCommunityClass ContentDiscoveryCommunity { get; init; }
        public DatabaseClass Database { get; init; }
        public DhtDiscoveryClass DhtDiscovery { get; init; }
        public KnowledgeCommunityClass KnowledgeCommunity { get; init; }
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
                    Statistics = Config.Statistics;
                    ContentDiscoveryCommunity = new() { Enabled = Config.Content_discovery_community.Enabled };
                    Database = new() { Enabled = Config.Database.Enabled };
                    DhtDiscovery = new() { Enabled = Config.Dht_discovery.Enabled };
                    KnowledgeCommunity = new() { Enabled = Config.Knowledge_community.Enabled };
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
