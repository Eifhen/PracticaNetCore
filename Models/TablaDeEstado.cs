using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaMigracion.Models
{
    [Table("TablaDeEstado")]
    public class TablaDeEstado
	{
        [Key]
        public int ID { get; set; }

        [Required]
        public string NombreEstado { get; set; }

        [Required]
        public DateTime FechaDeCreacion { get; set; }

    }
}
