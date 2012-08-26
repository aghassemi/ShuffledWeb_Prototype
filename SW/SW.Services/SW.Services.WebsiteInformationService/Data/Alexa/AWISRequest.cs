using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Web;
using System.IO;

namespace SW.Services.WebsiteInformationService.Data.Alexa {
	
	internal class AWISRequest {

		private string m_websiteUrl;

		private static readonly string ACTION_NAME = "UrlInfo";
		private static readonly string RESPONSE_GROUP_NAME = "RelatedLinks,Categories,Rank,ContactInfo,AdultContent,Speed,Language,Keywords,LinksInCount,SiteData";
		private static readonly string SERVICE_HOST = "awis.amazonaws.com";
		private static readonly string AWS_BASE_URL = "http://" + SERVICE_HOST + "/";
		private static readonly string HASH_ALGORITHM = "HmacSHA256";
		private static readonly string DATEFORMAT_AWS = "o";

		public AWISRequest( string websiteURL ) {
			m_websiteUrl = websiteURL;
		}

		public string Execute() {
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create( BuildQueryUrl() );
			WebResponse webResponse = request.GetResponse();
			Stream webResponseStream = webResponse.GetResponseStream();
			using ( StreamReader responseReader = new StreamReader( webResponseStream ) )
            {
                return responseReader.ReadToEnd();
            }

		}

		private string BuildQueryUrl() {
			SignedRequestHelper rh = new SignedRequestHelper(
				ConfigurationManager.AppSettings.Get("AWSAccessKey"),
				ConfigurationManager.AppSettings.Get("AWSSecretKey"),
				"/",
				SERVICE_HOST
			);
			IDictionary<string, string> qs = new Dictionary<string, string>(StringComparer.Ordinal);
			qs.Add("Action", ACTION_NAME );
			qs.Add("ResponseGroup", RESPONSE_GROUP_NAME);
			qs.Add("AWSAccessKeyId", ConfigurationManager.AppSettings.Get("AWSAccessKey"));
			qs.Add("Url", m_websiteUrl );
			qs.Add("SignatureVersion", "2");
			qs.Add("SignatureMethod", HASH_ALGORITHM);

			return rh.Sign( qs );
		}



	}
}
