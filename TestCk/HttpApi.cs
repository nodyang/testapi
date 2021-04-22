using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
namespace TestCk
{
    public class HttpApi
    {


        /// <summary>
        /// multipart/form-data上传文件
        /// </summary>
        /// <param name="url">请求的url地址</param>
        /// <param name="stringDict">post参数</param>
        /// <param name="fileName">文件名</param>
        /// <param name="file">文件</param>
        /// <param name="fileKeyName">文件这一项参数的key</param>
        /// <param name="timeOut">超时间隔_秒</param>
        /// <returns>失败返回null</returns>
        public static string HttpPostData(string url, NameValueCollection stringDict)
        {



            string responseContent;

            MemoryStream memStream = null;
            Stream requestStream = null;
            HttpWebResponse httpWebResponse = null;
            HttpWebRequest webRequest = null;

            try
            {
                memStream = new MemoryStream();
                webRequest = (HttpWebRequest)WebRequest.Create(url);
                // 边界符  
                var boundary = "---------------" + DateTime.Now.Ticks.ToString("x");
                // 边界符  
                var beginBoundary = Encoding.ASCII.GetBytes("--" + boundary + "\r\n");
                // 最后的结束符  
                var endBoundary = Encoding.ASCII.GetBytes("--" + boundary + "--\r\n");

                // 设置属性  
                webRequest.Method = "POST";
                webRequest.Timeout = 3600000;
                webRequest.ContentType = "multipart/form-data; boundary=" + boundary;

                // 写入字符串的Key  
                var stringKeyHeader = "--" + boundary +
                                      "\r\nContent-Disposition: form-data; name=\"{0}\"" +
                                      "\r\n\r\n{1}\r\n";

                foreach (byte[] formitembytes in from string key in stringDict.Keys
                    select string.Format(stringKeyHeader, key, stringDict[key])
                    into formitem
                    select Encoding.UTF8.GetBytes(formitem))
                {
                    memStream.Write(formitembytes, 0, formitembytes.Length);
                }


                // 写入换行  
                var contentLine = Encoding.ASCII.GetBytes("\r\n");
                memStream.Write(contentLine, 0, contentLine.Length);

                // 写入最后的结束边界符  
                memStream.Write(endBoundary, 0, endBoundary.Length);

                webRequest.ContentLength = memStream.Length;

                requestStream = webRequest.GetRequestStream();

                memStream.Position = 0;
                var tempBuffer = new byte[memStream.Length];
                memStream.Read(tempBuffer, 0, tempBuffer.Length);
                //memStream.Close();

                requestStream.Write(tempBuffer, 0, tempBuffer.Length);
                //requestStream.Close();

                httpWebResponse = (HttpWebResponse)webRequest.GetResponse();

                using var httpStreamReader = new StreamReader(httpWebResponse.GetResponseStream(),
                    Encoding.GetEncoding("utf-8"));
                responseContent = httpStreamReader.ReadToEnd();
            }
            finally
            {
                if (memStream != null) { memStream.Close(); }
                if (requestStream != null) { requestStream.Close(); }
                if (httpWebResponse != null) { httpWebResponse.Close(); }
                if (webRequest != null) { webRequest.Abort(); }
            }

            return responseContent;
        }
    }
}
