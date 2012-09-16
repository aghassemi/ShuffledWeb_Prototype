using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SW.Services.UrlImport {

	public class AlexaUrlImporter {
		
		private readonly UrlImporter m_urlImporter;
		private readonly int? m_maxNumRecords;

		public AlexaUrlImporter( int? maxNumRecords = null ) {
			m_urlImporter = new UrlImporter();
			m_maxNumRecords = maxNumRecords;
		}

		public void ImportUrls( string csvFilePath ) {
			List<Url> urls = new List<Url>();
			int counter = 0;
			using ( StreamReader s = new StreamReader( csvFilePath ) ) {
				string line;
				while( (line = s.ReadLine()) != null ) {

					string[] parts = line.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries );
					int rank = rank = Int32.Parse( parts[0] );
					string url = parts[1].Trim();

					urls.Add( new Url( url, rank ) );

					counter++;

					if( m_maxNumRecords.HasValue && counter == m_maxNumRecords.Value ) {
						break;
					}

				}
			}

			m_urlImporter.AddUrls( urls );
		}
	}
}
