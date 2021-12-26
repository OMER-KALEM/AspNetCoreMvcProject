using AspNetCoreMvcProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcProject.ViewComponents
{
    public class ProductList : ViewComponent
    {
        private readonly IProductRepository _productRepository;

        public ProductList(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IViewComponentResult Invoke(int? categoryId)
        {
            if (categoryId.HasValue)
            {
                return View(_productRepository.GetAllByCategoryId((int)categoryId));
            }
            return View(_productRepository.GetAll());
        }
    }
}
