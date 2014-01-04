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

namespace Napeso.DPsdk.Interface
{
    public class CouponInterface : DPInterface
    {
        public CouponInterface(Client client)
            : base(client, "coupon")
        {
        }

        //****************************************************************************************************************************

        /// <summary>
        /// 搜索优惠券 coupon/find_coupons
        /// 按照地理位置、分类、关键词等多种条件搜索优惠券信息，并以分页形式返回
        /// </summary>
        /// <param name="city">包含优惠券信息的城市名称，可选范围见相关API返回结果</param>
        /// <param name="latitude">纬度坐标，须与经度坐标同时传入</param>
        /// <param name="longitude">经度坐标，须与纬度坐标同时传入</param>
        /// <param name="radius">搜索半径，单位为米，最小值1，最大值5000，如不传入，默认值为1000</param>
        /// <param name="region">包含优惠券信息的城市区域名，可选范围见相关API返回结果（不含返回结果中包括的城市名称信息）</param>
        /// <param name="category">包含优惠券信息的分类名，可选范围见相关API返回结果</param>
        /// <param name="keyword">关键词，搜索范围包括商户名、优惠券名等</param>
        /// <param name="sort">结果排序，1:最新发布优先，2:热门优惠优先，3:最优优惠优先，4:即将结束优先，5:离经纬度坐标距离近优先，如不传入，默认值为1</param>
        /// <param name="limit">每页返回的团单结果条目数上限，最小值1，最大值40，如不传入默认为20</param>
        /// <param name="page">页码，如不传入默认为1，即第一页</param>
        /// <returns>优惠券集合</returns>
        public Napeso.DPsdk.Entity.Coupon.CouponCollection FindCoupons(string city,
            		float? latitude = null,		    
            		float? longitude = null,		
		            int? radius = null,		      
		            string region = null,		    
		            string category = null,		  
		            string keyword = null,		   
		            int? sort = null,		        
		            int? limit = null,		       
		            int? page = null)		        
        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => city), city);

                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => latitude), latitude);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => longitude), longitude);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => radius), radius);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => region), region);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => category), category);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => keyword), keyword);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => sort), sort);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => limit), limit);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => page), page);
            }

            return JsonConvert.DeserializeObject<Napeso.DPsdk.Entity.Coupon.CouponCollection>(Client.GetCommand(GetCommandName("find_coupons"),
                                                                                                                parameters));
        }

        /// <summary>
        /// 获取指定优惠券信息 coupon/get_single_coupon
        /// 根据优惠券ID获取指定优惠券的详细信息
        /// </summary>
        /// <param name="coupon_id">优惠券ID</param>
        /// <returns>优惠券</returns>
        public Napeso.DPsdk.Entity.Coupon.Coupon GetSingleCoupon(int coupon_id)
        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => coupon_id), coupon_id);
            }

            string json = Client.GetCommand(GetCommandName("get_single_coupon"), parameters);
            JObject jobj = JObject.Parse(json);

            return (jobj["count"].Value<int>() == 1)
                ? JsonConvert.DeserializeObject<Napeso.DPsdk.Entity.Coupon.Coupon>(jobj["coupons"].Children().First().ToString())
                : null;
        }
    }
}
