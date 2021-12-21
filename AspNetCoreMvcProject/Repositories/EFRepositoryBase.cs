using AspNetCoreMvcProject.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreMvcProject.Repositories
{
    public class EFRepositoryBase<T> 
        where T : class, new()
    {
        public void Add(T entity)
        {
            using var context = new UygulamaContext();
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            using var context = new UygulamaContext();
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            using var context = new UygulamaContext();
            return context.Set<T>().ToList();

        }

        public T GetById(int id)
        {
            using var context = new UygulamaContext();
            return context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            using var context = new UygulamaContext();
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }
    }
}
