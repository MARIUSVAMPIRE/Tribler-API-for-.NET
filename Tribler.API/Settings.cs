using Newtonsoft.Json;

namespace Tribler.API
{
    public partial class Settings
    {
        private static readonly string ConfigJSON = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\Roaming\.Tribler\8.0\configuration.json");
        private readonly Configuration Config;

        public bool Loaded { get; private set; }
        public ApiClass Api { get; init; }

        public Settings()
        {
            if (File.Exists(ConfigJSON))
            {
                Config = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(ConfigJSON));
                if (Config != null)
                {
                    Api = new()
                    {
                        Http = new()
                        {
                            Enabled = String.Equals(Config.Api.Http_enabled, "True"),
                            Host = Config.Api.Http_host,
                            Port = new()
                            {
                                Setting = Convert.ToInt32(Config.Api.Http_port),
                                Running = Convert.ToInt32(Config.Api.Http_port_running)
                            }
                        },
                        Key = Config.Api.Key
                    };
                    Loaded = true;
                }
            }
        }
    }
}
