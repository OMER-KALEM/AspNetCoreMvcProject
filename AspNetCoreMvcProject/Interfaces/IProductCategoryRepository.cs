using AspNetCoreMvcProject.Entities;
using System;
using System.Linq.Expressions;

namespace AspNetCoreMvcProject.Interfaces
{
    public interface IProductCategoryRepository : IGenericRepository<ProductCategory>
    {
        ProductCategory GetProductByCategoryId(Expression<Func<ProductCategory, bool>> filter);
    }
}
