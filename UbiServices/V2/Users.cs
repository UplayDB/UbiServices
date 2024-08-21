using Newtonsoft.Json.Linq;
using RestSharp;
using UbiServices.Records;

namespace UbiServices.Public
{
    public partial class V2
    {
        public static readonly string URL_UsersMe = Urls.GetUrl("v2/users/me");
        public static readonly string URL_User = Urls.GetUrl("v2/users");
        /// <summary>
        /// Get User stuff from Ubi
        /// </summary>
        /// <param name="token">Ubi Token</param>
        /// <param name="sessionId">Session Id</param>
        /// <returns>v2UserMe or Null</returns>
        public static v2UserMe? GetUsersMe(string token, string sessionId)
        {
            var client = new RestClient(URL_UsersMe);
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", V3.AppID);
            request.AddHeader("Authorization", $"Ubi_v1 t={token}");
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get<v2UserMe>(client, request);
        }


        public static JObject? GetCommunicationPreferences(string token, string sessionId)
        {
            var client = new RestClient($"{URL_UsersMe}/communicationPreferences");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", V3.AppID);
            request.AddHeader("Authorization", $"Ubi_v1 t={token}");
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get(client, request);
        }

        public static JObject? ConnectSteam(string steamtoken, string uplaytoken, string sessionId, string userId)
        {
            var client = new RestClient($"{URL_UsersMe}/{userId}/profiles");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", V3.AppID);
            request.AddHeader("Authorization", $"steam t={steamtoken}");
            request.AddHeader("Ubi-SessionId", sessionId);
            request.AddHeader("Ubi-RequestedPlatformType", "uplay");
            request.AddHeader("User-Agent", "Massgate");

            request.AddStringBody("{\"otherTicket\":\"" + uplaytoken  +"\"}", DataFormat.Json);
            return Rest.Post(client, request);
        }
    }
}
