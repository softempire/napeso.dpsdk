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

namespace Napeso.DPsdk.Entity.Review
{
    public class ReviewAdditionalInfo : Napeso.DPsdk.Entity.Entity
    {
        /// <summary>
        /// 全部点评页面链接
        /// </summary>
        [JsonProperty(PropertyName = "more_reviews_url")]
        public string MoreReviewsUrl { get; internal set; }
    }

    public class ReviewCollection : Napeso.DPsdk.Entity.Collection
    {
        /// <summary>
        /// 所有评论
        /// </summary>
        [JsonProperty(PropertyName = "reviews")]
        public List<Review> Items { get; internal set; }
        

        /// <summary>
        /// 额外的信息
        /// </summary>
        [JsonProperty(PropertyName = "additional_info")]
        public ReviewAdditionalInfo AdditionalInfo { get; internal set; }
    }
}
