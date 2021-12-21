using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcProject.Interfaces
{
    public interface IGenericRepository <T> where T : class,new()
    {
        void Add(T entity);
        void Update(T entity);
        List<T> GetAll();
        T GetById(int id);
        void Remove(T entity);
    }
}
