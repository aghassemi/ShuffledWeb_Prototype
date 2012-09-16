using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Services.WebsiteInformationService.GoogleSafeBrowsing.Data {

	internal class GSBResultDTO {
		
		private readonly string m_id;
		private readonly bool m_malware;
		private readonly bool m_phishing;

		public GSBResultDTO(
			string id,
			bool malware,
			bool phishing
		) {
			m_id = id;
			m_malware = malware;
			m_phishing = phishing;
		}

		public string Id {
			get { return m_id; }
		}

		public bool Malware {
			get { return m_malware; }
		}

		public bool Phishing {
			get { return m_phishing; }
		} 
	}
}
