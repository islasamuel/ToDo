using Microsoft.EntityFrameworkCore;
using SIslas.ToDo.App.Repository.IRepositories;
using SIslas.ToDo.App.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIslas.ToDo.App.Repository.Repositories
{
    public class TareaRepository : ITareaRepository
    {
        private readonly AppDBContext appDBContext;

        public TareaRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<Tarea>> GetAllByIdMeta(int IdMeta)
        {
            return await appDBContext.Tareas
                   .Include(x => x.Estatus)
                  .Where(x => x.IdMeta == IdMeta).ToListAsync();
        }

        public bool FindByNombre(string Nombre, int IdMeta)
        {
            bool result = false;
            var blnExiste = appDBContext.Tareas.Where(x => x.Nombre == Nombre && x.IdMeta == IdMeta).FirstOrDefault();
            result = blnExiste != null ? true : false;
            return result;
        }

        public Tarea? GetById(int Id)
        {
            return appDBContext.Tareas.Where(x => x.Id == Id).FirstOrDefault();
        }

    }
}
