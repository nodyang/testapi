using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using NewLife.Log;
using NewLife.Serialization;

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

            OutHttpTest();
          //  StatusHttp();
         //   OutHttp();
          //  Declare();
           
            
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }


        static void Declare()
        {
            string outUrl = $"{url}api/check/declare";
            DeclareReq declareReq = new DeclareReq(appId, app_secret,outUrl)
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

            var stri = declareReq.HttpPostData();
           XTrace.WriteLine(stri.ToJson());
        }
        
        static void OutHttp()
        {
            string outUrl = $"{url}api/delivery/out";
            OutReq outReq = new OutReq(appId, app_secret,outUrl);
            
            var stri = outReq.HttpPostData();
            XTrace.WriteLine(stri.ToJson());
        }

        static void StatusHttp()
        {
            string statusUrl = $"{url}api/check/status";

            StatusReq statusReq = new StatusReq(appId, app_secret, statusUrl)
            {
                Data = new List<string>()
                {
                    "1"
                }
            };
            var stri = statusReq.HttpPostData();
            XTrace.WriteLine(stri.ToJson());
        }
        
        static void OutHttpTest()
        {
            string outUrl = $"{url}api/delivery/out";
            OutReq outReq = new OutReq(appId, app_secret, outUrl);
            OrderEntity orderEntity = new OrderEntity
            {
                order_sn = "201222",
                express_no = "1111",
                goods_amount = "100",
                add_time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(),
                pay_time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString()
            };


            ReceiverEntity receiver = new ReceiverEntity
            {
                consignee = "祝波涛",
                province_name = "山东省",
                city_name = "青岛市",
                district_name = "市北区",
                street_name = "无",
                address = "金华支路",
                mobile = "13375552067"
            };






            List<GoodsEntity> goods = new List<GoodsEntity>();

            GoodsEntity good = new GoodsEntity
            {
                goods_sn = "A1",
                goods_name = "仓库编码",
                goods_number = "1"
            };

            goods.Add(good);


            outReq.Order = orderEntity;
            outReq.Receiver = receiver;
            outReq.GoodsEntities = goods;



            var stri = outReq.HttpPostData();
            XTrace.WriteLine(stri.ToJson());
        }
    }
    
    
}