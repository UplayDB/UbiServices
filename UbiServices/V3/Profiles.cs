using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace UbiServices.Public
{
    public partial class V3
    {
        public static readonly string URL_Profiles = Urls.GetUrl("v3/profiles/");

        #region Validate
        public static JObject? ValidateName(string token, string sessionId, string NewName)
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
        public static JObject? ValidateGender(string token, string sessionId, string Gender)
        {
            var client = new RestClient($"{URL_Profiles}me/validateUpdate");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Authorization", "Ubi_v1 t=" + token);
            request.AddHeader("Ubi-SessionId", sessionId);

            request.AddBody(JsonConvert.SerializeObject(new
            {
                gender = Gender
            }));

            return Rest.Post(client, request);
        }
        public static JObject? ValidateFirstName(string token, string sessionId, string FirstName)
        {
            var client = new RestClient($"{URL_Profiles}me/validateUpdate");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Authorization", "Ubi_v1 t=" + token);
            request.AddHeader("Ubi-SessionId", sessionId);

            request.AddBody(JsonConvert.SerializeObject(new
            {
                firstName = FirstName
            }));

            return Rest.Post(client, request);
        }
        public static JObject? ValidateLastName(string token, string sessionId, string LastName)
        {
            var client = new RestClient($"{URL_Profiles}me/validateUpdate");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Authorization", "Ubi_v1 t=" + token);
            request.AddHeader("Ubi-SessionId", sessionId);

            request.AddBody(JsonConvert.SerializeObject(new
            {
                lastName = LastName
            }));

            return Rest.Post(client, request);
        }
        #endregion
        #region Update
        public static JObject? UpdateName(string token, string sessionId, string UserId, string NewName)
        {
            var client = new RestClient($"{URL_Profiles}{UserId}");
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

        public static JObject? UpdateGender(string token, string sessionId, string UserId, string Gender)
        {
            var client = new RestClient($"{URL_Profiles}{UserId}");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Authorization", "Ubi_v1 t=" + token);
            request.AddHeader("Ubi-SessionId", sessionId);

            request.AddBody(JsonConvert.SerializeObject(new
            {
                gender = Gender
            }));

            return Rest.Post(client, request);
        }

        public static JObject? UpdateFirstName(string token, string sessionId, string UserId, string FirstName)
        {
            var client = new RestClient($"{URL_Profiles}{UserId}");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Authorization", "Ubi_v1 t=" + token);
            request.AddHeader("Ubi-SessionId", sessionId);

            request.AddBody(JsonConvert.SerializeObject(new
            {
                firstName = FirstName
            }));

            return Rest.Post(client, request);
        }

        public static JObject? UpdateLastName(string token, string sessionId, string UserId, string LastName)
        {
            var client = new RestClient($"{URL_Profiles}{UserId}");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Authorization", "Ubi_v1 t=" + token);
            request.AddHeader("Ubi-SessionId", sessionId);

            request.AddBody(JsonConvert.SerializeObject(new
            {
                lastName = LastName
            }));

            return Rest.Post(client, request);
        }
        #endregion
        public static JObject? GetExternalProfile(string token, string sessionId)
        {
            var client = new RestClient($"{URL_Profiles}/me/external");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Authorization", "Ubi_v1 t=" + token);
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get(client, request);
        }

        public static JObject? GetActionLog(string token, string sessionId)
        {
            var client = new RestClient($"{URL_Profiles}/me/actionLog?offset=0&limit=10");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Authorization", "Ubi_v1 t=" + token);
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get(client, request);
        }

        public static JObject? GetFriends(string token, string sessionId, string ProfileId)
        {
            var client = new RestClient($"{URL_Profiles}/{ProfileId}/friends?locale=en-GB");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Authorization", "Ubi_v1 t=" + token);
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get(client, request);
        }
    }
}
