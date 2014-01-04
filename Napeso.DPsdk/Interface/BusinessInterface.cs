/*--------------------------------------------------------------------------
* 
* Napeso.DPsdk
*
* Created and Maintained by Summer Ding (zqding@hotmail.com)
*
--------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Napeso.DPsdk;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Napeso.DPsdk.Interface
{
    public class BusinessInterface : DPInterface
    {
        public BusinessInterface(Client client)
			: base(client, "business")
		{
		}

        //*******************************************************************************************************************************************

        /// <summary>
        /// 搜索商户 business/find_businesses
        /// 按照地理位置、商区、分类、关键词等多种条件获取商户信息列表
        /// </summary>
        /// <param name="latitude">纬度坐标，须与经度坐标同时传入，与城市名称二者必选其一传入</param>
        /// <param name="longitude">经度坐标，须与纬度坐标同时传入，与城市名称二者必选其一传入</param>
        /// <param name="offset_type">偏移类型，0:未偏移，1:高德坐标系偏移，2:图吧坐标系偏移，如不传入，默认值为0</param>
        /// <param name="radius">搜索半径，单位为米，最小值1，最大值5000，如不传入默认为1000</param>
        /// <param name="city">城市名称，可选范围见相关API返回结果，与经纬度坐标二者必选其一传入</param>
        /// <param name="region">城市区域名，可选范围见相关API返回结果（不含返回结果中包括的城市名称信息），如传入城市区域名，则城市名称必须传入</param>
        /// <param name="category">分类名，可选范围见相关API返回结果；支持同时输入多个分类，以逗号分隔，最大不超过5个。</param>
        /// <param name="keyword">关键词，搜索范围包括商户名、地址、标签等</param>
        /// <param name="out_offset_type">传出经纬度偏移类型，1:高德坐标系偏移，2:图吧坐标系偏移，如不传入，默认值为1</param>
        /// <param name="platform">传出链接类型，1:web站链接（适用于网页应用），2:HTML5站链接（适用于移动应用和联网车载应用），如不传入，默认值为1</param>
        /// <param name="has_coupon">根据是否有优惠券来筛选返回的商户，1:有，0:没有</param>
        /// <param name="has_deal">根据是否有团购来筛选返回的商户，1:有，0:没有</param>
        /// <param name="has_online_reservation">根据是否支持在线预订来筛选返回的商户，1:有，0:没有</param>
        /// <param name="sort">结果排序，1:默认，2:星级高优先，3:产品评价高优先，4:环境评价高优先，5:服务评价高优先，6:点评数量多优先，7:离传入经纬度坐标距离近优先，8:人均价格低优先，9：人均价格高优先</param>
        /// <param name="limit">每页返回的商户结果条目数上限，最小值1，最大值40，如不传入默认为20</param>
        /// <param name="page">页码，如不传入默认为1，即第一页</param>
        /// <returns>商户集合</returns>
        public Napeso.DPsdk.Entity.Business.BusinessCollection FindBusinesses(
            		float? latitude = null,		           
	                float? longitude = null,		        
		            int? offset_type = null,		        
		            int? radius = null,		                 
		            string city = null,		                
		            string region = null,           		
		            string category = null,		         
		            string keyword = null,		           
		            int? out_offset_type = null,		    
		            int? platform = null,           		
		            int? has_coupon = null,		         
		            int? has_deal = null,		            
		            int? has_online_reservation = null,		
		            int? sort = null,	                	
		            int? limit = null,		               
		            int? page = null)		                
        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => latitude), latitude);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => longitude), longitude);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => offset_type), offset_type);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => radius), radius);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => city), city);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => region), region);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => category), category);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => keyword), keyword);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => out_offset_type), out_offset_type);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => platform), platform);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => has_coupon), has_coupon);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => has_deal), has_deal);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => has_online_reservation), has_online_reservation);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => sort), sort);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => limit), limit);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => page), page);
            }

            return JsonConvert.DeserializeObject<Napeso.DPsdk.Entity.Business.BusinessCollection>(Client.GetCommand(GetCommandName("find_businesses"),
                                                                                                                                   parameters));
        }

        /// <summary>
        /// 获取指定商户信息 business/get_single_business
        /// 根据商户ID获取指定商户的详细信息
        /// </summary>
        /// <param name="business_id">商户ID</param>
        /// <param name="out_offset_type">传出经纬度偏移类型，1:高德坐标系偏移，2:图吧坐标系偏移，如不传入，默认值为1</param>
        /// <param name="platform">传出链接类型，1:web站链接（适用于网页应用），2:HTML5站链接（适用于移动应用和联网车载应用），如不传入，默认值为1</param>
        /// <returns>商户</returns>
        public Napeso.DPsdk.Entity.Business.Business GetSingleBusiness(int business_id,
            		int? out_offset_type = null,		
		            int? platform = null)		        
        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => business_id), business_id);

                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => out_offset_type), out_offset_type);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => platform), out_offset_type);
            }

            string json = Client.GetCommand(GetCommandName("get_single_business"), parameters);
            JObject jobj = JObject.Parse(json);

            return (jobj["count"].Value<int>() == 1)
                ? JsonConvert.DeserializeObject<Napeso.DPsdk.Entity.Business.Business>(jobj["businesses"].Children().First().ToString())
                : null;
        }

        /// <summary>
        /// 获取指定结果列表页面链接 business/get_search_result_url
        /// 获取指定搜索条件对应的大众点评结果列表页面链接
        /// </summary>
        /// <param name="city">城市名称，可选范围见相关API返回结果</param>
        /// <param name="region">城市区域名，可选范围见相关API返回结果（不含返回结果中包括的城市名称信息）</param>
        /// <param name="category">分类名，可选范围见相关API返回结果;支持多个category搜索，最多5个</param>
        /// <param name="keyword">关键词，搜索范围包括商户名、地址、标签等</param>
        /// <param name="sort">结果排序，1:默认，2:星级高优先，3:产品评价高优先，4:环境评价高优先，5:服务评价高优先，6:点评数量多优先</param>
        /// <param name="platform">传出链接类型，1:web站链接（适用于网页应用），2:HTML5站链接（适用于移动应用和联网车载应用），如不传入，默认值为1</param>
        /// <returns>Url字符串</returns>
        public string GetSearchResultUrl(string city,
            		string region = null,	    	
            		string category = null, 		
		            string keyword = null,		  
		            int? sort = null,		        
		            int? platform = null)		    
        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => city), city);

                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => region), region);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => category), category);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => keyword), keyword);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => sort), sort);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => platform), platform);
            }

            string json = Client.GetCommand(GetCommandName("get_search_result_url"), parameters);
            JObject jobj = JObject.Parse(json);

            return jobj["search_result_url"].Value<string>();
        }
    }
}
