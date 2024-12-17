namespace Tribler.API
{
    public partial class Settings
    {
        public partial class LibtorrentClass
        {
            public partial class DownloadDefaultsClass
            {
                public class SeedingClass
                {
                    internal string Mode { get; init; }
                    internal float Ratio { get; init; }
                    internal float Time { get; init; }
                }
            }
        }
    }
}