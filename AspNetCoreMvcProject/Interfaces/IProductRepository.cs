using AspNetCoreMvcProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcProject.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        List<Category> GetCategories(int productId);
        void AddCategory(ProductCategory productCategory);
        void RemoveCategory(ProductCategory productCategory);
        List<Product> GetAllByCategoryId(int id);
    }
}
