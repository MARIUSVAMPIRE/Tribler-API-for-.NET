using Newtonsoft.Json;

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
                            [JsonConverter(typeof(IpAddressConvertor))]
                            public partial class IpAddressClass
                            {
                                public string Ip { get; set; }
                                public int Port { get; set; }
                            }

                            class IpAddressConvertor : JsonConverter
                            {
                                public override bool CanConvert(Type objectType)
                                {
                                    return objectType == typeof(List<string>);
                                }

                                public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
                                {
                                    IpAddressClass ipAddress = new();
                                    int index = 0;
                                    while (reader.Read())
                                    {
                                        if (reader.TokenType == JsonToken.EndObject)
                                        {
                                            continue;
                                        }
                                        else if (reader.TokenType == JsonToken.EndArray)
                                        {
                                            break;
                                        }
                                        var value = reader.Value;
                                        if (value != null)
                                        {
                                            switch (index)
                                            {
                                                case 0: ipAddress.Ip = Convert.ToString(value); break;
                                                case 1:
                                                    {
                                                        ipAddress.Port = Convert.ToInt32(value);
                                                        break;
                                                    }
                                                default: break;
                                            }
                                            index++;
                                        }
                                    }
                                    return ipAddress;
                                }

                                public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
                                {
                                    throw new NotImplementedException();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}