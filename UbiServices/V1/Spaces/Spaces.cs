﻿using RestSharp;
using UbiServices.Records;

namespace UbiServices.Public
{
    public partial class V1
    {
        public partial class Spaces
        {
            public static readonly string URL_V1Spaces = Urls.GetUrl("v1/spaces/");
            /// <summary>
            /// Get Space Info
            /// </summary>
            /// <param name="SpaceId">Space Id</param>
            /// <returns>V1Spaces or Null</returns>
            public static V1Spaces? GetSpaces(string SpaceId)
            {
                if (!Validations.IdValidation(SpaceId))
                    return null;

                string URL = $"{URL_V1Spaces}{SpaceId}";
                var client = new RestClient(URL);
                var request = new RestRequest();

                request.AddHeader("Ubi-AppId", V3.AppID);

                return Rest.Get<V1Spaces>(client, request);
            }
        }
    }
}
