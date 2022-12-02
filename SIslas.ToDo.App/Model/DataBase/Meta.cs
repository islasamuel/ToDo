using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace SIslas.ToDo.App.Model.DataBase
{
    [Table("Metas")]
    public class Meta
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(80)")]
        [Required(ErrorMessage ="El nombre de la meta es requerido")]
        [MaxLength(80,ErrorMessage = "El nombre de la meta no debe ser mayor a {1} caracteres")]
        public string Nombre { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }

        [Column(TypeName = "int")]
        public int TotalTareas { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal PorcentajeCompletada { get; set; }
        [NotMapped]
        [JsonIgnore]
        public int TareasCompletadas { get; set; }

    }
}
