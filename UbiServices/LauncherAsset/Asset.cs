using RestSharp;

namespace UbiServices.LauncherAsset
{
    public class Asset
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="asset"></param>
        /// <returns></returns>
        public static byte[]? GetAsset(string asset)
        {

            var client = new RestClient($"https://ubistatic3-a.akamaihd.net/orbit/uplay_launcher_3_0/assets/{asset}");
            var request = new RestRequest();

            try
            {
                RestResponse response = client.GetAsync(request).Result;
                if (response.Content != null)
                {
                    Console.WriteLine(response.StatusCode);
                    return response.RawBytes;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
                InternalEx.WriteEx(ex);
                return null;
            }
        }
    }
}
