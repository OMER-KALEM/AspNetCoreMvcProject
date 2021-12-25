using AspNetCoreMvcProject.Entities;
using AspNetCoreMvcProject.Interfaces;
using AspNetCoreMvcProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View(_productRepository.GetAll());
        }

        public IActionResult AddProduct()
        {
            return View(new AddProductModel());
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductModel addProductModel)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();
                if (addProductModel.Image != null) //&& addProductModel.Image.ContentType == "image/jpeg"
                {
                    try
                    {
                        var contentType = Path.GetExtension(addProductModel.Image.FileName);
                        var imageName = Guid.NewGuid() + contentType;
                        var toUpload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + imageName);
                        var stream = new FileStream(toUpload, FileMode.Create);
                        addProductModel.Image.CopyTo(stream);
                        product.Image = imageName;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                product.ProductName = addProductModel.ProductName;
                product.UnitPrice = addProductModel.UnitPrice;
                _productRepository.Add(product);

                //return RedirectToAction("Index","Home",new { area="Admin"});
                return RedirectToAction("Index");
            }
            return View(addProductModel);
        }

        public IActionResult UpdateProduct(int id)
        {
            var currentProduct = _productRepository.GetById(id);
            UpdateProductModel updateProductModel = new UpdateProductModel {
                ProductId = currentProduct.ProductId,
                ProductName = currentProduct.ProductName,
                UnitPrice = currentProduct.UnitPrice
            };

            return View(updateProductModel);
        }

        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductModel updateProductModel)
        {
            if (ModelState.IsValid)
            {
                var productToUpdate = _productRepository.GetById(updateProductModel.ProductId);

                if (updateProductModel.Image != null)
                {
                    try
                    {
                        var contentType = Path.GetExtension(updateProductModel.Image.FileName);
                        var imageName = Guid.NewGuid() + contentType;
                        var toUpload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + imageName);
                        var stream = new FileStream(toUpload, FileMode.Create);
                        updateProductModel.Image.CopyTo(stream);
                        productToUpdate.Image = imageName;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                productToUpdate.ProductName = updateProductModel.ProductName;
                productToUpdate.UnitPrice = updateProductModel.UnitPrice;
                _productRepository.Update(productToUpdate);

                return RedirectToAction("Index");
            }

            return View(updateProductModel);
        }
    }
}
