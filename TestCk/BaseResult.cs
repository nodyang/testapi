using System;
namespace TestCk
{
    public class BaseResult
    {
        public string Data { get; set; }
        public Exception ExceptionInfo { get; set; }

        public T GetT<T>()
        {
            if (ExceptionInfo != null)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(Data);
            }
            return default(T);
        }
    }
}