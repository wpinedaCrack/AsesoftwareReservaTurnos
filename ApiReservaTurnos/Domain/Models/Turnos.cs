using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiReservaTurnos.Domain.Models
{
    [Table("Turnos")]
    public class Turnos
    {
        [Key]
        public int id_turno { get; set; }

        [Required]
        [ForeignKey("id_servicio")]
        public int id_servicio { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fecha_turno { get; set; }
        [Required]
        public TimeSpan hora_inicio { get; set; }   
        [Required]
        public TimeSpan hora_fin { get; set; }
        [Required]
        [Range(0, 1, ErrorMessage = "El estado debe ser activo o inactivo")]       
        public int estado { get; set; }
        [JsonIgnore]
        public Servicio Servicio { get; set; }
    }
}