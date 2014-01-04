/*--------------------------------------------------------------------------
* 
* Napeso.DPsdk
*
* Created and Maintained by Summer Ding (zqding@hotmail.com)
*
--------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Napeso.DPsdk
{
	[Serializable]
	public class DPException : System.Net.WebException
	{
		/// <summary>
		/// 错误代码
		/// </summary>
		public string ErrorCode
		{
			get;
			private set;
		}


		/// <summary>
		/// 错误信息
		/// </summary>
		public string ErrorMessage
		{
			get;
			private set;
		}


		/// <summary>
		/// 错误状态
		/// </summary>
		public string ErrorStatus
		{
			get;
			private set;
		}


		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="message"></param>
		/// <param name="inner"></param>
		public DPException(string message, System.Net.WebException inner)
			: base(message, inner)
		{

		}

        public DPException(string code, string errorMessage)
			: base(errorMessage)
		{ 
			ErrorCode = code;
		    ErrorMessage = errorMessage;
		}

    	/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected DPException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context)
			: base(info, context)
		{

		}

        private static string GetErrorMsg(string errorCode)
		{
            //http://developer.dianping.com/ API文档->错误码
			Dictionary<string, string> ErrorMsgBag = new Dictionary<string, string>
			{
                {"10001","Request time out. (请求超时)"},
                {"10002","Appkey is missing. (无appkey参数)"},
                {"10003","Invalid appkey. (appkey参数值无效)"},
                {"10004","Sign is missing. (无sign签名参数)"},
                {"10005","Invalid sign. (sign签名参数值无效)"},
                {"10006","This API is not accessible. (无当前API访问权限)"},
                {"10007","You have reached the daily limit. (当日API访问量已达到上限)"},
                {"10008","Appkey is unavailable. (appkey不可用)"},
                {"10009","API does not exist. (API地址不存在)"},
                {"10010","Required parameter is missing. (缺少必选请求参数)"},
                {"10011","Parameter value is invalid. (请求参数值无效)"},
                {"10012","Parameter is invalid. (请求参数无效)"},
                {"10013","Parameters set is invalid. (请求参数组合无效)"},
                {"10014","IP is invalid. (请求IP无效)"},
                {"10015","Error method. (请求方法错误)"},
                {"10016","Access forbidden. (禁止访问)"},
                {"10017","You have exceeded the allowed frequency. (访问过于频繁)"},
                {"10018","Invalid Request.(无效请求)"},
                {"100","API service is temporarily unavailable. (API服务器繁忙)"},
                {"101","API service timeout. (API服务调用超时)"},
                {"10019","Invalid request-header: {0}. (HTTP Header {0} 无效)"},
                {"10020","Request contains invalid UTF-8 characters. (HTTP请求包含非UTF-8编码字符: {0})"},
                {"10021","Parameter contains more than {1} items: {0}. (请求参数值数量超过{1}上限: {0})"},
                {"10022","Parameter contains less than {1} items: {0}. (请求参数值数量不足{1}: {0})"},
                {"10023","Parameter value format invalid: {0} (请求参数值格式错误: {0})"}
			};

		    if (ErrorMsgBag.ContainsKey(errorCode))
		    {
		        return ErrorMsgBag[errorCode];
		    }
		    else
		    {
		        return "未知错误";
		    }
		}
	}
}
