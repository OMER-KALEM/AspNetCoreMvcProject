using AspNetCoreMvcProject.Contexts;
using AspNetCoreMvcProject.Entities;
using AspNetCoreMvcProject.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreMvcProject.Repositories
{
    public class ProductRepository : EFRepositoryBase<Product>, IProductRepository
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductRepository(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

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

        public void AddCategory(ProductCategory productCategory)
        {
            if (IsProductCategoryNull(productCategory))
            {
                _productCategoryRepository.Add(productCategory);
            }
        }

        public void RemoveCategory(ProductCategory productCategory)
        {
            if (!IsProductCategoryNull(productCategory,out ProductCategory productCategoryData))
            {
                _productCategoryRepository.Remove(productCategoryData);
            }
        }

        public List<Product> GetAllByCategoryId(int categoryId)
        {
            using var context = new UygulamaContext();
            
            return context.Products.Join(context.ProductCategories,
                p => p.ProductId, pc => pc.ProductId,
                (product, productCategory) => new
                {
                    Product = product,
                    ProductCategory = productCategory
                }).Where(I => I.ProductCategory.CategoryId == categoryId).Select(I => new Product
                {
                    ProductId = I.Product.ProductId,
                    ProductName = I.Product.ProductName,
                    UnitPrice = I.Product.UnitPrice,
                    Image = I.Product.Image
                }).ToList();
        }

        private bool IsProductCategoryNull(ProductCategory productCategory)
        {
            return IsProductCategoryNull(productCategory, out ProductCategory productCategoryData);
        }

        private bool IsProductCategoryNull(ProductCategory productCategory, out ProductCategory productCategoryData)
        {
            productCategoryData = _productCategoryRepository.GetProductByCategoryId(
                I => I.CategoryId == productCategory.CategoryId && I.ProductId == productCategory.ProductId);

            return productCategoryData == null;
        }
    }
}
