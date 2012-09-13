using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Services.UrlImport.Data {

	public sealed class UrlDTO {

		private readonly string m_id;
		private readonly string m_url;
		private int? m_rank;

		public UrlDTO(
			string id,
			string url,
			int? rank 
		) {
			
			m_id = id;
			m_url = url;
			m_rank = rank;

		}

		public string Id {
			get { return m_id; }
		}

		public string Url {
			get { return m_url; }
		}

		public int? Rank {
			get { return m_rank; }
			set { m_rank = value; }
		}

	}
}
