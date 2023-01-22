using Newtonsoft.Json.Linq;
using RestSharp;

namespace UbiServices.Public
{
    public partial class V3
    {
        public static readonly string URL_Policies = Urls.GetUrl("v3/policies/");

        public static JObject? GetPolicies(string userCountry, string userLocale)
        {
            var client = new RestClient($"{URL_Profiles}{userCountry}?languageCode={userLocale}&contentFormat=plain");
            var request = new RestRequest();

            request.AddHeader("Ubi-AppId", AppID);

            return Rest.Get(client, request);
        }
    }
}
