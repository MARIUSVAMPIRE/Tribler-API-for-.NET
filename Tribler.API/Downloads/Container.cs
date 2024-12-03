using Newtonsoft.Json;

namespace Tribler.API
{
    public partial class Downloads
    {
        public partial class Container
        {
            public CheckpointsBase Checkpoints { get; init; }
            [JsonProperty("downloads")]
            public List<Information> LIST { get; init; }
        }
    }
}