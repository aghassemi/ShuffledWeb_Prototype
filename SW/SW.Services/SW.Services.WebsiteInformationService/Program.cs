using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SW.Services.WebsiteInformationService.Data;

namespace SW.Services.WebsiteInformationService
{
	class Program
	{
		public static void Main(string[] args)
		{
			WebsiteInformationDataProviderFactory factory = new WebsiteInformationDataProviderFactory();
			IWebsiteInformationDataProvider dp = factory.Create();

			string site = "yahoo.com";
			Console.Write(  dp.GetRaw( site ) );

			while( true ){}
		}


	}
}