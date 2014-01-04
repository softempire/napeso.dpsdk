/*--------------------------------------------------------------------------
* 
* Napeso.DPsdk
*
* Created and Maintained by Summer Ding (zqding@hotmail.com)
*
--------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Napeso.DPsdk.Entity.Coupon
{
    /// <summary>
    /// 优惠券集合
    /// </summary>
    public class CouponCollection : Napeso.DPsdk.Entity.Collection
    {
        /// <summary>
        /// 所有页面优惠券总数
        /// </summary>
        [JsonProperty(PropertyName = "total_count")]
        public int TotalCount { get; internal set; }


        /// <summary>
        /// 所有优惠券
        /// </summary>
        [JsonProperty(PropertyName = "coupons")]
        public List<Coupon> Items { get; internal set; }
    }
}
