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
    public class MetaRepository : IMetaRepository
    {
        private readonly AppDBContext appDBContext;

        public MetaRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<Meta>> GetAll()
        {
            var metas = await appDBContext.Metas.ToListAsync();
            for (int i = 0; i < metas.Count; i++)
            {
                var tareasCompletadas = await appDBContext.Tareas.Where(x => x.IdMeta == metas[i].Id && x.IdEstatusTarea == 2).ToListAsync();
                metas[i].TareasCompletadas = tareasCompletadas.Count();

            }

            return metas;
        }

        public bool FindByNombre(string Nombre)
        {
            bool result = false;
            var blnExiste = appDBContext.Metas.Where(x => x.Nombre == Nombre).FirstOrDefault();
            result = blnExiste != null ? true : false;
            return result;
        }

        public Meta? GetById(int IdMeta)
        {
            return appDBContext.Metas.Where(x => x.Id == IdMeta).FirstOrDefault();
        }

        public async Task<bool> ChangeTarea(int IdMeta)
        {
            var lstTareas = appDBContext.Tareas.Where(x => x.IdMeta == IdMeta).ToList();
            var filterCompletadas = lstTareas.FindAll(x => x.IdEstatusTarea == 2).ToList();
            var meta = appDBContext.Metas.Where(x => x.Id == IdMeta).AsNoTracking().FirstOrDefault();
            meta.PorcentajeCompletada = (filterCompletadas.Count * 100) / lstTareas.Count;
            meta.TotalTareas = lstTareas.Count;

            appDBContext.Attach(meta);
            appDBContext.Entry(meta).Property(p => p.TotalTareas).IsModified = true;
            appDBContext.Entry(meta).Property(p => p.PorcentajeCompletada).IsModified = true;

            await appDBContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangePorcentaje(int IdMeta)
        {
            var lstTareas = appDBContext.Tareas.Where(x => x.IdMeta == IdMeta).ToList();
            var filterCompletadas = lstTareas.FindAll(x => x.IdEstatusTarea == 2).ToList();
            var meta = appDBContext.Metas.Where(x => x.Id == IdMeta).FirstOrDefault();
            meta.PorcentajeCompletada = (filterCompletadas.Count * 100) / lstTareas.Count;

            appDBContext.Attach(meta);
            appDBContext.Entry(meta).Property(p => p.PorcentajeCompletada).IsModified = true;

            await appDBContext.SaveChangesAsync();
            return true;
        }
    }
}
