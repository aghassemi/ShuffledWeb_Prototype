using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Services.WebsiteInformationService.GoogleSafeBrowsing {

	internal enum GSBResultType {
		Safe,
		Malware,
		Phishing,
		BothPhishingAndMalware,
		Unknown
	}
}
