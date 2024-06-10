using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbiServices.Others
{
    public class GameStatus
    {
        public static JObject? GetGameStatus(string AppId)
        {
            string URL = $"https://game-status-api.ubisoft.com/v1/instances?appIds={AppId}";
            var client = new RestClient(URL);
            var request = new RestRequest();

            return Rest.Get(client, request);
        }
    }
}
