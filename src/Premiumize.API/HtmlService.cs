using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace Premiumize.API
{
    /// <summary>
    /// Handle HTML Requests
    /// </summary>
    public static class HtmlService
    {
        /// <summary>
        /// Customer Pin from https://www.premiumize.me/account
        /// </summary>
        public static string CustomerID { get; set; }
        /// <summary>
        /// Customer Pin from https://www.premiumize.me/account
        /// </summary>
        public static string Pin { get; set; }

        /// <summary>
        /// Make GET Request and return object T
        /// </summary>
        /// <typeparam name="T">Object to Deserialise response</typeparam>
        /// <param name="url">Request URL</param>
        /// <returns></returns>
        public static object GetJson<T>(Uri url)
        {
            //Add Auth params
            if (String.IsNullOrEmpty(url.Query))
                url = new Uri(url.AbsoluteUri + $"?customer_id={CustomerID}&pin={Pin}");
            else
                url = new Uri(url.AbsoluteUri + $"&customer_id={CustomerID}&pin={Pin}");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Ubuntu Chromium/37.0.2062.120 Chrome/37.0.2062.120 Safari/537.36"; ;

            //Add Auth Cookies to prevent not Authorized reponse from some requests
            var cookieContainer = new CookieContainer();
            cookieContainer.Add(new Cookie("login", $"{CustomerID}:{Pin}", url.AbsolutePath, url.Host));

            request.CookieContainer = cookieContainer;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (String.IsNullOrEmpty(response.CharacterSet))
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                // Json String
                string data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();

                return JsonConvert.DeserializeObject<T>(data);
            }
            return null;
        }

        /// <summary>
        /// Make Post Request
        /// </summary>
        /// <typeparam name="T">Object to Deserialise response</typeparam>
        /// <param name="url">Request URl</param>
        /// <param name="parameters">Parameters added to Body</param>
        /// <returns></returns>
        public static T PostJson<T>(Uri url, string parameters = "")
        {
            // Add Auth params
            if (String.IsNullOrEmpty(parameters))
                parameters = $"customer_id={CustomerID}&pin={Pin}";
            else
                parameters += $"&customer_id={CustomerID}&pin={Pin}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Ubuntu Chromium/37.0.2062.120 Chrome/37.0.2062.120 Safari/537.36";
            request.ContentType = "application/x-www-form-urlencoded";

            //Add Auth Cookies to prevent not Authorized reponse from some requests
            var cookieContainer = new CookieContainer();
            cookieContainer.Add(new Cookie("login", $"{CustomerID}:{Pin}", url.AbsolutePath, url.Host));

            request.CookieContainer = cookieContainer;

            request.Method = "POST";

            byte[] byteArray = Encoding.UTF8.GetBytes(parameters);
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (String.IsNullOrEmpty(response.CharacterSet))
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

                //Json string
                string data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();

                var result = JsonConvert.DeserializeObject<T>(data);

                return result;
            }
            return default(T);
        }
    }
}
