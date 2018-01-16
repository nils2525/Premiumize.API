using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Premiumize.API.Model
{
    public class FolderRequest : BaseRequest
    {
        [JsonProperty("content")]
        public List<FolderItem> Folders { get; set; }
    }
    public class CreateFolderRequest : BaseRequest
    {
        [JsonProperty("id")]
        public string ID { get; set; }
    }

    public class FolderItem
    {
        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("stream_link")]
        public string Stream_Link { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("created_at")]
        public int Created_At { get; set; }

        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("breadcrumbs")]
        public List<BreadCrumbItem> BreadCrumbs { get; set; }
    }
    public class BreadCrumbItem
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("parent_id")]
        public string Parent_ID { get; set; }
    }
}
