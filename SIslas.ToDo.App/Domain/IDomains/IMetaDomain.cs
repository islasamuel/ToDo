using SIslas.ToDo.App.Model;
using SIslas.ToDo.App.Model.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIslas.ToDo.App.Domain.IDomains
{
    public interface IMetaDomain
    {
        Task<Response<List<Meta>>> GetAll();
        Response<bool> Add(Meta data);
        Response<bool> Update(Meta data);
        Response<bool> Remove(int IdMeta);
    }
}
