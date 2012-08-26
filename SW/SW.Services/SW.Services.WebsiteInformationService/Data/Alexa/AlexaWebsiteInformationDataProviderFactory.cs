using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Services.WebsiteInformationService.Data.Alexa {

	public class AlexaWebsiteInformationDataProviderFactory {

		public IAlexaWebsiteInformationDataProvider Create() {
			return new AlexaWebsiteInformationDataProvider();
		}

	}
}
