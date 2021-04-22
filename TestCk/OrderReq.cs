using System.Collections.Generic;
using System.Collections.Specialized;
namespace TestCk
{
    public class OutReq:BaseReq
    {
        public List<GoodsEntity> GoodsEntities { get; set; }
        public OrderEntity Order { get; set; }
        public ReceiverEntity Receiver { get; set; }
        public OutReq(string appId, string appSecret) : base(appId, appSecret)
        {
            
        }
        public override NameValueCollection ToNameValueCollection()
        {
            var nameValueCollection= base.ToNameValueCollection();
            if (GoodsEntities != null)
            {
                for (var i = 0; i < GoodsEntities.Count; i++)
                {
                    var entity = GoodsEntities[i];
                    var dictionary=  entity.ToDictionary();
                    if (dictionary != null)
                    {
                        foreach (var keyValuePair in dictionary)
                        {
                            string cname = keyValuePair.Key;
                            string rvalue = keyValuePair.Value?.ToString();
                            if (rvalue != null)
                            {
                                nameValueCollection.Add($"body[{i}][{cname}]",rvalue);
                            }
                        }
                    }
                  
                }
            }
            var orderNameValue = Order.ToDictionary();
            foreach (var keyValuePair in orderNameValue)
            {
                if (keyValuePair.Value != null)
                {
                    nameValueCollection.Add($"order.{keyValuePair.Key}",keyValuePair.Value?.ToString());
                }
               
            }
            var receiverNameValue = Receiver.ToDictionary();
            foreach (var keyValuePair in receiverNameValue)
            {
                if (keyValuePair.Value != null)
                {
                    nameValueCollection.Add($"receiver.{keyValuePair.Key}",keyValuePair.Value?.ToString());
                }
            }

            return nameValueCollection;
        }

    }

    public class GoodsEntity
    {
        /// <summary>
        /// 商品编码
        /// </summary>
        public string goods_sn { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string goods_name { get; set; }
        
        /// <summary>
        /// 商品数量
        /// </summary>
        public string goods_number { get; set; }
    }
    public class OrderEntity
    {
        /// <summary>
        /// 外部运单号
        /// </summary>
        public string express_no { get; set; }
        /// <summary>
        /// 外部单号
        /// </summary>
        public string order_sn { get; set; }
        /// <summary>
        /// 商品总金额
        /// </summary>
        public string goods_amount { get; set; }
        /// <summary>
        /// 下单时间 
        /// </summary>
        public string add_time { get; set; }
        /// <summary>
        /// 付款时间
        /// </summary>
        public string pay_time { get; set; }
       
    }
    public class ReceiverEntity
    {
        /// <summary>
        /// 收货方联系人
        /// </summary>
        public string consignee { get; set; }
        
        /// <summary>
        /// 	收货方所在省
        /// </summary>
        public string province_name { get; set; }
        /// <summary>
        /// 	收货方所在市
        /// </summary>
        public string city_name { get; set; }
        /// <summary>
        /// 	收货方所在区
        /// </summary>
        public string district_name { get; set; }
        /// <summary>
        /// 收货方接到
        /// </summary>
        public string street_name { get; set; }
        /// <summary>
        ///  地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string mobile { get; set; }
    }
}