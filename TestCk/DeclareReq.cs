using System.Collections.Generic;
using System.Collections.Specialized;
namespace TestCk
{
    public class DeclareReq : BaseReq
    {

        public string no { get; set; }
        public List<BodyEntity> Data { get; set; }
        public DeclareReq(string appId, string appSecret) : base(appId, appSecret)
        {
            
        }
        public override NameValueCollection ToNameValueCollection()
        {
            var nameValueCollection = base.ToNameValueCollection();
            nameValueCollection.Add("no",no);
            if (Data != null)
            {
                for (var i = 0; i < Data.Count; i++)
                {
                    var entity = Data[i];
                    var dictionary=  entity.ToDictionary();
                    if (dictionary != null)
                    {
                        foreach (var keyValuePair in dictionary)
                        {
                            string kname = keyValuePair.Key;
                            string kvalue = keyValuePair.Value?.ToString();
                            if (kvalue != null)
                            {
                                nameValueCollection.Add($"body[{i}][{kname}]",kvalue);
                            }
                        }
                    }
                  
                }
                
            }
            return nameValueCollection;

        }

    }
    public class BodyEntity
    {
        /// <summary>
        /// 备案序号
        /// </summary>
        public string itemRecordNo { get; set; }
        /// <summary>
        /// 商品料号
        /// </summary>
        public string itemNo { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string gcode { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string gname { get; set; }
        /// <summary>
        /// 商品规格型号
        /// </summary>
        public string gmodel { get; set; }
        /// <summary>
        /// 申报计量单位
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 法定计量单位
        /// </summary>
        public string unit1 { get; set; }
        /// <summary>
        /// 法定第二单位
        /// </summary>
        public string unit2 { get; set; }
        /// <summary>
        /// 原产国
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 企业申报单位
        /// </summary>
        public string price { get; set; }
        /// <summary>
        /// 企业申报总价
        /// </summary>
        public string totalPrice { get; set; }
        /// <summary>
        /// 币值
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 法定数量
        /// </summary>
        public string qty1 { get; set; }
        /// <summary>
        /// 第二法定数量
        /// </summary>
        public string qty2 { get; set; }
        /// <summary>
        /// 重量比利因子
        /// </summary>
        public string wtsfVal { get; set; }
        /// <summary>
        /// 第一比利因子
        /// </summary>
        public string fstsfVal { get; set; }
        /// <summary>
        /// 第二比利因子
        /// </summary>
        public string secdsfVal { get; set; }









        /// <summary>
        /// 申报数据
        /// </summary>
        public string qty { get; set; }

        /// <summary>
        /// 毛重
        /// </summary>
        public string grossWt { get; set; }
        /// <summary>
        /// 净量
        /// </summary>
        public string netWt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string lvyrlfModecd { get; set; }
        /// <summary>
        /// 单耗版本号
        /// </summary>
        public string ucnsVerno { get; set; }
        /// <summary>
        /// 报关单商品序列号
        /// </summary>
        public string entryGdsSeqno { get; set; }
        /// <summary>
        /// 归类标识
        /// </summary>
        public string clyMarkcd { get; set; }
        /// <summary>
        /// 流转申报
        /// </summary>
        public string applyTbSeqno { get; set; }
        
        /// <summary>
        /// 默认
        /// </summary>
        public string modfMarkcd { get; set; }
        
        /// <summary>
        /// 默认
        /// </summary>
        public string note { get; set; }
    }
}