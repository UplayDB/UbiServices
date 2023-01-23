using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using UbiServices.Records;

namespace UbiServices.Public
{
    public partial class V3
    {
        public static readonly string URL_Users = Urls.GetUrl("v3/users/");

        /// <summary>
        /// Get User stuff from Ubi
        /// </summary>
        /// <param name="token">Ubi Token</param>
        /// <param name="sessionId">Session Id</param>
        /// <returns>UsersMe or Null</returns>
        public static UsersMe? GetUsersMe(string token, string sessionId)
        {
            var client = new RestClient($"{URL_Users}me");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Authorization", "Ubi_v1 t=" + token);
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get<UsersMe>(client, request);
        }

        /// <summary>
        /// Get User stuff from Ubi by UserId
        /// </summary>
        /// <param name="token">Ubi Token</param>
        /// <param name="sessionId">Session Id</param>
        /// <param name="UserId">User Id</param>
        /// <param name="fields">Fields Filter</param>
        /// <returns>JObject or Null</returns>
        public static JObject? GetUsersMeById(string token, string sessionId, string UserId, List<string> fields)
        {
            string URL = $"{URL_Users}{UserId}";


            if (fields == null || fields.Count == 0)
            {
                //Just normal request should do anything
            }
            else
            {
                var filedscommas = String.Join(",", fields);
                URL += "?fields=" + filedscommas;
            }

            var client = new RestClient(URL);
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Authorization", "Ubi_v1 t=" + token);
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get(client, request);
        }

        public static JObject? GetRoamingProfiles(string token, string sessionId, string spaceId)
        {
            var client = new RestClient($"{URL_Users}me/roamingProfiles?spaceIds={spaceId}");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Authorization", "Ubi_v1 t=" + token);
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get(client, request);
        }

        public static JObject? ResetPassword(string token, string sessionId, string EmailAddress)
        {
            var client = new RestClient($"{URL_Users}startResetPassword");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Authorization", "Ubi_v1 t=" + token);
            request.AddHeader("Ubi-SessionId", sessionId);
            request.AddHeader("Ubi-RequestedPlatformType", "uplay");

            request.AddBody(JsonConvert.SerializeObject(new
            {
                email = EmailAddress
            }));
            return Rest.Post(client, request);
        }

        /// <summary>
        /// Trying to create a Ubisoft Account
        /// </summary>
        /// <param name="EmailAddress"></param>
        /// <param name="Password"></param>
        /// <param name="DateOfBirth">2000-00-00</param>
        /// <param name="NameOnPlatform"></param>
        /// <param name="Country"></param>
        /// <param name="PreferredLanguage"></param>
        /// <param name="LegalOptinsKey"></param>
        /// <returns></returns>
        public static JObject? CreateAccount(string EmailAddress, string Password, string DateOfBirth, string NameOnPlatform, string Country, string PreferredLanguage, string LegalOptinsKey)
        {
            var client = new RestClient($"{URL_Users}validateCreation");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Ubi-RequestedPlatformType", "uplay");

            request.AddBody(JsonConvert.SerializeObject(new
            {
                email = EmailAddress,
                password = Password,
                dateOfBirth = DateOfBirth,
                nameOnPlatform = NameOnPlatform,
                country = Country,
                preferredLanguage = PreferredLanguage,
                legalOptinsKey = LegalOptinsKey
            }));
            return Rest.Post(client, request);
        }

        public static JObject? ActivateAccount(string EmailAddress, string ActivationKey)
        {
            var client = new RestClient($"{URL_Users}completeActivation");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Ubi-RequestedPlatformType", "uplay");

            request.AddBody(JsonConvert.SerializeObject(new
            {
                email = EmailAddress,
                activationKey = ActivationKey
            }));
            return Rest.Post(client, request);
        }

        public static JObject? CreateAccountAfterValidated(string EmailAddress, string Password, string DateOfBirth, string NameOnPlatform, string Country, string PreferredLanguage, string LegalOptinsKey)
        {
            var client = new RestClient(URL_Users.Remove(URL_Users.Length - 1));
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Ubi-RequestedPlatformType", "uplay");

            request.AddBody(JsonConvert.SerializeObject(new
            {
                email = EmailAddress,
                password = Password,
                dateOfBirth = DateOfBirth,
                nameOnPlatform = NameOnPlatform,
                country = Country,
                preferredLanguage = PreferredLanguage,
                legalOptinsKey = LegalOptinsKey
            }));
            return Rest.Post(client, request);
        }

        public static JObject? GetProfiles(string token, string sessionId, string UserId)
        {
            var client = new RestClient($"{URL_Users}{UserId}/profiles");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Authorization", "Ubi_v1 t=" + token);
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get(client, request);
        }

        public static JObject? GetInitialProfiles(string token, string sessionId, string UserId)
        {
            var client = new RestClient($"{URL_Users}{UserId}/initialProfiles");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);
            request.AddHeader("Authorization", "Ubi_v1 t=" + token);
            request.AddHeader("Ubi-SessionId", sessionId);

            return Rest.Get(client, request);
        }
    }
}
