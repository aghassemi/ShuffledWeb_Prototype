using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Services.WebsiteInformationService.Data.GoogleSafeBrowsing {

	internal class GoogleSafeBrowsingDataProvider : IGoogleSafeBrowsingDataProvider {

		string IGoogleSafeBrowsingDataProvider.GetRaw( string url ) {
			
			GSBRequest request = new GSBRequest( url );
			return request.Execute();
		}
	}
}
