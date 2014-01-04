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
using System.Diagnostics;

using Newtonsoft.Json;

namespace Napeso.DPsdk.Entity
{
    public class Collection : Napeso.DPsdk.Entity.Entity
    {
        /// <summary>
        /// 本次API访问所获取的单页元素数量
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public int Count { get; internal set; }
    }
}
