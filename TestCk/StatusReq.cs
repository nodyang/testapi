using System.Collections.Generic;
using System.Collections.Specialized;
namespace TestCk
{
    public class StatusReq:BaseReq
    {
        public StatusReq(string appId, string appSecret) : base(appId, appSecret)
        {
            
        }
        public List<string> Data { get; set; }
        public override NameValueCollection ToNameValueCollection()
        {
            var nameCollection=base.ToNameValueCollection();
            if (Data != null)
            {
                for (var i = 0; i < Data.Count; i++)
                {
                    string val = $"seq_arr[{i}]";
                    nameCollection.Add(val,Data[i]);
                }
            }
            return nameCollection;
        }
    }
}