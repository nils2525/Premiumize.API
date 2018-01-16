using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Premiumize.API.Model
{
    public class AccountRequest : BaseRequest
    {
        [JsonProperty("premium_until")]
        public int Premium_Until { get; set; }
        [JsonProperty("limit_used")]
        public float Limit_Used { get; set; }
    }
}
