﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using UbiServices.Records;

namespace UbiServices.Store
{
    public static class AlgoliaSearch
    {
        /// <summary>
        /// Post Request datas to get the Search result<br/>
        /// IndexNames: (storetype)_product_suggestion,(storetype)_best_sellers_query_suggestions
        /// </summary>
        /// <param name="requests"></param>
        /// <returns>JObject or Null</returns>
        public static JObject? PostStoreAlgoliaSearch(List<Request> requests)
        {
            string URL = $"https://xely3u4lod-dsn.algolia.net/1/indexes/*/queries?x-algolia-agent=Algolia%20for%20JavaScript%20(3.35.1)%3B%20Browser&x-algolia-application-id=XELY3U4LOD&x-algolia-api-key=5638539fd9edb8f2c6b024b49ec375bd";
            var client = new RestClient(URL);
            var request = new RestRequest();

            var req = new RequestRoot(requests);
            request.AddBody(JsonConvert.SerializeObject(req));

            return Rest.Post(client, request);
        }

        /// <summary>
        /// Query in Ubisoft Algolia Database via items
        /// </summary>
        /// <param name="storeType">ie,uk,us</param>
        /// <param name="productIds">List of productIds</param>
        /// <returns>JObject or Null</returns>
        public static JObject? PostStoreAlgoliaQuery(Enums.CountryCode storeType, List<string> productIds)
        {
            string URL = $"https://xely3u4lod-dsn.algolia.net/1/indexes/{storeType.ToString()}_custom_MFE/query?x-algolia-agent=Algolia%20for%20JavaScript%20(4.8.5)%3B%20Browser&x-algolia-application-id=XELY3U4LOD&x-algolia-api-key=5638539fd9edb8f2c6b024b49ec375bd";
            var client = new RestClient(URL);
            var request = new RestRequest();
            string jointed = "";
            if (productIds.Count == 1)
            {
                jointed = productIds[0];
            }
            else
            {
                jointed = string.Join(",", productIds);
            }

            request.AddBody("{\"query\":\"" + jointed + "\"}");

            return Rest.Post(client, request);
        }

        public static JObject? GetStoreAlgolia(Enums.LocaleCode locale)
        {
            string URL = $"https://avcvysejs1-dsn.algolia.net/1/indexes/products_{locale.ToString()}_default?&query=&hitsPerPage=10000";
            var client = new RestClient(URL);
            var request = new RestRequest();
            request = request.AddHeader("Content-Type", "application/json");
            request = request.AddHeader("X-Algolia-Api-Key", "9258b782262f815cdfee54a00cf69d02");
            request = request.AddHeader("X-Algolia-Application-Id", "AVCVYSEJS1");

            return Rest.Get(client, request);
        }
    }
}
