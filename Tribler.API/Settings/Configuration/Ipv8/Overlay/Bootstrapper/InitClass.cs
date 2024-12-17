using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tribler.API
{
    public partial class Settings
    {
        public partial class Configuration
        {
            public partial class Ipv8Class
            {
                public partial class OverlayClass
                {
                    public partial class BootstrapperClass
                    {
                        public partial class InitClass
                        {
                            public List<IpAddressClass> Ip_addresses { get; set; }
                            public List<IpAddressClass> Dns_addresses { get; set; }
                            public int Bootstrap_timeout { get; init; }
                        }
                    }
                }
            }
        }
    }
}