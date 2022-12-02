using Microsoft.EntityFrameworkCore;
using SIslas.ToDo.App.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIslas.ToDo.App.Repository.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<CatEstatusTarea>().HasData(
                new CatEstatusTarea { Id = 1, Descripcion = "Abierta", Activo = true },
                new CatEstatusTarea { Id = 2, Descripcion = "Completada", Activo = true }
            );
        }
    }
}
