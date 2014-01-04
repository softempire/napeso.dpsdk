/*--------------------------------------------------------------------------
* 
* Napeso.DPsdk
*
* Created and Maintained by Summer Ding (zqding@hotmail.com)
*
--------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Napeso.DPsdk.Entity.Review
{
    /// <summary>
    /// 评论
    /// </summary>
    public class Review : DPsdk.Entity.Entity
    {
        /// <summary>
        /// 单条点评ID
        /// </summary>
        [JsonProperty(PropertyName = "review_id")]
        public int ReviewId { get; internal set; }


        /// <summary>
        /// 该条点评作者用户名
        /// </summary>
        [JsonProperty(PropertyName = "user_nickname")]
        public string UserNickname { get; internal set; }


        /// <summary>
        /// 点评创建时间
        /// </summary>
        [JsonProperty(PropertyName = "created_time")]
        public string CreatedTime { get; internal set; }


        /// <summary>
        /// 点评文字片断，前50字
        /// </summary>
        [JsonProperty(PropertyName = "text_excerpt")]
        public string TextExcerpt { get; internal set; }


        /// <summary>
        /// 点评作者提供的星级评分，5.0代表五星，4.5代表四星半，依此类推
        /// </summary>
        [JsonProperty(PropertyName = "review_rating")]
        public float ReviewRating { get; internal set; }


        /// <summary>
        /// 星级图片链接
        /// </summary>
        [JsonProperty(PropertyName = "rating_img_url")]
        public string RatingImgUrl { get; internal set; }


        /// <summary>
        /// 小尺寸星级图片链接
        /// </summary>
        [JsonProperty(PropertyName = "rating_s_img_url")]
        public string RatingSImgUrl { get; internal set; }


        /// <summary>
        /// 产品/食物口味评价，0:差，1:一般，2:好，3:很好，4:非常好
        /// </summary>
        [JsonProperty(PropertyName = "product_rating")]
        public int ProductRating { get; internal set; }


        /// <summary>
        /// 环境评价，0:差，1:一般，2:好，3:很好，4:非常好
        /// </summary>
        [JsonProperty(PropertyName = "decoration_rating")]
        public int DecorationRating { get; internal set; }


        /// <summary>
        /// 服务评价，0:差，1:一般，2:好，3:很好，4:非常好
        /// </summary>
        [JsonProperty(PropertyName = "service_rating")]
        public int ServiceRating { get; internal set; }


        /// <summary>
        /// 点评页面链接
        /// </summary>
        [JsonProperty(PropertyName = "review_url")]
        public string ReviewUrl { get; internal set; }
    }
}
