using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SW.Foundation.Data {

	public class DatabaseServer {

		public static SqlConnection SqlConnection {
			get {
				return new SqlConnection(
						ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString
					);
			}
		}

	}
}
