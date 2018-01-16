using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;

namespace Premiumize.API
{
    public static class HtmlService
    {
        public static string CustomerID { get; set; }
        public static string Pin { get; set; }

        public static object GetJson<T>(Uri url)
        {
            if (String.IsNullOrEmpty(url.Query))
                url = new Uri(url.AbsoluteUri + $"?customer_id={CustomerID}&pin={Pin}");
            else
                url = new Uri(url.AbsoluteUri + $"&customer_id={CustomerID}&pin={Pin}");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Ubuntu Chromium/37.0.2062.120 Chrome/37.0.2062.120 Safari/537.36"; ;

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

                string data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();

                return JsonConvert.DeserializeObject<T>(data);
            }
            return null;
        }

        public static object PostJson<T>(Uri url, string parameters = "")
        {
            if (String.IsNullOrEmpty(parameters))
                parameters = $"customer_id={CustomerID}&pin={Pin}";
            else
                parameters += $"&customer_id={CustomerID}&pin={Pin}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Ubuntu Chromium/37.0.2062.120 Chrome/37.0.2062.120 Safari/537.36";
            request.ContentType = "application/x-www-form-urlencoded";

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

                string data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();

                var result = JsonConvert.DeserializeObject<T>(data);

                return result;
            }
            return null;
        }
    }
}
