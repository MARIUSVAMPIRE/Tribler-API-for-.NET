using System.Linq.Expressions;

namespace Tribler.API
{
    public partial class Settings
    {
        public partial class Configuration
        {
            public partial class LibtorrentClass
            {
                public class DownloadDefaultsClass
                {
                    public bool Anonymity_enabled { get; init; }
                    public int Number_hops { get; init; }
                    public bool Safeseeding_enabled { get; init; }
                    public string Saveas { get; init; }
                    public string Seeding_mode { get; init; }
                    public float Seeding_ratio { get; init; }
                    public float Seeding_time { get; init; }
                    public bool Channel_download { get; init; }
                    public bool Add_download_to_channel { get; init; }
                }
            }
        }
    }
}