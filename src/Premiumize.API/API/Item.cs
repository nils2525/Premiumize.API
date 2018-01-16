using System;
using System.Collections.Generic;
using System.Text;

namespace Premiumize.API.API
{
    public static class Item
    {
        public static BaseRequest Delte(string id)
        {
            return (BaseRequest)HtmlService.PostJson<BaseRequest>(new Uri("https://www.premiumize.me/api/item/delete"), $"id={id}");
        }
        public static BaseRequest Delte(string id, string name)
        {
            return (BaseRequest)HtmlService.PostJson<BaseRequest>(new Uri("https://www.premiumize.me/api/item/rename"), $"id={id}&name={name}");
        }
    }
}
