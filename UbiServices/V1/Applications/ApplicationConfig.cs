﻿using Newtonsoft.Json.Linq;
using RestSharp;

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
                var client = new RestClient(URL);
                var request = new RestRequest();

                request.AddHeader("Ubi-AppId", ApplicationId);

                return Rest.Get(client, request);
            }
        }
    }
}
