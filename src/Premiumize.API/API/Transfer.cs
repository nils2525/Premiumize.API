using Newtonsoft.Json;
using Premiumize.API.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Premiumize.API
{
    public static class Transfer
    {
        public static BaseRequest ClearFinished()
        {
            return (BaseRequest)HtmlService.PostJson<BaseRequest>(new Uri("https://www.premiumize.me/api/transfer/clearfinished"));
        }
        public static TransferRequest Create(string src)
        {
            return (TransferRequest)HtmlService.PostJson<TransferRequest>(new Uri("https://www.premiumize.me/api/transfer/create"), $"src={src}");
        }
        public static TransferRequest2 Create2(string src)
        {
            return (TransferRequest2)HtmlService.PostJson<TransferRequest2>(new Uri("https://www.premiumize.me/api/transfer/create"), $"src={src}");
        }
        public static BaseRequest Delete(string id)
        {
            return (BaseRequest)HtmlService.PostJson<BaseRequest>(new Uri("https://www.premiumize.me/api/transfer/delete"), $"id={id}");
        }
        public static TransferRequest List()
        {
            return (TransferRequest)HtmlService.GetJson<TransferRequest>(new Uri("https://www.premiumize.me/api/transfer/list"));
        }
    }
}
