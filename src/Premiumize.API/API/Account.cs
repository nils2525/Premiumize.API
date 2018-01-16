using Newtonsoft.Json;
using Premiumize.API.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Premiumize.API
{
    public static class Account
    {
        public static AccountRequest Info()
        {
            return (AccountRequest)HtmlService.PostJson<AccountRequest>(new Uri("https://www.premiumize.me/api/account/info"));
        }
    }
}
