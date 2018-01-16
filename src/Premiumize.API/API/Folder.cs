using Newtonsoft.Json;
using Premiumize.API.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Premiumize.API
{
    public static class Folder
    {
        public static CreateFolderRequest Create(string name, string parent_id = "")
        {
            return (CreateFolderRequest)HtmlService.PostJson<CreateFolderRequest>(new Uri("https://www.premiumize.me/api/folder/create"), $"name={name}&parent_id={parent_id}");
        }

        public static BaseRequest Delete(string id)
        {
            return (BaseRequest)HtmlService.PostJson<BaseRequest>(new Uri("https://www.premiumize.me/api/folder/delete"), $"id={id}");
        }

        public static FolderRequest List(string id = "", bool? includebreadcrumbs = null)
        {
            return (FolderRequest)HtmlService.GetJson<FolderRequest>(new Uri("https://www.premiumize.me/api/folder/list" + $"?id={id}&includebreadcrumbs={includebreadcrumbs}"));
        }

        public static BaseRequest Paste(string target_id, List<string> files = null, List<string> folders = null)
        {
            return (BaseRequest)HtmlService.PostJson<BaseRequest>(new Uri("https://www.premiumize.me/api/folder/paste"), $"files={files.ToString()}&folders={folders.ToString()}&target_id={target_id}");
        }
        public static BaseRequest Rename(string id, string name)
        {
            return (BaseRequest)HtmlService.PostJson<BaseRequest>(new Uri("https://www.premiumize.me/api/folder/rename"), $"id={id}&name={name}");
        }
        public static void UploadInfo(string id)
        {
            throw new NotImplementedException();
        }
    }
}
