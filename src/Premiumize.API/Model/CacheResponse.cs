using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Premiumize.API.Model
{
    public class CacheResponse : BaseRequest
    {
        [JsonProperty("response")]
        public List<string> Response { get; set; }
        [JsonProperty("transcoded")]
        public List<string> Transcoded { get; set; }
        [JsonProperty("filename")]
        public List<string> Filename { get; set; }
        [JsonProperty("filesize")]
        public List<string> FileSize { get; set; }
    }
}
