using SIslas.ToDo.App.Model;
using SIslas.ToDo.App.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIslas.ToDo.App.Domain.IDomains
{
    public interface ITareaDomain
    {
        Task<Response<List<Tarea>>> GetAllByIdMeta(int IdMeta);
        Task<Response<bool>> Add(Tarea data);
        Response<bool> Update(Tarea data);
        Task<Response<bool>> Remove(int IdTarea);
        Response<bool> SetImportante(Tarea data);
        Task<Response<bool>> CompletarTarea(int IdTarea);
        Response<Tarea> GetById(int IdTarea);


    }
}
