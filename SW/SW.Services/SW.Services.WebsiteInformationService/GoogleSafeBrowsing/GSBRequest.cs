using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SW.Services.WebsiteInformationService.GoogleSafeBrowsing {

	internal class GSBRequest {

		private readonly string m_websiteUrl;

		private static readonly string CLIENT = "API";
		private static readonly string APP_VER = "1.0";
		private static readonly string P_VER = "3.0";
		private static readonly string GSB_BASE_URL = "https://sb-ssl.google.com/safebrowsing/api/lookup";

		public GSBRequest( string websiteUrl ) {
			m_websiteUrl = websiteUrl;
		}

		public GSBResultType Execute() {

			GSBResultType result = GSBResultType.Unknown;
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create( BuildQueryUrl() );
			try {
				HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
				Stream webResponseStream = webResponse.GetResponseStream();

				if ( webResponse.StatusCode == HttpStatusCode.NoContent ) {
					result = GSBResultType.Safe;
				} else if ( webResponse.StatusCode == HttpStatusCode.OK ) {
					string response;
					using ( StreamReader responseReader = new StreamReader( webResponseStream ) ) {
						response = responseReader.ReadToEnd();
					}

					switch ( response.ToLowerInvariant() ) {
						case "malware":
							result = GSBResultType.Malware;
							break;
						case "phishing":
							result = GSBResultType.Phishing;
							break;
						case "phishing,malware":
							result = GSBResultType.BothPhishingAndMalware;
							break;
					}
				}

			} catch( WebException e ) {
				if ( ((HttpWebResponse)e.Response).StatusCode == HttpStatusCode.Forbidden ) {
					throw new GSBBackOffException();
				} else {
					throw;
				}
			}

			return result;
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
