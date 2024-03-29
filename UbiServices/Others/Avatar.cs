﻿using RestSharp;

namespace UbiServices.Others
{
    public class Avatar
    {
        /// <summary>
        /// Get Avatar
        /// </summary>
        /// <param name="UserId">User Id</param>
        /// <param name="size">256</param>
        /// <returns>Byte Array or null</returns>
        public static byte[]? GetAvatar(string UserId, string size)
        {

            var client = new RestClient($"https://ubisoft-avatars.akamaized.net/{UserId}/default_{size}_{size}.png");
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
