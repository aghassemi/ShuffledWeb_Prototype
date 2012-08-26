using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SW.Services.WebsiteInformationService.Data.GoogleSafeBrowsing {

	internal class GSBRequest {

		private readonly string m_websiteUrl;

		private static readonly string CLIENT = "API";
		private static readonly string APP_VER = "1.0";
		private static readonly string P_VER = "3.0";
		private static readonly string GSB_BASE_URL = "https://sb-ssl.google.com/safebrowsing/api/lookup";

		public GSBRequest( string websiteUrl ) {
			m_websiteUrl = websiteUrl;
		}

		public string Execute() {

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create( BuildQueryUrl() );
			WebResponse webResponse = request.GetResponse();
			Stream webResponseStream = webResponse.GetResponseStream();
			using ( StreamReader responseReader = new StreamReader( webResponseStream ) ) {
				return responseReader.ReadToEnd();
			}
		}

		private string BuildQueryUrl() {

			string requestUrl = "{0}?client={1}&apikey={2}&appver={3}&pver={4}&url={5}";
			requestUrl = string.Format(
				requestUrl,
				GSB_BASE_URL,
				CLIENT,
				ConfigurationManager.AppSettings.Get("GoogleAPIKey"),
				APP_VER,
				P_VER,
				Utility.RfcUrlEncoder.PercentEncodeRfc3986( m_websiteUrl )
			);

			return requestUrl;
		}
	}
}
