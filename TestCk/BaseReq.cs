using System;
using System.Collections.Specialized;
using System.Security.Principal;
using NewLife.Serialization;
namespace TestCk
{
    public  class BaseReq
    {
        protected BaseReq(string appId, string appSecret, string url)
        {
            
            AppId = appId;
            AppSecret = appSecret;
            this.url = url;
        }
        private string AppId { get; set; }
        private string AppSecret { get; set; }

        private String url;
        public virtual NameValueCollection ToNameValueCollection()
        {
            NameValueCollection nameValueCollection = new NameValueCollection
            {
                {
                    "app_id", AppId
                },
                {
                    "app_secret", AppSecret
                }
            };
            return nameValueCollection;
        }

        public BaseResult HttpPostData()
        {
            BaseResult result = new BaseResult();
            try
            {
                var s = this.ToNameValueCollection().ToJson();
                string json=  HttpApi.HttpPostData(url, this.ToNameValueCollection());
               result.Data = json;
            }
            catch (Exception e)
            {
                result.ExceptionInfo = e;
                
            }
            return result;
        }
    }
    
}