/*--------------------------------------------------------------------------
* 
* Napeso.DPsdk
*
* Created and Maintained by Summer Ding (zqding@hotmail.com)
*
--------------------------------------------------------------------------*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Napeso.DPsdk.Interface;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Napeso.DPsdk
{
	public class Client
	{
		const string BASE_URL = "http://api.dianping.com/v1/";

	    private string mAppKey = null;
	    private string mAppSecrect = null;

	    public Client(string appkey, string appSecret)
	    {
	        mAppKey = appkey;
	        mAppSecrect = appSecret;
	    }

		/// <summary>
		/// 用GET方式发送命令
		/// </summary>
        /// <param name="command">命令。命令例如：business/find_businesses http://developer.dianping.com/app/api。</param>
		/// <param name="parameters">参数表</param>
		/// <returns></returns>
		public string GetCommand(string command, params Parameter[] parameters)
		{
			return Request(command, parameters);
		}

        /// <summary>
        /// 用GET方式发送命令
        /// </summary>
        /// <param name="command">命令。命令例如：business/find_businesses http://developer.dianping.com/app/api。</param>
        /// <param name="parameters">参数表</param>
        /// <returns></returns>
        public string GetCommand(string command, List<Parameter> parameters)
        {
            return Request(command, parameters.ToArray());
        }

        /// <summary>
        /// URL请求参数UTF8编码
        /// </summary>
        /// <param name="value">源字符串</param>
        /// <returns>编码后的字符串</returns> 
        private string Utf8Encode(string value)
        {
            return HttpUtility.UrlEncode(value, System.Text.Encoding.UTF8).ToLower();
        }

        /// <summary>
        /// SHA1加密字符串
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <returns>加密后的字符串</returns> 
        public string SHA1(string source)
        {
            byte[] value = Encoding.UTF8.GetBytes(source);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(value);

            string delimitedHexHash = BitConverter.ToString(result);
            string hexHash = delimitedHexHash.Replace("-", "");

            return hexHash;
        }

        private string BuildQueryString(Hashtable parameters)
        {
            //参数按照参数名排序
            ArrayList aKeys = new ArrayList(parameters.Keys);
            aKeys.Sort();

            //拼接字符串
            string value = "";
            string queryString = "";
            foreach (string skey in aKeys)
            {
                value += (skey + parameters[skey]);
                queryString += string.Format("&{0}={1}", skey, Utf8Encode(parameters[skey].ToString()));
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(mAppKey);
            sb.Append(value);
            sb.Append(mAppSecrect);
            value = sb.ToString();

            return string.Format("?appkey={0}&sign={1}", mAppKey, SHA1(value)) + queryString;
        }

        private string BuildQueryString(params Parameter[] parameters)
        {
            //准备参数
            Hashtable ht = new Hashtable();
            foreach (var param in parameters)
            {
                ht.Add(param.Name, param.Value.ToString());
            }

            return BuildQueryString(ht);
        }

	    private string BuildQueryString(IEnumerable<Parameter> parameters)
	    {
            //准备参数
            Hashtable ht = new Hashtable();
            foreach (var param in parameters)
            {
                ht.Add(param.Name, param.Value.ToString());
            }

            return BuildQueryString(ht);
	    }

        private string Request(string command, params Parameter[] parameters)
        {
            Debug.Assert(!string.IsNullOrEmpty(command));

            string url = string.Format("{0}{1}{2}", BASE_URL, command, this.BuildQueryString(parameters));

            string resultJson = null;
            HttpWebResponse response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                response = (HttpWebResponse)request.GetResponse();
                Encoding responseEncoding = Encoding.GetEncoding(response.CharacterSet);
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), responseEncoding))
                {
                    resultJson = sr.ReadToEnd();
                }
            }
            catch (WebException webEx)
            {
                if (webEx.Response != null)
                {
                    using (StreamReader reader = new StreamReader(webEx.Response.GetResponseStream()))
                    {
                        string errorInfo = reader.ReadToEnd();
                        reader.Close();

                        Napeso.DPsdk.Error error = Error.Deserialize(errorInfo);
                        throw new DPException(error.ErrorCode.ToString(), error.ErrorMessage);
                    }
                }
                else
                {
                    throw new DPException(((HttpWebResponse)webEx.Response).StatusCode.ToString(),
                                          webEx.ToString());
                }
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }

            Napeso.DPsdk.DPStatus status = DPStatus.Deserialize(resultJson);
            if (!status.IsValid)
            {
                string errorInfo = resultJson;
                Napeso.DPsdk.Error error = Error.Deserialize(errorInfo);

                throw new DPException(error.ErrorCode.ToString(), error.ErrorMessage);
            }

            return resultJson;
        }

        public Napeso.DPsdk.Interface.BusinessInterface Business
        {
            get
            {
                return new Napeso.DPsdk.Interface.BusinessInterface(this);
            }
        }

	    private Napeso.DPsdk.Interface.DealInterface _dealInterface = null;
        public Napeso.DPsdk.Interface.DealInterface Deal
        {
            get
            {
                if (_dealInterface == null)
                {
                    _dealInterface = new Napeso.DPsdk.Interface.DealInterface(this);
                }

                return _dealInterface;
            }
        }

        private Napeso.DPsdk.Interface.CouponInterface _couponInterface = null;
        public Napeso.DPsdk.Interface.CouponInterface Coupon
        {
            get
            {
                if (_couponInterface == null)
                {
                    _couponInterface = new Napeso.DPsdk.Interface.CouponInterface(this);
                }

                return _couponInterface;
            }
        }

        private Napeso.DPsdk.Interface.ReservationInterface _reservationInterface = null;
        public Napeso.DPsdk.Interface.ReservationInterface Reservation
        {
            get
            {
                if (_reservationInterface == null)
                {
                    _reservationInterface = new Napeso.DPsdk.Interface.ReservationInterface(this);
                }

                return _reservationInterface;
            }
        }

        private Napeso.DPsdk.Interface.ReviewInterface _reviewInterface = null;
        public Napeso.DPsdk.Interface.ReviewInterface Review
        {
            get
            {
                if (_reviewInterface == null)
                {
                    _reviewInterface = new Napeso.DPsdk.Interface.ReviewInterface(this);
                }

                return _reviewInterface;
            }
        }

        private Napeso.DPsdk.Interface.MetadataInterface _metadataInterface = null;
        public Napeso.DPsdk.Interface.MetadataInterface Metadata
        {
            get
            {
                if (_metadataInterface == null)
                {
                    _metadataInterface = new Napeso.DPsdk.Interface.MetadataInterface(this);
                }

                return _metadataInterface;
            }
        }

        private Napeso.DPsdk.Interface.StatisticsInterface _statisticsInterface = null;
        public Napeso.DPsdk.Interface.StatisticsInterface Statistics
        {
            get
            {
                if (_statisticsInterface == null)
                {
                    _statisticsInterface = new Napeso.DPsdk.Interface.StatisticsInterface(this);
                }

                return _statisticsInterface;
            }
        }
	}
}
