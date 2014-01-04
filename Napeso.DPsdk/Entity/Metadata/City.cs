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

namespace Napeso.DPsdk.Entity.Metadata
{
    public class District : Napeso.DPsdk.Entity.Entity
    {
        /// <summary>
        /// 支持商户搜索的最新城市下属行政区列表
        /// </summary>
        [JsonProperty(PropertyName = "district_name")]
        public string DistrictName { get; internal set; }


        /// <summary>
        /// 支持商户搜索的最新行政区下属商区列表
        /// </summary>
        [JsonProperty(PropertyName = "neighborhoods")]
        public List<string> Neighborhoods { get; internal set; }
    }

    public class City : Napeso.DPsdk.Entity.Entity
    {
        /// <summary>
        /// 城市名称，可选范围见相关API返回结果
        /// </summary>
        [JsonProperty(PropertyName = "city_name")]
        public string CityName { get; internal set; }


        /// <summary>
        /// 支持商户搜索的最新城市列表
        /// </summary>
        [JsonProperty(PropertyName = "districts")]
        public List<District> Districts { get; internal set; }
    }
}
