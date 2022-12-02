using SIslas.ToDo.App.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIslas.ToDo.App.Repository.IRepositories
{
    public interface IMetaRepository : IDisposable
    {
        Task<List<Meta>> GetAll();
        Meta? GetById(int IdMeta);
        bool FindByNombre(string Nombre);
        Task<bool> ChangeTarea(int IdMeta);
        Task<bool> ChangePorcentaje(int IdMeta);
    }
}
