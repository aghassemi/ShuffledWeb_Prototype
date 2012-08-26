using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Services.WebsiteInformationService.Data
{
	public class WebsiteInformationDataProviderFactory {
		
		public IWebsiteInformationDataProvider Create() {
			return new Alexa.AlexaWebsiteInformationDataProvider();
		}

	}
}
