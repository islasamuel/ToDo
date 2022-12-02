using Microsoft.EntityFrameworkCore;
using SIslas.ToDo.App.Repository.Extensions;
using SIslas.ToDo.App.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIslas.ToDo.App.Repository
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
            base.OnModelCreating(builder);
        }

        public DbSet<CatEstatusTarea> CatEstatusTareas { get; set; }
        public DbSet<Meta> Metas { get; set; }
        public DbSet<Tarea> Tareas { get; set; }


    }
}
