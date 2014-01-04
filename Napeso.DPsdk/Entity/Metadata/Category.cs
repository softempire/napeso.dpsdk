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
    public class SubCategory : Napeso.DPsdk.Entity.Entity
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        [JsonProperty(PropertyName = "category_name")]
        public string CategoryName { get; internal set; }


        /// <summary>
        /// 支持商户搜索的最新大分类下属小分类列表
        /// </summary>
        [JsonProperty(PropertyName = "subcategories")]
        public List<string> SubCategories { get; internal set; }
    }

    /// <summary>
    /// 分类
    /// </summary>
    public class Category : Napeso.DPsdk.Entity.Entity
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        [JsonProperty(PropertyName = "category_name")]
        public string CategoryName { get; internal set; }


        /// <summary>
        /// 支持商户搜索的最新大分类下属小分类列表
        /// </summary>
        [JsonProperty(PropertyName = "subcategories")]
        public List<SubCategory> SubCategories { get; internal set; }
    }
}
