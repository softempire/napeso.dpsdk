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

namespace Napeso.DPsdk.Entity.Business
{
    /// <summary>
    /// 商户集合
    /// </summary>
    public class BusinessCollection : Napeso.DPsdk.Entity.Collection
    {
        /// <summary>
        /// 所有页面商户总数，最多为40条
        /// </summary>
        [JsonProperty(PropertyName = "total_count")]
        public int TotalCount { get; internal set; }


        /// <summary>
        /// 所有商户
        /// </summary>
        [JsonProperty(PropertyName = "businesses")]
        public List<Business> Items { get; internal set; }
    }
}
