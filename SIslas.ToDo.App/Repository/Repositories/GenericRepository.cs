using Microsoft.EntityFrameworkCore;
using SIslas.ToDo.App.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIslas.ToDo.App.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDBContext appDBContext;

        public GenericRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public void Add(T data)
        {
            appDBContext.Set<T>().Add(data);
            appDBContext.SaveChanges();
        }

        public void Remove(T data)
        {
            appDBContext.Set<T>().Remove(data);
            appDBContext.SaveChanges();
        }

        public void Update(T data)
        {
            appDBContext.Entry(data).State = EntityState.Modified;
            appDBContext.SaveChanges();
        }
    }
}
