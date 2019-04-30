using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Premiumize.API.Model
{
    public class TransferRequest : BaseRequest
    {
        [JsonProperty("name")]
        string Name { get; set; }
        [JsonProperty("transfers")]
        List<TransferItem> TransferItems { get; set; }
    }
    public class TransferItem
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("progress")]
        public int Progress { get; set; }
        [JsonProperty("target_folder_id")]
        public string Target_Folder_ID { get; set; }
        [JsonProperty("folder_id")]
        public string Folder_ID { get; set; }
        [JsonProperty("file_id")]
        public string File_ID { get; set; }
    }

    public class TransferRequest2 : BaseRequest
    {
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("filename")]
        public string FileName { get; set; }
        [JsonProperty("filesize")]
        public string FileSize { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
