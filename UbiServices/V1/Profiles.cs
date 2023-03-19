using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace UbiServices.Public
{
    public partial class V1
    {
        public static readonly string URL_Profiles = Urls.GetUrl("v1/profiles");

        public static JObject? GetConnections(string token, string sessionId)
        {
            var client = new RestClient($"{URL_Profiles}/connections");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", V3.AppID);
            request.AddHeader("Authorization", $"Ubi_v1 t={token}");
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get(client, request);
        }

        public static JObject? BlockUser(string token, string sessionId, string ProfileId, string BlockedProfileId, string SpaceId)
        {
            var client = new RestClient($"{URL_Profiles}/{ProfileId}/blocks");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", V3.AppID);
            request.AddHeader("Authorization", $"Ubi_v1 t={token}");
            request.AddHeader("Ubi-SessionId", sessionId);

            request.AddBody(JsonConvert.SerializeObject(new
            {
                spaceId = SpaceId,
                profileId = BlockedProfileId
            }));
            return Rest.Post(client, request);
        }

        public static JObject? GetAvatars(string token, string sessionId, string ProfileId)
        {
            var client = new RestClient($"{URL_Profiles}/{ProfileId}/avatars");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", V3.AppID);
            request.AddHeader("Authorization", "Ubi_v1 t=" + token);
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get(client, request);
        }

        public static JObject? GetEntitlements(string token, string sessionId)
        {
            var client = new RestClient($"{URL_Profiles}/me/global/ubiconnect/entitlement/api/entitlements");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", V3.AppID);
            request.AddHeader("Authorization", $"Ubi_v1 t={token}");
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get(client, request);
        }

        public static JObject? GetMetaProgression(string token, string sessionId)
        {
            var client = new RestClient($"{URL_Profiles}/me/global/ubiconnect/economy/api/metaprogression");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", V3.AppID);
            request.AddHeader("Authorization", $"Ubi_v1 t={token}");
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get(client, request);
        }

        public static JObject? GetUnits(string token, string sessionId)
        {
            var client = new RestClient($"{URL_Profiles}/me/global/ubiconnect/economy/api/units");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", V3.AppID);
            request.AddHeader("Authorization", $"Ubi_v1 t={token}");
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get(client, request);
        }

        public static JObject? GetTransactions(string token, string sessionId)
        {
            var client = new RestClient($"{URL_Profiles}/me/global/ubiconnect/economy/api/units/transactions");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", V3.AppID);
            request.AddHeader("Authorization", $"Ubi_v1 t={token}");
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get(client, request);
        }

        public static JObject? GetConsents(string token, string sessionId, string UserId)
        {
            var client = new RestClient($"{URL_Profiles}/{UserId}/applications/oauth/clients/consents?offset=0&limit=50");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", V3.AppID);
            request.AddHeader("Authorization", $"Ubi_v1 t={token}");
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get(client, request);
        }
    }
}
