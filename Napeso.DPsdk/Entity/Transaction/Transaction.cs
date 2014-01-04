/*--------------------------------------------------------------------------
* 
* Napeso.DPsdk
*
* Created and Maintained by Summer Ding (zqding@hotmail.com)
*
--------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Napeso.DPsdk.Entity.Statistics
{
    /// <summary>
    /// 交易
    /// </summary>
    public class Transaction : DPsdk.Entity.Entity
    {
        /// <summary>
        /// 交易状态更新时间
        /// </summary>
        [JsonProperty(PropertyName = "update_time")]
        public string UpdateTime { get; internal set; }


        /// <summary>
        /// 团购ID
        /// </summary>
        [JsonProperty(PropertyName = "deal_id")]
        public string DealId { get; internal set; }


        /// <summary>
        /// 订单号
        /// </summary>
        [JsonProperty(PropertyName = "order_id")]
        public string OrderId { get; internal set; }


        /// <summary>
        /// 团购单价
        /// </summary>
        [JsonProperty(PropertyName = "unit_price")]
        public float UnitPrice { get; internal set; }


        /// <summary>
        /// 交易下单量
        /// </summary>
        [JsonProperty(PropertyName = "transaction_count")]
        public int TransactionCount { get; internal set; }


        /// <summary>
        /// 团购订单总价
        /// </summary>
        [JsonProperty(PropertyName = "transaction_amount")]
        public float TransactionAmount { get; internal set; }


        /// <summary>
        /// 交易状态，1:用户下单，2:用户付费，3:退款，4:验券
        /// </summary>
        [JsonProperty(PropertyName = "transaction_status")]
        public int TransactionStatus { get; internal set; }


        /// <summary>
        /// 第三方应用用户的标识，使用方法如：注意事项．
        /// </summary>
        [JsonProperty(PropertyName = "uid")]
        public string Uid { get; internal set; }


        /// <summary>
        /// 当前团单的佣金比例
        /// </summary>
        [JsonProperty(PropertyName = "commission_ratio")]
        public float CommissionRation { get; internal set; }
    }
}
