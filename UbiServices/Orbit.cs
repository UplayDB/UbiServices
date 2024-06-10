using Newtonsoft.Json;
using RestSharp;

namespace UbiServices
{
    public class Orbit
    {
        public static string? GetFreeGameConfigs(int someId = 0580)
        {
            string URL = $"https://static3.cdn.ubi.com/orbit/uplay_launcher_14_0/free_games/{someId}/free_game_configs.yml";
            var client = new RestClient(URL);
            var request = new RestRequest();
            RestResponse response = client.GetAsync(request).Result;
            Debug.WriteDebug(JsonConvert.SerializeObject(response));
            if (response.Content != null)
            {
                return response.Content;
            }
            return null;
        }

        public static string? TestInternet()
        {
            string URL = $"https://static3.cdn.ubi.com/orbit/uplay_launcher_2_0/test_internet.txt";
            var client = new RestClient(URL);
            var request = new RestRequest();
            RestResponse response = client.GetAsync(request).Result;
            Debug.WriteDebug(JsonConvert.SerializeObject(response));
            if (response.Content != null)
            {
                Console.WriteLine(response.StatusCode);
                return response.Content;
            }
            return null;
        }

        public static string? LatestFreeGames()
        {
            string URL = $"https://static3.cdn.ubi.com/orbit/uplay_launcher_14_0/free_games/latest.txt";
            var client = new RestClient(URL);
            var request = new RestRequest();
            RestResponse response = client.GetAsync(request).Result;
            Debug.WriteDebug(JsonConvert.SerializeObject(response));
            if (response.Content != null)
            {
                return response.Content;
            }
            return null;
        }

        public static string? GetPromoConfig()
        {
            string URL = $"https://static3.cdn.ubi.com/orbit/uplay_launcher_3_0/promotions/promo_config.yml";
            var client = new RestClient(URL);
            var request = new RestRequest();
            RestResponse response = client.GetAsync(request).Result;
            Debug.WriteDebug(JsonConvert.SerializeObject(response));
            if (response.Content != null)
            {
                return response.Content;
            }
            return null;
        }

        public static byte[]? GetPatches(string version, string file)
        {
            string URL = $"http://static3.cdn.ubi.com/orbit/releases/{version}/patches/{file}";
            var client = new RestClient(URL);
            var request = new RestRequest();
            RestResponse response = client.GetAsync(request).Result;
            Debug.WriteDebug(JsonConvert.SerializeObject(response));
            if (response.RawBytes != null)
            {
                return response.RawBytes;
            }
            return null;
        }
    }
}
