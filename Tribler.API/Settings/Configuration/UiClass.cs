namespace Tribler.API
{
    public partial class Settings
    {
        public partial class Configuration
        {
            public class UiClass
            {
                public bool Dev_mode { get; init; }
                public bool Ask_download_settings { get; init; }
                public string Lang { get; init; }
            }
        }
    }
}