using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Services.WebsiteInformationService.Data.GoogleSafeBrowsing {

	public interface IGoogleSafeBrowsingDataProvider {
		
		string GetRaw( string url );
	}
}
