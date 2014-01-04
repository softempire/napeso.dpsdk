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

namespace Napeso.DPsdk.Entity.Coupon
{
    public class CouponBusiness : Napeso.DPsdk.Entity.Entity
    {
        /// <summary>
        /// 商户名
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; internal set; }


        /// <summary>
        /// 商户ID
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; internal set; }


        /// <summary>
        /// 商户Web页面链接，适用于网页应用
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; internal set; }


        /// <summary>
        /// 商户HTML5页面链接，适用于移动应用和联网车载应用
        /// </summary>
        [JsonProperty(PropertyName = "h5_url")]
        public string H5Url { get; internal set; }
    }

    /// <summary>
    /// 优惠券
    /// </summary>
    public class Coupon : Napeso.DPsdk.Entity.Entity
    {
        /// <summary>
        /// 优惠券ID
        /// </summary>
        [JsonProperty(PropertyName = "coupon_id")]
        public int CouponId { get; internal set; }


        /// <summary>
        /// 优惠券标题
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; internal set; }


        /// <summary>
        /// 优惠券描述
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; internal set; }


        /// <summary>
        /// 优惠券适用商户所在行政区
        /// </summary>
        [JsonProperty(PropertyName = "regions")]
        public List<string> Regions { get; internal set; }


        /// <summary>
        /// 优惠券所属分类
        /// </summary>
        [JsonProperty(PropertyName = "categories")]
        public List<string> Categories { get; internal set; }


        /// <summary>
        /// 优惠券当前已下载量
        /// </summary>
        [JsonProperty(PropertyName = "download_count")]
        public int DownloadCount { get; internal set; }


        /// <summary>
        /// 优惠券发布上线日期
        /// </summary>
        [JsonProperty(PropertyName = "publish_date")]
        public string PublishDate { get; internal set; }


        /// <summary>
        /// 优惠券的截止使用日期
        /// </summary>
        [JsonProperty(PropertyName = "expiration_date")]
        public string ExpirationDate { get; internal set; }


        /// <summary>
        /// 优惠券的图标，尺寸120＊90
        /// </summary>
        [JsonProperty(PropertyName = "logo_img_url")]
        public string LogoImgUrl { get; internal set; }


        /// <summary>
        /// 优惠券Web页面链接，适用于网页应用
        /// </summary>
        [JsonProperty(PropertyName = "coupon_url")]
        public string CouponUrl { get; internal set; }


        /// <summary>
        /// 优惠券HTML5页面链接，适用于移动应用和联网车载应用
        /// </summary>
        [JsonProperty(PropertyName = "coupon_h5_url")]
        public string CouponH5Url { get; internal set; }


        /// <summary>
        /// 优惠券所适用的商户列表
        /// </summary>
        [JsonProperty(PropertyName = "businesses")]
        public List<CouponBusiness> Businesses { get; internal set; }
    }
}
