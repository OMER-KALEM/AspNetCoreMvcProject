using AspNetCoreMvcProject.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvcProject.ViewComponents
{
    public class CategoryList : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryList(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {            
            return View(_categoryRepository.GetAll());
        }
    }
}
