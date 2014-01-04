/*--------------------------------------------------------------------------
* 
* Napeso.DPsdk
*
* Created and Maintained by Summer Ding (zqding@hotmail.com)
*
--------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Napeso.DPsdk;
using Napeso.DPsdk.Entity.Deal;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Napeso.DPsdk.Interface
{
    public class DealInterface : DPInterface
    {
        public DealInterface(Client client)
            : base(client, "deal")
        {
        }

        //*************************************************************************************************************************************************

        /// <summary>
        /// 获取当前在线的全部团购ID列表 deal/get_all_id_list
        /// 获取指定城市当前在线的全部团购ID列表
        /// </summary>
        /// <param name="city">包含团购信息的城市名称，可选范围见相关API返回结果</param>
        /// <param name="category">包含团购信息的分类名，支持多个category合并查询，多个category用逗号分割。可选范围见相关API返回结果</param>
        /// <returns>团购Id集合</returns>
        public Napeso.DPsdk.Entity.Deal.DealIdCollection GetAllIdList(string city,
            		string category = null)	    	
        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => city), city);

                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => category), category);
            }

            return JsonConvert.DeserializeObject<Napeso.DPsdk.Entity.Deal.DealIdCollection>(Client.GetCommand(GetCommandName("get_all_id_list"),
                                                                                                                             parameters));
        }

        /// <summary>
        /// 获取API名称：  获取每日新增团购ID列表 deal/get_daily_new_id_list
        /// 获取指定城市每日新增团购ID列表
        /// </summary>
        /// <param name="city">包含团购信息的城市名称，可选范围见相关API返回结果</param>
        /// <param name="date">查询日期，格式为“YYYY-MM-DD”</param>
        /// <param name="category">包含团购信息的分类名，支持多个category合并查询，多个category用逗号分割。可选范围见相关API返回结果</param>
        /// <returns>团购Id集合</returns>
        public Napeso.DPsdk.Entity.Deal.DealIdCollection GetDailyNewIdList(string city, string date,
            		string category = null)		

        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => city), city);
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => date), date);

                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => category), category);
            }

            return JsonConvert.DeserializeObject<Napeso.DPsdk.Entity.Deal.DealIdCollection>(Client.GetCommand(GetCommandName("get_daily_new_id_list"),
                                                                                                                             parameters));
        }

        /// <summary>
        /// 获取指定时间内卖完的团购ID列表 deal/get_sold_out_id_list
        /// 获取指定城市、指定时间内卖完的团购ID列表
        /// </summary>
        /// <param name="city">包含团购信息的城市名称，可选范围见相关API返回结果</param>
        /// <param name="begin_time">查询起始时间，格式为“YYYY-MM-DD</param>
        /// <param name="end_time">查询结束时间，格式为“YYYY-MM-DD</param>
        /// <returns>团购Id集合</returns>
        public Napeso.DPsdk.Entity.Deal.DealIdCollection GetSoldOutIdList(string city, string beginTime, string endTime)
        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => city), city);
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => beginTime), beginTime);
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => endTime), endTime);
            }

            return JsonConvert.DeserializeObject<Napeso.DPsdk.Entity.Deal.DealIdCollection>(Client.GetCommand(GetCommandName("get_sold_out_id_list"),
                                                                                                                             parameters));
        }

        /// <summary>
        /// 批量获取指定团购信息 deal/get_batch_deals_by_id
        /// 根据多个团购ID批量获取指定团购单的详细信息
        /// </summary>
        /// <param name="deal_ids">一个或多个团购ID集合，多ID之间以英文逗号分隔，如“1-120239,1-121039,1-87299”，一次传入的ID数量上限为40个，其他参数限制请参考下方注意事项</param>
        /// <returns>团购集合</returns>
        public Napeso.DPsdk.Entity.Deal.DealCollection GetBatchDealsById(string deal_ids)
        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => deal_ids), deal_ids);
            }

            return JsonConvert.DeserializeObject<Napeso.DPsdk.Entity.Deal.DealCollection>(Client.GetCommand(GetCommandName("get_batch_deals_by_id"),
                                                                                                                           parameters));
        }

        /// <summary>
        /// 获取指定团购信息 deal/get_single_deal
        /// 根据团购ID获取指定团购单的详细信息
        /// </summary>
        /// <param name="deal_id">团购ID</param>
        /// <returns>团购</returns>
        public Napeso.DPsdk.Entity.Deal.Deal GetSingleDeal(string deal_id)
        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => deal_id), deal_id);
            }

            string json = Client.GetCommand(GetCommandName("get_single_deal"), parameters);
            JObject jobj = JObject.Parse(json);

            return (jobj["count"].Value<int>() == 1)
                ? JsonConvert.DeserializeObject<Napeso.DPsdk.Entity.Deal.Deal>(jobj["deals"].Children().First().ToString())
                : null;
        }

        /// <summary>
        /// 获取指定商户的团购信息 deal/get_deals_by_business_id
        /// 根据城市和商户ID获取团购信息
        /// </summary>
        /// <param name="city">包含团购信息的城市名称，可选范围见相关API返回结果</param>
        /// <param name="business_id">商户ID</param>
        /// <returns>团购集合</returns>
        public Napeso.DPsdk.Entity.Deal.DealCollection GetDealsByBusinessId(string city, string business_id)
        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => city), city);
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => business_id), business_id);
            }

            return JsonConvert.DeserializeObject<Napeso.DPsdk.Entity.Deal.DealCollection>(Client.GetCommand(GetCommandName("get_deals_by_business_id"),
                                                                                                                           parameters));
        }

        /// <summary>
        /// 搜索团购 deal/find_deals
        /// 按照地理位置、分类、关键词等多种条件搜索团购信息，并以分页形式返回
        /// </summary>
        /// <param name="city">包含团购信息的城市名称，可选范围见相关API返回结果</param>
        /// <param name="latitude">纬度坐标，须与经度坐标同时传入</param>
        /// <param name="longitude">经度坐标，须与纬度坐标同时传入</param>
        /// <param name="radius">搜索半径，单位为米，最小值1，最大值5000，如不传入默认为1000</param>
        /// <param name="region">包含团购信息的城市区域名，可选范围见相关API返回结果（不含返回结果中包括的城市名称信息）</param>
        /// <param name="category">包含团购信息的分类名，支持多个category合并查询，多个category用逗号分割。可选范围见相关API返回结果</param>
        /// <param name="is_local">根据是否是本地单来筛选返回的团购，1:是，0:不是</param>
        /// <param name="keyword">关键词，搜索范围包括商户名、商品名、地址等</param>
        /// <param name="sort">结果排序，1:默认，2:价格低优先，3:价格高优先，4:购买人数多优先，5:最新发布优先，6:即将结束优先，7:离经纬度坐标距离近优先</param>
        /// <param name="limit">每页返回的团单结果条目数上限，最小值1，最大值40，如不传入默认为20</param>
        /// <param name="page">页码，如不传入默认为1，即第一页</param>
        /// <returns>团购集合</returns>
        public Napeso.DPsdk.Entity.Deal.DealCollection FindDeals(string city,
            		float? latitude = null,		    
            		float? longitude = null,	    
		            int? radius = null,		         
		            string region = null,		   
		            string category = null,		   
		            int? is_local = null,		   
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
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => is_local), is_local);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => keyword), keyword);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => sort), sort);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => limit), limit);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => page), page);
            }

            return JsonConvert.DeserializeObject<Napeso.DPsdk.Entity.Deal.DealCollection>(Client.GetCommand(GetCommandName("find_deals"),
                                                                                                                           parameters));
        }
    }
}
