using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiReservaTurnos.Domain.Models
{
    [Table("Comercio")]
    public class Comercio
    {
        [Key]
        public int id_comercio { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string nom_comercio { get; set; }

        //[Range(18, 99, ErrorMessage = "")]
        [Required]
        public int aforo_maximo { get; set; }

        public ICollection<Servicio> Servicio { get; set; }
    }
}
