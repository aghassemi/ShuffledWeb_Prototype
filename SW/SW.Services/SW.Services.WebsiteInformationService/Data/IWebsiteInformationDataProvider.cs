using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Services.WebsiteInformationService.Data
{
	public interface IWebsiteInformationDataProvider {

		string GetRaw( string url );

	}
}
