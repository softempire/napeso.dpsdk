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
    public class Error : Napeso.DPsdk.Entity.Entity
    {
        public static Error Deserialize(string json)
        {
            JObject jobj = JObject.Parse(json);

            return JsonConvert.DeserializeObject<Error>(jobj["error"].ToString());
        }

        /// <summary>
        /// 错误码
        /// </summary>
        [JsonProperty(PropertyName = "errorCode")]
        public int ErrorCode { get; internal set; }


        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonProperty(PropertyName = "errorMessage")]
        public string ErrorMessage { get; internal set; }
    }
}
