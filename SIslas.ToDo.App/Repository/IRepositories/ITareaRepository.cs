using SIslas.ToDo.App.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIslas.ToDo.App.Repository.IRepositories
{
    public interface ITareaRepository : IDisposable
    {
        Task<List<Tarea>> GetAllByIdMeta(int IdMeta);
        Tarea? GetById(int Id);
        bool FindByNombre(string Nombre, int IdMeta);
    }
}
