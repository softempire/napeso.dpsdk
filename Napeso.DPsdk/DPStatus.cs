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
using Newtonsoft.Json.Linq;

namespace Napeso.DPsdk
{
    public class DPStatus : Napeso.DPsdk.Entity.Entity
    {
        public static DPStatus Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<DPStatus>(json);
        }

        /// <summary>
        /// 状态信息
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; internal set; }

        public bool IsValid
        {
            get
            {
                return Status != "ERROR";
            }
        }
    }
}
