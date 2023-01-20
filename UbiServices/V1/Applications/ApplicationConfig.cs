﻿using DalSoft.RestClient;
using Newtonsoft.Json.Linq;

namespace UbiServices.Public
{
    public partial class V1
    {
        public partial class Applications
        {
            /// <summary>
            /// Get Application Configuration
            /// </summary>
            /// <param name="ApplicationId">Ubi-AppId</param>
            /// <returns>JObject or Null</returns>
            public static JObject? GetApplicationConfig(string ApplicationId)
            {
                if (!Validations.IdValidation(ApplicationId))
                    return null;

                string URL = $"{URL_V1Applications}{ApplicationId}/configuration";
                Dictionary<string, string> headers = new();
                headers.Add("Ubi-AppId", ApplicationId);

                var client = new RestClient(URL, headers);
                var posted = client.Get<JObject>();
                posted.Wait();

                if (posted.Result.HasValues == false)
                    return null;

                return posted.Result;
            }
        }
    }
}
