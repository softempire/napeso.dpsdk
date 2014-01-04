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
using Napeso.DPsdk.Entity.Metadata;

using Newtonsoft.Json;

namespace Napeso.DPsdk.Entity.Business
{
    public class BusinessDeal : Napeso.DPsdk.Entity.Entity
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; internal set; }


        /// <summary>
        /// 描述
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; internal set; }


        /// <summary>
        /// Url
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; internal set; }
    }

    /// <summary>
    /// 商户
    /// </summary>
    public class Business : DPsdk.Entity.Entity
    {
        /// <summary>
        /// 商户ID
        /// </summary>
        [JsonProperty(PropertyName = "business_id")]
        public int BusinessId { get; internal set; }


        /// <summary>
        /// 商户名
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; internal set; }


        /// <summary>
        /// 分店名
        /// </summary>
        [JsonProperty(PropertyName = "branch_name")]
        public string BranchName { get; internal set; }


        /// <summary>
        /// 地址
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; internal set; }


        /// <summary>
        /// 带区号的电话
        /// </summary>
        [JsonProperty(PropertyName = "telephone")]
        public string Telephone { get; internal set; }


        /// <summary>
        /// 所在城市
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public string City { get; internal set; }


        /// <summary>
        /// 所在区域信息列表，如[徐汇区，徐家汇]
        /// </summary>
        [JsonProperty(PropertyName = "regions")]
        public List<string> Regions { get; internal set; }


        /// <summary>
        /// 所属分类信息列表，如[宁波菜，婚宴酒店]
        /// </summary>
        [JsonProperty(PropertyName = "categories")]
        public List<string> Categories { get; internal set; }


        /// <summary>
        /// 纬度坐标
        /// </summary>
        [JsonProperty(PropertyName = "latitude")]
        public float Latitude { get; internal set; }


        /// <summary>
        /// 经度坐标
        /// </summary>
        [JsonProperty(PropertyName = "longitude")]
        public float Longitude { get; internal set; }


        /// <summary>
        /// 星级评分，5.0代表五星，4.5代表四星半，依此类推
        /// </summary>
        [JsonProperty(PropertyName = "avg_rating")]
        public float AvgRating { get; internal set; }


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
        /// 产品/食品口味评价，1:一般，2:尚可，3:好，4:很好，5:非常好
        /// </summary>
        [JsonProperty(PropertyName = "product_grade")]
        public int ProductGrade { get; internal set; }


        /// <summary>
        /// 环境评价，1:一般，2:尚可，3:好，4:很好，5:非常好
        /// </summary>
        [JsonProperty(PropertyName = "decoration_grade")]
        public int DecorationGrade { get; internal set; }


        /// <summary>
        /// 服务评价，1:一般，2:尚可，3:好，4:很好，5:非常好
        /// </summary>
        [JsonProperty(PropertyName = "service_grade")]
        public int ServiceGrade { get; internal set; }


        /// <summary>
        /// 产品/食品口味评价单项分，精确到小数点后一位（十分制）
        /// </summary>
        [JsonProperty(PropertyName = "product_score")]
        public float ProductScore { get; internal set; }


        /// <summary>
        /// 环境评价单项分，精确到小数点后一位（十分制）
        /// </summary>
        [JsonProperty(PropertyName = "decoration_score")]
        public float DecorationScore { get; internal set; }


        /// <summary>
        /// 服务评价单项分，精确到小数点后一位（十分制）
        /// </summary>
        [JsonProperty(PropertyName = "service_score")]
        public float ServiceScore { get; internal set; }


        /// <summary>
        /// 人均价格，单位:元，若没有人均，返回-1
        /// </summary>
        [JsonProperty(PropertyName = "avg_price")]
        public int AvgPrice { get; internal set; }


        /// <summary>
        /// 点评数量
        /// </summary>
        [JsonProperty(PropertyName = "review_count")]
        public int ReviewCount { get; internal set; }


        /// <summary>
        /// 商户与参数坐标的距离，单位为米，如不传入经纬度坐标，结果为-1
        /// </summary>
        [JsonProperty(PropertyName = "distance")]
        public int Distance { get; internal set; }


        /// <summary>
        /// 商户页面链接
        /// </summary>
        [JsonProperty(PropertyName = "business_url")]
        public string BusinessUrl { get; internal set; }


        /// <summary>
        /// 照片链接，照片最大尺寸700×700
        /// </summary>
        [JsonProperty(PropertyName = "photo_url")]
        public string PhotoUrl { get; internal set; }


        /// <summary>
        /// 小尺寸照片链接，照片最大尺寸278×200
        /// </summary>
        [JsonProperty(PropertyName = "s_photo_url")]
        public string SPhotoUrl { get; internal set; }


        /// <summary>
        /// 是否有优惠券，0:没有，1:有
        /// </summary>
        [JsonProperty(PropertyName = "has_coupon")]
        public int HasCoupon { get; internal set; }


        /// <summary>
        /// 优惠券ID
        /// </summary>
        [JsonProperty(PropertyName = "coupon_id")]
        public int CouponId { get; internal set; }


        /// <summary>
        /// 优惠券描述
        /// </summary>
        [JsonProperty(PropertyName = "coupon_description")]
        public string CouponDescription { get; internal set; }


        /// <summary>
        /// 优惠券页面链接
        /// </summary>
        [JsonProperty(PropertyName = "coupon_url")]
        public string CouponUrl { get; internal set; }


        /// <summary>
        /// 是否有团购，0:没有，1:有
        /// </summary>
        [JsonProperty(PropertyName = "has_deal")]
        public int HasDeal { get; internal set; }


        /// <summary>
        /// 商户当前在线团购数量
        /// </summary>
        [JsonProperty(PropertyName = "deal_count")]
        public int DealCount { get; internal set; }


        /// <summary>
        /// 团购列表
        /// </summary>
        [JsonProperty(PropertyName = "deals")]
        public List<Napeso.DPsdk.Entity.Business.BusinessDeal> Deals { get; internal set; }


        /// <summary>
        /// 是否有在线预订，0:没有，1:有
        /// </summary>
        [JsonProperty(PropertyName = "has_online_reservation")]
        public int HasOnlineReservation { get; internal set; }


        /// <summary>
        /// 在线预订页面链接，目前仅返回HTML5站点链接
        /// </summary>
        [JsonProperty(PropertyName = "online_reservation_url")]
        public string OnlineReservationUrl { get; internal set; }
    }
}
