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
    public class DealRestriction : Napeso.DPsdk.Entity.Entity
    {
        /// <summary>
        /// 是否需要预约，0：不是，1：是
        /// </summary>
        [JsonProperty(PropertyName = "is_reservation_required")]
        public int IsReservationRequired { get; internal set; }


        /// <summary>
        /// 是否支持随时退款，0：不是，1：是
        /// </summary>
        [JsonProperty(PropertyName = "is_refundable")]
        public int IsRefundable { get; internal set; }


        /// <summary>
        /// 附加信息(一般为团购信息的特别提示)
        /// </summary>
        [JsonProperty(PropertyName = "special_tips")]
        public string SpecialTips { get; internal set; }
    }

    public class DealBusiness : Napeso.DPsdk.Entity.Entity
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
        /// 商户地址
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; internal set; }


        /// <summary>
        /// 商户纬度
        /// </summary>
        [JsonProperty(PropertyName = "latitude")]
        public float Latitude { get; internal set; }


        /// <summary>
        /// 商户经度
        /// </summary>
        [JsonProperty(PropertyName = "longitude")]
        public float Longitude { get; internal set; }


        /// <summary>
        /// 商户页链接
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; internal set; }
    }

    /// <summary>
    /// 团购
    /// </summary>
    public class Deal : Napeso.DPsdk.Entity.Entity
    {
        /// <summary>
        /// 团购单ID
        /// </summary>
        [JsonProperty(PropertyName = "deal_id")]
        public string DealId { get; internal set; }


        /// <summary>
        /// 团购标题
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; internal set; }


        /// <summary>
        /// 团购描述
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; internal set; }


        /// <summary>
        /// 城市名称，city为＂全国＂表示全国单，其他为本地单，城市范围见相关API返回结果
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public string City { get; internal set; }


        /// <summary>
        /// 团购包含商品原价值
        /// </summary>
        [JsonProperty(PropertyName = "list_price")]
        public float ListPrice { get; internal set; }


        /// <summary>
        /// 团购价格
        /// </summary>
        [JsonProperty(PropertyName = "current_price")]
        public float CurrentPrice { get; internal set; }


        /// <summary>
        /// 团购适用商户所在商区
        /// </summary>
        [JsonProperty(PropertyName = "regions")]
        public List<string> Regions { get; internal set; }


        /// <summary>
        /// 团购所属分类
        /// </summary>
        [JsonProperty(PropertyName = "categories")]
        public List<string> Categories { get; internal set; }


        /// <summary>
        /// 团购当前已购买数
        /// </summary>
        [JsonProperty(PropertyName = "purchase_count")]
        public int PurchaseCount { get; internal set; }


        /// <summary>
        /// 团购发布上线日期
        /// </summary>
        [JsonProperty(PropertyName = "publish_date")]
        public string PublishDate { get; internal set; }


        /// <summary>
        /// 团购详情
        /// </summary>
        [JsonProperty(PropertyName = "details")]
        public string Details { get; internal set; }


        /// <summary>
        /// 团购单的截止购买日期
        /// </summary>
        [JsonProperty(PropertyName = "purchase_deadline")]
        public string PurchaseDeadline { get; internal set; }


        /// <summary>
        /// 团购图片链接，最大图片尺寸450×280
        /// </summary>
        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; internal set; }


        /// <summary>
        /// 小尺寸团购图片链接，最大图片尺寸160×100
        /// </summary>
        [JsonProperty(PropertyName = "s_image_url")]
        public string SImageUrl { get; internal set; }


        /// <summary>
        /// 更多大尺寸图片
        /// </summary>
        [JsonProperty(PropertyName = "more_image_urls")]
        public List<string> MoreImageUrls { get; internal set; }


        /// <summary>
        /// 更多小尺寸图片
        /// </summary>
        [JsonProperty(PropertyName = "more_s_image_urls")]
        public List<string> MoreSImageUrls { get; internal set; }


        /// <summary>
        /// 是否为热门团购，0：不是，1：是
        /// </summary>
        [JsonProperty(PropertyName = "is_popular")]
        public int IsPopular { get; internal set; }


        /// <summary>
        /// 团购限制条件
        /// </summary>
        [JsonProperty(PropertyName = "restrictions")]
        public DealRestriction Restrictions { get; internal set; }


        /// <summary>
        /// 重要通知(一般为团购信息的临时变更)
        /// </summary>
        [JsonProperty(PropertyName = "notice")]
        public string Notice { get; internal set; }


        /// <summary>
        /// 团购Web页面链接，适用于网页应用
        /// </summary>
        [JsonProperty(PropertyName = "deal_url")]
        public string DealUrl { get; internal set; }


        /// <summary>
        /// 团购HTML5页面链接，适用于移动应用和联网车载应用
        /// </summary>
        [JsonProperty(PropertyName = "deal_h5_url")]
        public string DealH5Url { get; internal set; }


        /// <summary>
        /// 当前团单的佣金比例
        /// </summary>
        [JsonProperty(PropertyName = "commission_ratio")]
        public float CommissionRatio { get; internal set; }


        /// <summary>
        /// 团购所适用的商户列表
        /// </summary>
        [JsonProperty(PropertyName = "businesses")]
        public List<DealBusiness> Businesses { get; internal set; }
    }
}
