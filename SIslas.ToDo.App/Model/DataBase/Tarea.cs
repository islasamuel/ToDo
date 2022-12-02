using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SIslas.ToDo.App.Model.DataBase
{
    [Table("Tareas")]
    public class Tarea
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(80)")]
        [Required(ErrorMessage = "El nombre de la tarea es requerido")]
        [MaxLength(80, ErrorMessage = "El nombre de la tarea no debe ser mayor a {1} caracteres")]
        public string Nombre { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime FechaCreacion { get; set; }

        [Column(TypeName = "int")]
        public int IdMeta { get; set; }

        [Column(TypeName = "int")]
        public int IdEstatusTarea { get; set; }

        [Column(TypeName = "bit")]
        public bool Importante { get; set; }


        [ForeignKey("IdMeta")]
        public Meta? Meta { get; set; }

        [ForeignKey("IdEstatusTarea")]
        public CatEstatusTarea? Estatus { get; set; }


    }
}
