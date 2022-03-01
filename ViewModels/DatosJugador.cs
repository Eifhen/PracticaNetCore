using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaMigracion.ViewModels
{
	public class DatosJugador
	{

		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Sexo { get; set; }

		public DateTime FechaNacimiento { get; set; }
		public string Pasaporte { get; set; }
		public string Direccion { get; set; }

		public string Estado { get; set; } // activo, agente libre, cancelado

		public string NombreEquipo { get; set; }


	}
}
