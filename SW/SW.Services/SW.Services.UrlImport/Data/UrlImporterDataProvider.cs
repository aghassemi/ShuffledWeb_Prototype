using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SW.Services.UrlImport.Data {

	internal sealed class UrlImporterDataProvider {

		public void AddUrls( UrlDTO[] urls ) {
			
			SqlConnection conn = SW.Foundation.Data.DatabaseServer.SqlConnection;

			foreach( UrlDTO urlDTO in urls ) {

				SqlCommand cmd = new SqlCommand( "s_URLS_Add", conn );
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue( "@Id", urlDTO.Id );
				cmd.Parameters.AddWithValue( "@Url", urlDTO.Url );
				cmd.Parameters.AddWithValue( "@Rank", urlDTO.Rank );
				conn.Open();
				cmd.ExecuteNonQuery();
				conn.Close();

			};

		}
	}
}
