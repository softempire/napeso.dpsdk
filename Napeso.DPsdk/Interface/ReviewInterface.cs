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
    public class ReviewInterface : DPInterface
    {
        public ReviewInterface(Client client)
			: base(client, "review")
		{
		}

        //*******************************************************************************************************************************************

        /// <summary>
        /// 获取指定商户最新点评片断 review/get_recent_reviews
        /// 获取指定商户的最新三条用户点评前50字片断
        /// </summary>
        /// <param name="business_id">商户ID</param>
        /// <param name="platform">传出链接类型，1:web站链接（适用于网页应用），2:HTML5站链接（适用于移动应用和联网车载应用），如不传入，默认值为1</param>
        /// <param name="limit">返回的点评条目数，最小值1，最大值3，如不传入默认为3</param>
        /// <returns>评论集合</returns>
        public Napeso.DPsdk.Entity.Review.ReviewCollection GetRecentReviews(int business_id,
            		int? platform = null,		
		            int? limit = null)	    

        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => business_id), business_id);

                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => platform), platform);
                Utility.ADD_REQUEST_OPTIONAL_PARAMETER(parameters, Utility.GetMemberName(() => limit), limit);
            }

            return JsonConvert.DeserializeObject<Napeso.DPsdk.Entity.Review.ReviewCollection>(Client.GetCommand(GetCommandName("get_recent_reviews"),
                                                                                                                               parameters));
        }
    }
}
