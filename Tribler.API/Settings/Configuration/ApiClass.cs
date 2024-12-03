namespace Tribler.API
{
    public partial class Settings
    {
        public partial class Configuration
        {
            public class ApiClass
            {
                public string? Http_enabled { get; init; }
                public string? Http_port { get; init; }
                public string? Http_host { get; init; }
                public string? Https_enabled { get; init; }
                public string? Https_host { get; init; }
                public string? Https_port { get; init; }
                public string? Https_certfile { get; init; }
                public string? Http_port_running { get; init; }
                public string? Https_port_running { get; init; }
                public string? Key { get; init; }
            }
        }
    }
}
