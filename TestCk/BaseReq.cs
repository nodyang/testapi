using System.Collections.Specialized;
namespace TestCk
{
    public  class BaseReq
    {
        protected BaseReq(string appId, string appSecret)
        {
            AppId = appId;
            AppSecret = appSecret;
        }
        private string AppId { get; set; }
        private string AppSecret { get; set; }

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
    }
    
}