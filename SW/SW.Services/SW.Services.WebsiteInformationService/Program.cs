using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SW.Services.WebsiteInformationService.Data.Alexa;
using SW.Services.WebsiteInformationService.GoogleSafeBrowsing;

namespace SW.Services.WebsiteInformationService
{
	class Program
	{
		public static void Main(string[] args)
		{

			//IAlexaWebsiteInformationDataProvider alexadp = new AlexaWebsiteInformationDataProviderFactory().Create();
		
			//string site = "unicef.org";
			//Console.Write( alexadp.GetRaw( site ) );
			//Console.Write( "-------------------------\n" );
			//Console.Write( gsbdp.GetRaw( site ) );

			GoogleSafeBrowsing.GoogleSafeBrowsingManager gsbManager = new GoogleSafeBrowsing.GoogleSafeBrowsingManager();

			gsbManager.UpdateNew();

			while( true ){}
		}


	}
}