namespace Tribler.API
{
    public partial class Settings
    {
        public partial class ApiClass
        {
            internal class HttpBase
            {
                public bool Enabled { get; init; }
                public Port Port { get; init; }
                public string Host { get; init; }
            }

            internal class Port
            {
                public int Setting { get; init; }
                public int Running { get; init; }
            }
        }
    }
}