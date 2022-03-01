using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaMigracion.ViewModels
{
	public class DetalleEquipo
	{

		public int Id { get; set; }
		public string NombreEquipo { get; set; }
		public bool Estado { get; set; }
		public List<DatosJugador> ListadoJugadores { get; set; }
		public List<DatosJugador> ListadoAgregarJugadores { get; set; }

	}
}
