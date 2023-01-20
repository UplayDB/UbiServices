﻿using DalSoft.RestClient;
using Newtonsoft.Json.Linq;
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
            var req = new RequestRoot(requests);
            var client = new RestClient(URL);
            var posted = client.Post<RequestRoot, JObject>(req);
            posted.Wait();

            if (posted.Result.HasValues == false)
                return null;

            return posted.Result;
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
            var posted = client.Post<string, JObject>("{\"query\":\"" + string.Join(",", productIds) + "\"}");
            posted.Wait();

            if (posted.Result.HasValues == false)
                return null;

            return posted.Result;
        }
    }
}
