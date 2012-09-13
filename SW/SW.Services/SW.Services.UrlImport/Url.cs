using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SW.Services.UrlImport {

	public sealed class Url {

		private readonly string m_value;
		private int? m_rank;

		public Url(
			string value,
			int? rank
		) {
			m_value = value;
			m_rank = rank;
		}

		public string Value {
			get { return m_value; }
		}

		public int? Rank {
			get { return m_rank; }
			set { m_rank = value; }
		}

	}
}
