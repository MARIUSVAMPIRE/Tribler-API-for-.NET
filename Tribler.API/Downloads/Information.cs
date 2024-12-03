using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tribler.API
{
    public partial class Downloads
    {
        public partial class Container
        {
            [JsonConverter(typeof(InformationConverter))]
            public class Information
            {
                public AllTimeBase AllTime { get; init; }
                public class AllTimeBase
                {
                    public long Download { get; init; }
                    public long Upload { get; init; }
                    public float Ratio { get; init; }
                }
                public AnonymityBase Anonymity { get; init; }
                public class AnonymityBase
                {
                    public bool Download { get; init; }
                }
                public string Destination { get; init; }
                public string Error { get; init; }
                public TimeSpan Eta { get; init; }
                public int Hops { get; init; }
                public string InfoHash { get; init; }
                public SpeedBase Speed { get; init; }
                public class SpeedBase
                {
                    public long Download { get; init; }
                    public long Upload { get; init; }
                    public MaxBase Max { get; init; }
                    public class MaxBase
                    {
                        public long Download { get; init; }
                        public long Upload { get; init; }

                    }
                }
                public string Name { get; init; }
                public PeersBase Peers { get; init; }
                public class PeersBase
                {
                    public int Connected { get; init; }
                    public int Count { get; init; }
                    public List<PeerInformation> LIST { get; init; }
                }
                [JsonConverter(typeof(PeerInformationConverter))]
                public class PeerInformation
                {
                    public string Id { get; init; }
                    public string ExtendedVersion { get; init; }
                    public string Ip { get; init; }
                    public int Port { get; init; }
                    public float Completed { get; init; }
                    public bool Optimistic { get; init; }
                    public bool PexReceived { get; init; }
                    public string Direction { get; init; }
                    public UploadBase Upload { get; init; }
                    public class UploadBase
                    {
                        public bool Choked { get; init; }
                        public float Rate { get; init; }
                        public float Total { get; init; }   // KB
                        public bool Only { get; init; }
                        public bool Interested { get; init; }
                        public bool Flushed { get; init; }
                        public bool HasQueries { get; init; }
                    }
                    public ConnectionBase Connection { get; init; }
                    public class ConnectionBase
                    {
                        public int Type { get; init; }
                    }
                    public DownloadBase Download { get; init; }
                    public class DownloadBase
                    {
                        public bool Choked { get; init; }
                        public float Rate { get; init; }
                        public float Total { get; init; }   // KB
                        public bool Interested { get; init; }
                        public bool Snubbed { get; init; }
                        public float Speed { get; init; }

                    }
                    public bool Seed { get; init; }
                }
                public SeedsBase Seeds { get; init; }
                public class SeedsBase
                {
                    public int Connected { get; init; }
                    public int Count { get; init; }
                }
                public float Progress { get; init; }
                public bool SafeSeeding { get; init; }
                public long Size { get; init; }
                public StatusBase Status { get; init; }
                public class StatusBase
                {
                    public string Label { get; init; }
                    public int Code { get; init; }
                }
                public TimeBase Time { get; init; }
                public class TimeBase
                {
                    public DateTime Added { get; init; }
                }
                public PiecesBase Pieces { get; init; }
                public class PiecesBase
                {
                    public int Total { get; init; }
                    public string Detail { get; init; }
                }
                public List<Tracker> Trackers { get; init; }
                public class Tracker
                {
                    public int Peers { get; init; }
                    public string Url { get; init; }
                    public string Status { get; init; }
                }
                public double Availability { get; init; } = -1;
                class InformationConverter : JsonConverter
                {
                    public override bool CanConvert(Type objectType)
                    {
                        return objectType == typeof(Information);
                    }

                    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
                    {
                        JObject parsedObject = JObject.Load(reader);
                        return new Information()
                        {
                            AllTime = new() { Download = Convert.ToInt64(parsedObject.SelectToken("all_time_download")), Upload = Convert.ToInt64(parsedObject.SelectToken("all_time_upload")), Ratio = float.Parse(Convert.ToString(parsedObject.SelectToken("all_time_ratio") ?? "-1")!) },
                            Anonymity = new() { Download = Convert.ToBoolean(parsedObject.SelectToken("anon_download")) },
                            Destination = Convert.ToString(parsedObject.SelectToken("destination")),
                            Error = Convert.ToString(parsedObject.SelectToken("error")),
                            Eta = new TimeSpan((long)parsedObject.SelectToken("eta")!),
                            Hops = Convert.ToInt32(parsedObject.SelectToken("hops")),
                            InfoHash = Convert.ToString(parsedObject.SelectToken("infohash")),
                            Speed = new()
                            {
                                Download = Convert.ToInt64(parsedObject.SelectToken("speed_down")),
                                Upload = Convert.ToInt64(parsedObject.SelectToken("speed_up")),
                                Max = new() { Download = Convert.ToInt64(parsedObject.SelectToken("max_download_speed")), Upload = Convert.ToInt64(parsedObject.SelectToken("max_upload_speed")) }
                            },
                            Name = Convert.ToString(parsedObject.SelectToken("name")),
                            Peers = new() { Connected = Convert.ToInt32(parsedObject.SelectToken("num_connected_peers")), Count = Convert.ToInt32(parsedObject.SelectToken("num_peers")), LIST = JsonConvert.DeserializeObject<List<PeerInformation>>(Convert.ToString(parsedObject.SelectToken("peers"))!) },
                            Seeds = new() { Connected = Convert.ToInt32(parsedObject.SelectToken("num_connected_seeds")), Count = Convert.ToInt32(parsedObject.SelectToken("num_seeds")) },
                            Progress = float.Parse(Convert.ToString(parsedObject.SelectToken("progress") ?? "-1")!),
                            SafeSeeding = Convert.ToBoolean(parsedObject.SelectToken("safe_seeding")),
                            Size = Convert.ToInt64(parsedObject.SelectToken("size")),
                            Status = new() { Label = Convert.ToString(parsedObject.SelectToken("status")), Code = Convert.ToInt32(parsedObject.SelectToken("status_code")) },
                            Time = new() { Added = (new DateTime(1970, 1, 1)).AddSeconds(Convert.ToInt64(parsedObject.SelectToken("time_added"))).ToLocalTime() },
                            Pieces = new() { Total = Convert.ToInt32(parsedObject.SelectToken("total_pieces")), Detail = Convert.ToString(parsedObject.SelectToken("pieces")) },
                            Availability = float.Parse(Convert.ToString(parsedObject.SelectToken("availability") ?? -1)!),
                            Trackers = JsonConvert.DeserializeObject<List<Tracker>>(Convert.ToString(parsedObject.SelectToken("trackers"))!)
                        };
                    }
                    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
                    {
                        throw new NotImplementedException();
                    }
                }
                class PeerInformationConverter : JsonConverter
                {
                    public override bool CanConvert(Type objectType)
                    {
                        return objectType == typeof(PeerInformation);
                    }

                    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
                    {
                        JObject parsedObject = JObject.Load(reader);
                        return new PeerInformation()
                        {
                            Id = Convert.ToString(parsedObject.SelectToken("id")),
                            ExtendedVersion = Convert.ToString(parsedObject.SelectToken("extended_version")),
                            Ip = Convert.ToString(parsedObject.SelectToken("ip")),
                            Port = Convert.ToInt32(parsedObject.SelectToken("port")),
                            Completed = float.Parse(Convert.ToString(parsedObject.SelectToken("completed") ?? "-1")!),
                            Optimistic = Convert.ToBoolean(parsedObject.SelectToken("optimistic")),
                            PexReceived = Convert.ToBoolean(parsedObject.SelectToken("pex_received")),
                            Direction = Convert.ToString(parsedObject.SelectToken("direction")),
                            Upload = new PeerInformation.UploadBase()
                            {
                                Choked = Convert.ToBoolean(parsedObject.SelectToken("uchoked")),
                                Rate = float.Parse(Convert.ToString(parsedObject.SelectToken("uprate") ?? "-1")!),
                                Total = float.Parse(Convert.ToString(parsedObject.SelectToken("utotal") ?? "-1")!),
                                Only = Convert.ToBoolean(parsedObject.SelectToken("upload_only")),
                                Interested = Convert.ToBoolean(parsedObject.SelectToken("uinterested")),
                                Flushed = Convert.ToBoolean(parsedObject.SelectToken("uflushed")),
                                HasQueries = Convert.ToBoolean(parsedObject.SelectToken("uhasqueries"))
                            },
                            Connection = new PeerInformation.ConnectionBase() { Type = Convert.ToInt32(parsedObject.SelectToken("connection_type")) },
                            Download = new PeerInformation.DownloadBase()
                            {
                                Choked = Convert.ToBoolean(parsedObject.SelectToken("dchoked")),
                                Rate = float.Parse(Convert.ToString(parsedObject.SelectToken("downrate") ?? "-1")!),
                                Total = float.Parse(Convert.ToString(parsedObject.SelectToken("dtotal") ?? "-1")!),
                                Interested = Convert.ToBoolean(parsedObject.SelectToken("dinterested")),
                                Snubbed = Convert.ToBoolean(parsedObject.SelectToken("snubbed")),
                                Speed = float.Parse(Convert.ToString(parsedObject.SelectToken("speed") ?? "-1")!)
                            },
                            Seed = Convert.ToBoolean(parsedObject.SelectToken("seed"))
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
}