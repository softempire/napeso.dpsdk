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
    /// 团购Id集合
    /// </summary>
    public class DealIdCollection : Napeso.DPsdk.Entity.Collection
    {
        /// <summary>
        /// 所有团购的ID
        /// </summary>
        [JsonProperty(PropertyName = "id_list")]
        public List<string> Items { get; internal set; }
    }
}
