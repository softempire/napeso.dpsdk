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

namespace Napeso.DPsdk.Entity.Reservation
{
    public class ReservationIdCollection : Napeso.DPsdk.Entity.Collection
    {
        /// <summary>
        /// 所有的预约ID
        /// </summary>
        [JsonProperty(PropertyName = "id_list")]
        public List<int> Items { get; internal set; }
    }
}
