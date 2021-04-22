using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using NewLife.Log;

namespace TestCk
{
    class Program
    {
        static string url = "http://apitest.wonmore.com/";
        static string appId = "test";
        static string app_secret = "test123456";
        static void Main(string[] args)
        {
            NewLife.Log.XTrace.UseConsole(true, false);

            StatusHttp();
            OutHttp();
            Declare();
           
            
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }


        static void Declare()
        {
            string outUrl = $"{url}api/check/declare";
            DeclareReq declareReq = new DeclareReq(appId, app_secret)
            {
                no = "单号",
                Data = new List<BodyEntity>()
                {
                    new BodyEntity()
                    {
                        itemRecordNo = "23423"
                    }
                }
            };
            
           var stri= HttpApi.HttpPostData(outUrl, declareReq.ToNameValueCollection());
           XTrace.WriteLine(stri);
        }
        
        static void OutHttp()
        {
            string outUrl = $"{url}api/delivery/out";
            OutReq outReq = new OutReq(appId, app_secret);
            
            var stri= HttpApi.HttpPostData(outUrl, outReq.ToNameValueCollection());
            
            XTrace.WriteLine(stri);
        }

        static void StatusHttp()
        {
            string statusUrl = $"{url}api/check/status";

            StatusReq statusReq = new StatusReq(appId, app_secret)
            {
                Data = new List<string>()
                {
                    "1"
                }
            };
            var stri= HttpApi.HttpPostData(statusUrl, statusReq.ToNameValueCollection());
            
            XTrace.WriteLine(stri);
        }
    }
}