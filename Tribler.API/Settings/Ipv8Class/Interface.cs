namespace Tribler.API
{
    public partial class Settings
    {
        public partial class Ipv8Class
        {
            public class InterfaceBase
            {
                internal string Interface { get; init; }
                internal string Ip { get; init; }
                internal int Port { get; init; }
                internal int WorkerThread { get; init; }
            }
        }
    }
}