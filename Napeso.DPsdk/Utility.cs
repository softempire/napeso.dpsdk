/*--------------------------------------------------------------------------
* 
* Napeso.DPsdk
*
* Created and Maintained by Summer Ding (zqding@hotmail.com)
*
--------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Napeso.DPsdk
{
    internal static class Utility
    {
        /// <summary>
        /// 获取变量的名字，如 var 的名字是 "var"
        /// </summary>
        internal static string GetMemberName<T>(Expression<Func<T>> memberExpression)
        {
            MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
            return expressionBody.Member.Name;
        }

        /// <summary>
        /// 添加一个必选参数
        /// </summary>
        /// <param name="parameters">参数列表</param>
        /// <param name="paramName">参数名</param>
        /// <param name="paramValue">参数值</param>
        internal static void ADD_REQUEST_PARAMETER(List<Parameter> parameters, string paramName, object paramValue)
        {
            parameters.Add(new Parameter(paramName, paramValue));
        }

        /// <summary>
        /// 添加一个可选参数。
        /// </summary>
        /// <param name="parameters">参数列表</param>
        /// <param name="paramName">参数名</param>
        /// <param name="paramValue">参数值</param>
        internal static void ADD_REQUEST_OPTIONAL_PARAMETER(List<Parameter> parameters, string paramName, object paramValue)
        {
            if (paramValue != null)
            {
                parameters.Add(new Parameter(paramName, paramValue));
            }
        }
    }
}
