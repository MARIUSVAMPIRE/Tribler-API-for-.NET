namespace Tribler.API
{
    public partial class Settings
    {
        public partial class LibtorrentClass
        {
            public class ProxyClass
            {
                internal int Type { get; init; }
                internal string Server { get; init; }
                internal string Authority { get; init; }
            }
        }
    }
}