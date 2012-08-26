using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Services.WebsiteInformationService.Data.Alexa {

	public interface IAlexaWebsiteInformationDataProvider {
		string GetRaw( string url );
	}
}
