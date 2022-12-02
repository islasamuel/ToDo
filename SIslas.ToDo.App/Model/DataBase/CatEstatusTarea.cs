using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SIslas.ToDo.App.Model.DataBase
{
    [Table("CatEstatusTareas")]
    public class CatEstatusTarea
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(80)")]
        public string Descripcion { get; set; }


        [Column(TypeName = "bit")]
        [DefaultValue(true)]
        public bool Activo { get; set; }
    }
}
