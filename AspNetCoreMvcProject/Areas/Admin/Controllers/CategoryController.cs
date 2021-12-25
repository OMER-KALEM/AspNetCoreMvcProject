using AspNetCoreMvcProject.Entities;
using AspNetCoreMvcProject.Interfaces;
using AspNetCoreMvcProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View(_categoryRepository.GetAll());
        }

        public IActionResult AddCategory()
        {
            return View(new AddCategoryModel());
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryModel addCategoryModel)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.CategoryName = addCategoryModel.CategoryName;
                _categoryRepository.Add(category);
                return RedirectToAction("Index");
            }

            return View(addCategoryModel);
        }

        public IActionResult UpdateCategory(int id)
        {
            var currentCategory = _categoryRepository.GetById(id);
            UpdateCategoryModel updateCategoryModel = new UpdateCategoryModel();
            updateCategoryModel.CategoryId = currentCategory.CategoryId;
            updateCategoryModel.CategoryName = currentCategory.CategoryName;

            return View(updateCategoryModel);
        }

        [HttpPost]
        public IActionResult UpdateCategory(UpdateCategoryModel updateCategoryModel)
        {
            if (ModelState.IsValid)
            {
                Category categoryToUpdate = _categoryRepository.GetById(updateCategoryModel.CategoryId);
                categoryToUpdate.CategoryName = updateCategoryModel.CategoryName;
                _categoryRepository.Update(categoryToUpdate);
                return RedirectToAction("Index");
            }

            return View(new UpdateCategoryModel());
        }
    }
}
