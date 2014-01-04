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
using Napeso.DPsdk;
using Napeso.DPsdk.Entity.Metadata;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Napeso.DPsdk.Interface
{
    public class MetadataInterface : DPInterface
    {
        public MetadataInterface(Client client)
			: base(client, "metadata")
		{
		}

        //*******************************************************************************************************************************************

        /// <summary>
        /// 获取支持商户搜索的最新城市列表 metadata/get_cities_with_businesses
        /// 获取支持商户搜索的最新城市列表
        /// </summary>
        /// <returns>城市名称列表</returns>
        public List<string> GetCityNamesWithBusinesses()
        {
            List<Parameter> parameters = new List<Parameter>();
            {
            }

            string json = Client.GetCommand(GetCommandName("get_cities_with_businesses"), parameters);
            JObject jobj = JObject.Parse(json);

            return jobj["cities"].Children().Values<string>().ToList();
        }

        /// <summary>
        /// 获取支持商户搜索的最新城市下属区域列表 metadata/get_regions_with_businesses
        /// 获取支持商户搜索的最新城市下属区域列表
        /// </summary>
        /// <param name="city">城市名称，可选范围见相关API返回结果</param>
        /// <returns>城市列表</returns>
        public List<Napeso.DPsdk.Entity.Metadata.City> GetCitiesWithBusinesses(
            		string city = null)		    
        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => city), city);
            }

            string json = Client.GetCommand(GetCommandName("get_regions_with_businesses"), parameters);
            JObject jobj = JObject.Parse(json);

            List<Napeso.DPsdk.Entity.Metadata.City> cities = new List<City>();
            foreach (var c in jobj["cities"].Children())
            {
                cities.Add(JsonConvert.DeserializeObject<City>(c.ToString()));
            }
      
            return cities;
        }

        /// <summary>
        /// 获取支持商户搜索的最新城市下属区域列表 metadata/get_regions_with_businesses
        /// 获取支持商户搜索的最新城市下属区域列表
        /// </summary>
        /// <param name="city">城市名称，可选范围见相关API返回结果</param>
        /// <returns>城市</returns>
        public Napeso.DPsdk.Entity.Metadata.City GetSingleCityWithBusinesses(string city)
        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => city), city);
            }

            string json = Client.GetCommand(GetCommandName("get_regions_with_businesses"), parameters);
            JObject jobj = JObject.Parse(json);
            JEnumerable<JToken> cities = jobj["cities"].Children();

            return cities.Count() == 1 ? JsonConvert.DeserializeObject<City>(cities.First().ToString()) : null;
        }

        /// <summary>
        /// 获取支持商户搜索的最新分类列表 metadata/get_categories_with_businesses
        /// 获取支持商户搜索的最新分类列表
        /// </summary>
        /// <param name="city">城市名称，可选范围见相关API返回结果</param>
        /// <returns>分类列表</returns>
        public List<Napeso.DPsdk.Entity.Metadata.Category> GetCategoriesWithBusinesses(string city)
        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => city), city);
            }

            string json = Client.GetCommand(GetCommandName("get_categories_with_businesses"), parameters);
            JObject jobj = JObject.Parse(json);

            List<Napeso.DPsdk.Entity.Metadata.Category> categories = new List<Category>();
            foreach (var c in jobj["categories"].Children())
            {
                categories.Add(JsonConvert.DeserializeObject<Category>(c.ToString()));
            }

            return categories;
        }

        //********************************************************************************************************

        /// <summary>
        /// 获取支持团购搜索的最新城市列表 metadata/get_cities_with_deals
        /// 获取支持团购搜索的最新城市列表
        /// </summary>
        /// <returns>城市名称列表</returns>
        public List<string> GetCityNamesWithDeals()
        {
            List<Parameter> parameters = new List<Parameter>();
            {
            }

            string json = Client.GetCommand(GetCommandName("get_cities_with_deals"), parameters);
            JObject jobj = JObject.Parse(json);

            return jobj["cities"].Children().Values<string>().ToList();
        }

        /// <summary>
        /// 获取支持团购搜索的最新城市下属区域列表 metadata/get_regions_with_deals
        /// 获取支持团购搜索的最新城市下属区域列表
        /// </summary>
        /// <param name="city">城市名称，可选范围见相关API返回结果</param>
        /// <returns>城市列表</returns>
        public List<Napeso.DPsdk.Entity.Metadata.City> GetCitiesWithDeals(
                    string city = null)		    
        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => city), city);
            }

            string json = Client.GetCommand(GetCommandName("get_regions_with_deals"), parameters);
            JObject jobj = JObject.Parse(json);

            List<Napeso.DPsdk.Entity.Metadata.City> cities = new List<City>();
            foreach (var c in jobj["cities"].Children())
            {
                cities.Add(JsonConvert.DeserializeObject<City>(c.ToString()));
            }
      
            return cities;
        }

        /// <summary>
        /// 获取支持团购搜索的最新城市下属区域列表 metadata/get_regions_with_deals
        /// 获取支持团购搜索的最新城市下属区域列表
        /// </summary>
        /// <param name="city">城市名称，可选范围见相关API返回结果</param>
        /// <returns>城市</returns>
        public Napeso.DPsdk.Entity.Metadata.City GetSingleCityWithDeals(string city)
        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => city), city);
            }

            string json = Client.GetCommand(GetCommandName("get_regions_with_deals"), parameters);

            JObject jobj = JObject.Parse(json);
            JEnumerable<JToken> cities = jobj["cities"].Children();

            return cities.Count() == 1 ? JsonConvert.DeserializeObject<City>(cities.First().ToString()) : null;
        }

        /// <summary>
        /// 获取支持团购搜索的最新分类列表 metadata/get_categories_with_deals
        /// 获取支持团购搜索的最新分类列表
        /// </summary>
        /// <returns>子分类列表</returns>
        public List<Napeso.DPsdk.Entity.Metadata.SubCategory> GetCategoriesWithDeals()
        {
            List<Parameter> parameters = new List<Parameter>();
            {
            }

            string json = Client.GetCommand(GetCommandName("get_categories_with_deals"), parameters);
            JObject jobj = JObject.Parse(json);

            List<Napeso.DPsdk.Entity.Metadata.SubCategory> categories = new List<SubCategory>();
            foreach (var c in jobj["categories"].Children())
            {
                categories.Add(JsonConvert.DeserializeObject<SubCategory>(c.ToString()));
            }

            return categories;
        }

        //********************************************************************************************************

        /// <summary>
        /// 获取支持优惠券搜索的最新城市列表 metadata/get_cities_with_coupons
        /// 获取支持优惠券搜索的最新城市列表
        /// </summary>
        /// <returns>城市名称列表</returns>
        public List<string> GetCityNamesWithCoupons()
        {
            List<Parameter> parameters = new List<Parameter>();
            {
            }

            string json = Client.GetCommand(GetCommandName("get_cities_with_coupons"), parameters);
            JObject jobj = JObject.Parse(json);

            return jobj["cities"].Children().Values<string>().ToList();
        }

        /// <summary>
        /// 获取支持优惠券搜索的最新城市下属区域列表 metadata/get_regions_with_coupons
        /// 获取支持优惠券搜索的最新城市下属区域列表
        /// </summary>
        /// <param name="city">城市名称，可选范围见相关API返回结果</param>
        /// <returns>城市列表</returns>
        public List<Napeso.DPsdk.Entity.Metadata.City> GetCitiesWithCoupons(
                    string city = null)
        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => city), city);
            }

            string json = Client.GetCommand(GetCommandName("get_regions_with_coupons"), parameters);
            JObject jobj = JObject.Parse(json);

            List<Napeso.DPsdk.Entity.Metadata.City> cities = new List<City>();
            foreach (var c in jobj["cities"].Children())
            {
                cities.Add(JsonConvert.DeserializeObject<City>(c.ToString()));
            }

            return cities;
        }

        /// <summary>
        /// 获取支持优惠券搜索的最新城市下属区域列表 metadata/get_regions_with_coupons
        /// 获取支持优惠券搜索的最新城市下属区域列表
        /// </summary>
        /// <param name="city">城市名称，可选范围见相关API返回结果</param>
        /// <returns>城市</returns>
        public Napeso.DPsdk.Entity.Metadata.City GetSingleCityWithCoupons(string city)
        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => city), city);
            }

            string json = Client.GetCommand(GetCommandName("get_regions_with_coupons"), parameters);

            JObject jobj = JObject.Parse(json);
            JEnumerable<JToken> cities = jobj["cities"].Children();

            return cities.Count() == 1 ? JsonConvert.DeserializeObject<City>(cities.First().ToString()) : null;
        }

        /// <summary>
        /// 获取支持优惠券搜索的最新分类列表 metadata/get_categories_with_coupons
        /// 获取支持优惠券搜索的最新分类列表
        /// </summary>
        /// <returns>分类名称列表</returns>
        public List<string> GetCategoriesWithCoupons()
        {
            List<Parameter> parameters = new List<Parameter>();
            {
            }

            string json = Client.GetCommand(GetCommandName("get_categories_with_coupons"), parameters);
            JObject jobj = JObject.Parse(json);

            return JsonConvert.DeserializeObject<List<string>>(jobj["categories"].ToString());
        }

        //********************************************************************************************************

        /// <summary>
        /// 获取支持在线预订的最新城市列表 metadata/get_cities_with_online_reservations
        /// 获取支持在线预订的最新城市列表
        /// </summary>
        /// <returns>城市名称列表</returns>
        public List<string> GetCityNamesWithOnlineReservations()
        {
            List<Parameter> parameters = new List<Parameter>();
            {
            }

            string json = Client.GetCommand(GetCommandName("get_cities_with_online_reservations"), parameters);
            JObject jobj = JObject.Parse(json);

            return jobj["cities"].Children().Values<string>().ToList();
        }
    }
}
