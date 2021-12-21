using AspNetCoreMvcProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcProject.Controllers
{
    public class HomeController : Controller
    {
        IProductRepository _productRepository;
        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            return View(_productRepository.GetAll());
        }

        public IActionResult ProductDetail(int id)
        {
            //ViewBag.Sepet = HttpContext.Session.GetObject<List<SepetModel>>("sepet");
            ViewBag.Sepet = new object();
            return View(_productRepository.GetById(id));
        }
    }
}
