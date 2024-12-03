using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tribler.API
{
    public partial class Downloads
    {
        public partial class Container
        {
            [JsonConverter(typeof(CheckpointsConverter))]
            public class CheckpointsBase
            {
                public LoadedBase Loaded { get; init; }
                public class LoadedBase
                {
                    public int Count { get; init; }
                    public bool All { get; init; }
                }
                public int Total { get; init; }
            }
            class CheckpointsConverter : JsonConverter
            {
                public override bool CanConvert(Type objectType)
                {
                    return objectType == typeof(CheckpointsBase);
                }

                public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
                {
                    JObject parsedObject = JObject.Load(reader);
                    return new CheckpointsBase()
                    {
                        Total = Convert.ToInt32(parsedObject.SelectToken("total")),
                        Loaded = new CheckpointsBase.LoadedBase()
                        {
                            All = Convert.ToBoolean(parsedObject.SelectToken("all_loaded")),
                            Count = Convert.ToInt32(parsedObject.SelectToken("loaded"))
                        }
                    };
                }

                public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}