using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using Tribler.API.Extension;

namespace Tribler.API
{
    public partial class Downloads(Settings settings)
    {
        private Settings Settings { get; init; } = settings;
        public List<Container.Information> LIST { get; internal set; }

        public async Task<bool> Get(string infohash = "", bool peers = false, bool pieces = false, bool availability = false)
        {
            HttpClient client = new() { Timeout = new TimeSpan(0, 0, 30) };
            HttpResponseMessage response = await client.GetAsync("http://" + Settings.Api.Http.Host + ":" + Settings.Api.Http.Port.Running + String.Format("/api/downloads?infohash={0}&get_peers={1}&get_pieces={2}&get_availability={3}&key={4}", infohash, peers ? "1" : "", pieces ? "1" : "", availability ? "1" : "", Settings.Api.Key)).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync();
            Container jsonResult = JsonConvert.DeserializeObject<Container>(result)!;
            this.LIST = jsonResult!.LIST;
            return jsonResult.LIST != null;
        }

        public async Task<bool> Add(byte[] content)
        {
            HttpClient client = new() { Timeout = new TimeSpan(0, 0, 30) };
            HttpContent httpContent = new ByteArrayContent(content);
            httpContent.Headers.Add("Content-type", "applications/x-bittorrent");
            HttpResponseMessage response = await client.PutAsync("http://" + Settings.Api.Http.Host + ":" + Settings.Api.Http.Port.Running + "/api/downloads?key=" + Settings.Api.Key, httpContent).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync();
            JObject resultJSON = (JObject)JsonConvert.DeserializeObject(result)!;
            return resultJSON.SelectToken("started") != null && String.Equals(Convert.ToString(resultJSON.SelectToken("started")), "true", StringComparison.InvariantCultureIgnoreCase);
        }

        public async Task<bool> Remove(string infoHash)
        {
            HttpClient client = new() { Timeout = new TimeSpan(0, 0, 30) };
            JObject options = new()
            {
                { "remove_data", 1 }
            };

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://" + Settings.Api.Http.Host + ":" + Settings.Api.Http.Port.Running + "/api/downloads/" + infoHash + "?key=" + Settings.Api.Key),
                Content = new StringContent(JsonConvert.SerializeObject(options), Encoding.UTF8, "application/json")
            };
            var response = await client.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync();
            JObject resultJSON = (JObject)JsonConvert.DeserializeObject(result)!;
            return resultJSON.SelectToken("started") != null && String.Equals(Convert.ToString(resultJSON.SelectToken("started")), "true", StringComparison.InvariantCultureIgnoreCase);
        }

        public async Task<bool> Resume(string infoHash, bool isResume = true)
        {
            HttpClient client = new() { Timeout = new TimeSpan(0, 0, 30) };
            JObject options = new()
            {
                { "state", isResume ? "resume" : "stop" }
            };

            HttpResponseMessage response = await client.PatchAsync("http://" + Settings.Api.Http.Host + ":" + Settings.Api.Http.Port.Running + "/api/downloads/" + infoHash + "?key=" + Settings.Api.Key, new StringContent(JsonConvert.SerializeObject(options), Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync();
            JObject resultJSON = (JObject)JsonConvert.DeserializeObject(result)!;
            return resultJSON.SelectToken("infohash") != null && String.Equals(Convert.ToString(resultJSON.SelectToken("modified")), "true", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
