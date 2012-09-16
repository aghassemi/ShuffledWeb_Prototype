using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SW.Services.UrlImport;

namespace SW.Services.AlexaUrlImportRunner {
	class Program {
		static void Main( string[] args ) {

			if( args.Length != 1 ) {
				Console.Write("Usage: AlexaUrlImporter.exe <path> <optional number of records to load");
				return;
			}

			string csvPath = args[0];
			int maxNumRecords = 300000;
			if( args.Length >= 2 ) {
				maxNumRecords = Int32.Parse( args[1] );
			}

			AlexaUrlImporter importer = new AlexaUrlImporter( maxNumRecords );
			importer.ImportUrls( csvPath );
			
		}
	}
}
