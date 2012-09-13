using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SW.Services.UrlImport.Data;

namespace SW.Services.UrlImport {

	public sealed class UrlImporter {

		private readonly UrlImporterDataProvider m_dp;

		public UrlImporter() {
			m_dp = new UrlImporterDataProvider();
		}
		
		public void AddUrls( IEnumerable<Url> urls ) {
			
			UrlDTO[] dtos = 
				urls.Select(
					u => 
					new UrlDTO(
						new ShortGuid().ToString(),
						u.Value,
						u.Rank
					)
				).ToArray();

			m_dp.AddUrls( dtos );
		}
	}
}
