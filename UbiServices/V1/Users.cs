using RestSharp;
using UbiServices.Records;

namespace UbiServices.Public
{
    public partial class V1
    {
        public static readonly string URL_UsersMe = Urls.GetUrl("v2/users/me");
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

            return Rest.Post<v2UserMe>(client, request);
        }
    }
}
