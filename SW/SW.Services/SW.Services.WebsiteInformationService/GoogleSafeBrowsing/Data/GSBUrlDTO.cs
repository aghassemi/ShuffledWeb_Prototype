using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Services.WebsiteInformationService.GoogleSafeBrowsing.Data {
	
	internal class GSBUrlDTO {

		private readonly string m_id;
		private readonly string m_url;

		public GSBUrlDTO(
			string id,
			string url
		) {
			m_id = id;
			m_url = url;
		}

		public string Id {
			get { return m_id; }
		}

		public string Url {
			get { return m_url; }
		} 

	}
}
