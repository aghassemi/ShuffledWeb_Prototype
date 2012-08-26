using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Services.WebsiteInformationService.Data.GoogleSafeBrowsing {

	public class GoogleSafeBrowsingDataProviderFactory {
		
		public IGoogleSafeBrowsingDataProvider Create() {
			return new GoogleSafeBrowsingDataProvider();
		}
	}
}
