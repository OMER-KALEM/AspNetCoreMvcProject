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

        public IViewComponentResult Invoke()
        {
            return View(_productRepository.GetAll());
        }
    }
}
