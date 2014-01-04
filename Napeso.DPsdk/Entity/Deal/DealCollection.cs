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

namespace Napeso.DPsdk.Entity.Deal
{
    /// <summary>
    /// 团购集合
    /// </summary>
    public class DealCollection : Napeso.DPsdk.Entity.Collection
    {
        /// <summary>
        /// 所有页面团购总数
        /// </summary>
        [JsonProperty(PropertyName = "total_count")]
        public int TotalCount { get; internal set; }


        /// <summary>
        /// 所有团购
        /// </summary>
        [JsonProperty(PropertyName = "deals")]
        public List<Deal> Items { get; internal set; }
    }
}
