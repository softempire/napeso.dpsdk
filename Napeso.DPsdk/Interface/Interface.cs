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

namespace Napeso.DPsdk.Interface
{
    public abstract class DPInterface
    {
        /// <summary>
        /// 操作类
        /// </summary>
        protected Client Client;
        protected string FeatureString;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="client">操作类实例</param>
        public DPInterface(Client client, string feature)
        {
            this.Client = client;
            this.FeatureString = feature;
        }

        protected string GetCommandName(string command)
        {
            return this.FeatureString + "/" + command;
        }
    }
}
