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

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Napeso.DPsdk.Interface
{
    public class StatisticsInterface : DPInterface
    {
        public StatisticsInterface(Client client)
            : base(client, "stats")
        {
        }

        //*******************************************************************************************************************************************

        /// <summary>
        /// 获取应用导入的团购交易的历史记录 stats/get_deal_transaction_history
        /// 获取指定时间段内开发者应用导入的团购交易的历史记录
        /// </summary>
        /// <param name="begin_time">查询起始日期，格式为“YYYY-MM-DD</param>
        /// <param name="end_time">查询结束日期，格式为“YYYY-MM-DD</param>
        /// <param name="transaction_status">交易状态，1:用户下单，2:用户付费，3:退款，4:验券</param>
        /// <param name="city">包含团购信息的城市名称，可以按城市为单位过滤结果，可选范围见相关API返回结果</param>
        /// <param name="deal_id">团购ID，可以按单个团购为单位过滤结果</param>
        /// <param name="uid">合作方在链接后加上的明文传输的自定义参数,使用方法如：注意事项．</param>
        /// <param name="limit">每页返回的记录条目数上限，最小值1，最大值40，如不传入默认为40</param>
        /// <param name="page">页码，如不传入默认为1，即第一页</param>
        /// <returns>交易集合</returns>
        public Napeso.DPsdk.Entity.Statistics.TransactionCollection GetDealTransactionHistory(string begin_time, string end_time, int transaction_status,
            		string city = null, 		    
            		string deal_id = null,		  
		            string uid = null,		       
		            int? limit = null,		        
		            int? page = null)		        
        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => begin_time), begin_time);
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => end_time), end_time);
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => transaction_status), transaction_status);

                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => city), city);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => deal_id), deal_id);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => uid), uid);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => limit), limit);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => page), page);
            }

            return JsonConvert.DeserializeObject<Napeso.DPsdk.Entity.Statistics.TransactionCollection>(Client.GetCommand(GetCommandName("get_deal_transaction_history"), 
                                                                                                                                   parameters));
        }
    }
}
