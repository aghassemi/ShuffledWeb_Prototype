using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SW.Services.WebsiteInformationService.GoogleSafeBrowsing.Data;

namespace SW.Services.WebsiteInformationService.GoogleSafeBrowsing {
	
	public class GoogleSafeBrowsingManager {

		private readonly GoogleSafeBrowsingDataProvider m_dp;

		public GoogleSafeBrowsingManager() {
			m_dp = new GoogleSafeBrowsingDataProvider();
		}
		
		public void UpdateAll( DateTime? after = null ) {
			this.Update( m_dp.Get( after ) );
		}

		public void UpdateNew() {
			this.Update( m_dp.GetNew() );
		}

		private void Update( IEnumerable<GSBUrlDTO> dtos ) {
			
			foreach( GSBUrlDTO dto in dtos ) {

				GSBResultType gsbResultType = GSBResultType.Unknown;
				try {
					gsbResultType = new GSBRequest( dto.Url ).Execute();
				} catch( GSBBackOffException e ) {
						
					// Backoff for 2 hours
					var backOffTime = 2 * 60 * 60 * 1000;
					System.Threading.Thread.Sleep( backOffTime );
				}
				if( gsbResultType != GSBResultType.Unknown ) {
					GSBResultDTO gsbResultDTO = new GSBResultDTO(
						dto.Id,
						gsbResultType == GSBResultType.Malware || gsbResultType == GSBResultType.BothPhishingAndMalware,
						gsbResultType == GSBResultType.Phishing || gsbResultType == GSBResultType.BothPhishingAndMalware
					);

					m_dp.Update(
						gsbResultDTO
					);
				} else {
					//TODO: Log
				}

			} 
		}

	}
}
