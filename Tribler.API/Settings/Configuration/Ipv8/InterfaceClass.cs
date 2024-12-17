namespace Tribler.API
{
    public partial class Settings
    {
        public partial class Configuration
        {
            public partial class Ipv8Class
            {
                public class InterfaceClass
                {
                    public string Interface { get; init; }
                    public string Ip { get; init; }
                    public int Port { get; init; }
                    public int Worker_threads { get; init; }
                }
            }
        }
    }
}