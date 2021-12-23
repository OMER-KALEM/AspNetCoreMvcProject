using AspNetCoreMvcProject.Contexts;
using AspNetCoreMvcProject.Entities;
using AspNetCoreMvcProject.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreMvcProject.Repositories
{
    public class ProductRepository : EFRepositoryBase<Product>, IProductRepository
    {
        public List<Category> GetCategories(int productId)
        {
            using var context = new UygulamaContext();
            return context.Products.Join(
                context.ProductCategories, product => product.ProductId, productCategory => productCategory.ProductId,
                (p, pc) => new
                {
                    product = p,
                    productCategory = pc
                }).Join(context.Categories, combination => combination.productCategory.CategoryId,
                category => category.CategoryId, (pc, c) => new
                {
                    product = pc.product,
                    category = c,
                    productCategory = pc.productCategory
                }).Where(I => I.product.ProductId == productId).Select(I => new Category
                {
                    CategoryName = I.category.CategoryName,
                    CategoryId = I.category.CategoryId
                }).ToList();
        }
    }
}
