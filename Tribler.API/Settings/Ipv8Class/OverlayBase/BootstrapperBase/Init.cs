namespace Tribler.API
{
    public partial class Settings
    {
        public partial class Ipv8Class
        {
            public partial class OverlayBase
            {
                public partial class BootstrapperBase
                {
                    public partial class InitClass
                    {
                        internal List<IpAddressClass> IpAddresses { get; init; }
                        internal List<DnsAddressClass> DnsAddresses { get; init; }
                        internal int BootstrapTimeout { get; init; }
                    }
                }
            }
        }
    }
}