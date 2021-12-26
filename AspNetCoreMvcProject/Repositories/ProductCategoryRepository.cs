using AspNetCoreMvcProject.Contexts;
using AspNetCoreMvcProject.Entities;
using AspNetCoreMvcProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspNetCoreMvcProject.Repositories
{
    public class ProductCategoryRepository : EFRepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategory GetProductByCategoryId(Expression<Func<ProductCategory, bool>> filter)
        {
            using var context = new UygulamaContext();
            return context.ProductCategories.FirstOrDefault(filter);
        }
    }
}
