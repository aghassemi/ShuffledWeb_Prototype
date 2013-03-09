using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SW.Services.WebsiteInformationService.GoogleSafeBrowsing.Data {

	internal class GoogleSafeBrowsingDataProvider  {


		public void Update( GSBResultDTO result ) {

			SqlConnection conn = SW.Foundation.Data.DatabaseServer.SqlConnection;

			SqlCommand cmd = new SqlCommand( "s_URLS_GOOGLE_SAFE_BROWSING_Add", conn );
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue( "@Id", result.Id );
			cmd.Parameters.AddWithValue( "@Malware", result.Malware );
			cmd.Parameters.AddWithValue( "@Phishing", result.Phishing );
			conn.Open();
			cmd.ExecuteNonQuery();
			conn.Close();
		}

		public IEnumerable<GSBUrlDTO> GetNew() {

			SqlConnection conn = SW.Foundation.Data.DatabaseServer.SqlConnection;

			SqlCommand cmd = new SqlCommand( "s_URLS_GOOGLE_SAFE_BROWSING_GetNew", conn );
			cmd.CommandType = CommandType.StoredProcedure;
			List<GSBUrlDTO> result = new List<GSBUrlDTO>();
			return GetUrlDTOResult( cmd );
		}

		public IEnumerable<GSBUrlDTO> Get( DateTime? after = null ) {
			
			SqlConnection conn = SW.Foundation.Data.DatabaseServer.SqlConnection;

			SqlCommand cmd = new SqlCommand( "s_URLS_GOOGLE_SAFE_BROWSING_Get", conn );
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue( "@After", after );
			return GetUrlDTOResult( cmd );
		}

		private List<GSBUrlDTO> GetUrlDTOResult( SqlCommand cmd ) {
			
			List<GSBUrlDTO> result = new List<GSBUrlDTO>();
			cmd.Connection.Open();
			using ( SqlDataReader reader = cmd.ExecuteReader() ) {
				while ( reader.Read() ) {
					result.Add(
						new GSBUrlDTO(
							reader["Id"].ToString(),
							reader["Url"].ToString()
						)
					);
				}
			}
			cmd.Connection.Close();
			return result;
		} 
	}
}
