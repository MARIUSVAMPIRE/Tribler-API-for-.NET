namespace Tribler.API
{
    public partial class Settings
    {
        public partial class LibtorrentClass
        {
            public partial class DownloadDefaultsClass
            {
                internal bool AnonymityEnabled { get; init; }
                internal int HopsNumber { get; init; }
                internal bool SafeSeedingEnabled { get; init; }
                internal string SaveAs { get; init; }
                internal SeedingClass Seeding { get; init; }
                internal bool ChannelDownload { get; init; }
                internal bool AddDownloadToChannel { get; init; }
            }
        }
    }
}