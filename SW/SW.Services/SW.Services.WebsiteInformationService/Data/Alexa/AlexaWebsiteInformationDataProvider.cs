using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Services.WebsiteInformationService.Data.Alexa
{
	internal class AlexaWebsiteInformationDataProvider : IAlexaWebsiteInformationDataProvider {

		public AlexaWebsiteInformationDataProvider() {
			
		}

		string IAlexaWebsiteInformationDataProvider.GetRaw( string url ) {
			AWISRequest request = new AWISRequest( url );
			return request.Execute();
		}
	}
}
