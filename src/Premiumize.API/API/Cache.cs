using Premiumize.API.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Premiumize.API.API
{
    public static class Cache
    {
        public static CacheResponse IsCached(string url)
        {
            var queryString = "?" + "items[]=" + url;
            return HtmlService.PostJson<CacheResponse>(new Uri("https://www.premiumize.me/api/cache/check"), queryString);
        }
        public static CacheResponse IsCached(List<string> urls)
        {
            var queryString = "?";
            bool isFirst = true;
            foreach (var url in urls)
            {
                if (!isFirst)
                {
                    queryString += "&";
                }
                else
                {
                    isFirst = !isFirst;
                }

                queryString += "items[]=" + url;
            }

            return HtmlService.PostJson<CacheResponse>(new Uri("https://www.premiumize.me/api/cache/check"), queryString);
        }
    }
}
