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

namespace Napeso.DPsdk.Entity.Statistics
{
    public class TransactionCollection : Napeso.DPsdk.Entity.Collection
    {
        /// <summary>
        /// 所有的交易
        /// </summary>
        [JsonProperty(PropertyName = "transactions")]
        public List<Transaction> Items { get; internal set; }
    }
}
