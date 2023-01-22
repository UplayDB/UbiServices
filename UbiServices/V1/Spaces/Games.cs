using Newtonsoft.Json.Linq;
using RestSharp;

namespace UbiServices.Public
{
    public partial class V1
    {
        public partial class Spaces
        {
            public static JObject? GetGames(string ticket)
            {
                string URL = $"{URL_V1Spaces}/global/ubiconnect/games/api";
                var client = new RestClient(URL);
                var request = new RestRequest();

                request.AddHeader("Ubi-AppId", V3.AppID);
                request.AddHeader("Authorization", $"Ubi_v1 t={ticket}");

                return Rest.Get(client, request);
            }
        }
    }
}
