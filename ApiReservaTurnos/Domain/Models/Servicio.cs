using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System;

namespace ApiReservaTurnos.Domain.Models
{
    [Table("Servicio")]
    public class Servicio
    {
        [Key]
        public int id_Servicio { get; set; }
        [Required]
        [ForeignKey("id_Comercio")]
        public int id_Comercio { get; set; }
        [Required]
        [Column(TypeName = "varchar(60)")]
        public string nom_servicio { get; set; }
        [Required]
        public TimeSpan hora_apertura { get; set; }
        [Required]        
        public TimeSpan hora_cierre { get; set; }
        [Required]
        public int duracion { get; set; }

        #region Propiedades de Navegacion
        [JsonIgnore]
        public Comercio Comercio { get; set; }
        [JsonIgnore]
        public ICollection<Turnos> Turnos { get; set; }
        #endregion      
    }
}
