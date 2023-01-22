using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace UbiServices.Public
{
    public partial class V3
    {
        public static readonly string URL_Profiles = Urls.GetUrl("v3/profiles/");

        public static JObject? UpdateName(string token, string sessionId, string NewName)
        {
            var client = new RestClient($"{URL_Profiles}me/validateUpdate");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Authorization", "Ubi_v1 t=" + token);
            request.AddHeader("Ubi-SessionId", sessionId);

            request.AddBody(JsonConvert.SerializeObject(new
            {
                nameOnPlatform = NewName
            }));

            return Rest.Post(client, request);
        }

        public static JObject? GetExternalProfile(string token, string sessionId)
        {
            var client = new RestClient($"{URL_Profiles}/me/external");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Authorization", "Ubi_v1 t=" + token);
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get(client, request);
        }
    }
}
