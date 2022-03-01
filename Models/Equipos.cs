using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaMigracion.Models
{
    [Table("Equipos")]
    public class Equipos
	{
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Pais { get; set; } // (Codigo de 3 digitos ISO3) (Dropdown)

        public bool Estado { get; set; }

        public DateTime FechaDeCreacion { get; set; }

        //
        public List<Jugadores> Jugadores { get; set; }
    }
}
