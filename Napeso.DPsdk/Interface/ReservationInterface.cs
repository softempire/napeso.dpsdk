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

namespace Napeso.DPsdk.Interface
{
    public class ReservationInterface : Napeso.DPsdk.Interface.DPInterface
    {
        public ReservationInterface(Client client)
            : base(client, "reservation")
        {
        }

        //*************************************************************************************************************************************************

        /// <summary>
        /// 获取支持在线预订的全部商户ID列表 reservation/get_all_id_list
        /// 获取指定城市支持在线预订的全部商户ID列表
        /// </summary>
        /// <param name="city">包含团购信息的城市名称，可选范围见相关API返回结果</param>
        /// <returns>预订Id集合</returns>
        public Napeso.DPsdk.Entity.Reservation.ReservationIdCollection GetAllIdList(string city)
        {
            List<Parameter> parameters = new List<Parameter>();
            {
                Utility.ADD_REQUEST_PARAMETER(parameters, Utility.GetMemberName(() => city), city);
            }

            return JsonConvert.DeserializeObject<Napeso.DPsdk.Entity.Reservation.ReservationIdCollection>(Client.GetCommand(GetCommandName("get_all_id_list"),
                                                                                                                                           parameters));
        }
    }
}
