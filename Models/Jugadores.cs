using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaMigracion.Models
{
    [Table("Jugadores")]
    public class Jugadores
	{
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string Pasaporte { get; set; }

        [Required]
        public string Direccion { get; set; }
        public bool Sexo { get; set; }

        public TablaDeEstado id_Estado { get; set; } // (Activo, Cancelado, Agente Libre)

        public Equipos Id_Equipo { get; set; }
    }
}
