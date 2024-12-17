using System.Linq.Expressions;

namespace Tribler.API
{
    public partial class Settings
    {
        public partial class Configuration
        {
            public ApiClass Api { get; init; }
            public Ipv8Class Ipv8 { get; init; }
            public bool Statistics { get; init; }
            public ContentDiscoveryCommunityClass Content_discovery_community { get; init; }
            public DatabaseClass Database { get; init; }
            public DhtDiscoveryClass Dht_discovery { get; init; }
            public KnowledgeCommunityClass Knowledge_community { get; init; }
            public LibtorrentClass Libtorrent { get; init; }
            public RendezvousClass Rendezvous { get; init; }
            public TorrentCheckerClass Torrent_checker { get; init; }
            public TunnelCommunityClass Tunnel_community { get; init; }
            public UserActivityClass User_activity { get; init; }
            public VersioningClass Versioning { get; init; }
            public string State_dir { get; init; }
            public bool Memory_db { get; init; }
            public UiClass Ui { get; init; }
        }
    }
}
