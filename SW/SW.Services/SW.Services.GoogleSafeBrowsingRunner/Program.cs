using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SW.Services.WebsiteInformationService.GoogleSafeBrowsing;

namespace SW.Services.GoogleSafeBrowsingRunner {
	class Program {

		static void Main( string[] args ) {

			GoogleSafeBrowsingManager gsbManager = new GoogleSafeBrowsingManager();

			gsbManager.UpdateNew();

			while ( true ) { }
		}
	}
}
