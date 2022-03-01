using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaMigracion.Procesos
{
	public class Paises
	{
		//          [ 0 ]                    [ 1 ]       [ 2 ]           [ 3 ]         [ 4 ]
		// English short name lower case, Alpha-2 code, Alpha-3 code, Numeric code, ISO 3166-2

		public string EnglishShortName { get; set; } // [ 0 ]

		public string Alpha3Code { get; set; } // [ 2 ] 
	}
}
