using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SW.Services.WebsiteInformationService.Utility {

	public class RfcUrlEncoder {

		/*
		 * Percent-encode (URL Encode) according to RFC 3986 as required by Amazon.
		 * 
		 * This is necessary because .NET's HttpUtility.UrlEncode does not encode
		 * according to the above standard. Also, .NET returns lower-case encoding
		 * by default and Amazon requires upper-case encoding.
		 */
		public static string PercentEncodeRfc3986( string str ) {
			str = HttpUtility.UrlEncode( str, System.Text.Encoding.UTF8 );
			str = str.Replace( "'", "%27" ).Replace( "(", "%28" ).Replace( ")", "%29" ).Replace( "*", "%2A" ).Replace( "!", "%21" ).Replace( "%7e", "~" ).Replace( "+", "%20" );

			StringBuilder sbuilder = new StringBuilder( str );
			for ( int i = 0; i < sbuilder.Length; i++ ) {
				if ( sbuilder[i] == '%' ) {
					if ( Char.IsLetter( sbuilder[i + 1] ) || Char.IsLetter( sbuilder[i + 2] ) ) {
						sbuilder[i + 1] = Char.ToUpper( sbuilder[i + 1] );
						sbuilder[i + 2] = Char.ToUpper( sbuilder[i + 2] );
					}
				}
			}
			return sbuilder.ToString();
		}
	}
}
