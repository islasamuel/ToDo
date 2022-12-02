using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIslas.ToDo.App.Repository.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T data);
        void Update(T data);
        void Remove(T data);
    }
}
