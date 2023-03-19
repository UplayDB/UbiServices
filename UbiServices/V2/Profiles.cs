using Newtonsoft.Json.Linq;
using RestSharp;

namespace UbiServices.Public
{
    public partial class V2
    {
        public static readonly string URL_ProfilesMe = Urls.GetUrl("v2/profiles/me");

        public static JObject? GetIP(string token, string sessionId)
        {
            var client = new RestClient($"{URL_ProfilesMe}/iplocation");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", V3.AppID);
            request.AddHeader("Authorization", $"Ubi_v1 t={token}");
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get(client, request);
        }

        public static JObject? GetFromIP(string token, string sessionId, string IP)
        {
            var client = new RestClient(Urls.GetUrl("v2/iplocation/") + IP);
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", V3.AppID);
            request.AddHeader("Authorization", $"Ubi_v1 t={token}");
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get(client, request);
        }
    }
}
