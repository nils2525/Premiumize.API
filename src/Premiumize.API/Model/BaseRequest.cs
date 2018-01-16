using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Premiumize.API
{
    public class BaseRequest
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
