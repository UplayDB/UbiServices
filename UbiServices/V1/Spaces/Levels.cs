using Newtonsoft.Json.Linq;
using RestSharp;

namespace UbiServices.Public
{
    public partial class V1
    {
        public partial class Spaces
        {
            public static JObject? GetLevel(string ticket, string level)
            {
                string URL = $"{URL_V1Spaces}/global/ubiconnect/economy/api/metaprogression?levels={level}";
                var client = new RestClient(URL);
                var request = new RestRequest();

                request.AddHeader("Ubi-AppId", V3.AppID);
                request.AddHeader("Authorization", $"Ubi_v1 t={ticket}");

                return Rest.Get(client, request);
            }

            public static JObject? GetLevels(string ticket, List<string> levels)
            {
                string jointed = "";
                if (levels.Count == 1)
                {
                    jointed = levels[0];
                }
                else if (levels.Count >= 10)
                {
                    Console.WriteLine("You cannot get more than 10 lvl once");
                    return null;
                }
                else
                {
                    jointed = string.Join(",", levels);
                }

                string URL = $"{URL_V1Spaces}/global/ubiconnect/economy/api/metaprogression?levels={jointed}";
                var client = new RestClient(URL);
                var request = new RestRequest();

                request.AddHeader("Ubi-AppId", V3.AppID);
                request.AddHeader("Authorization", $"Ubi_v1 t={ticket}");

                return Rest.Get(client, request);
            }
        }
    }
}
