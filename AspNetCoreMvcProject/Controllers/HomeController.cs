using AspNetCoreMvcProject.Interfaces;
using AspNetCoreMvcProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcProject.Controllers
{
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

        public IActionResult ProductDetail(int id)
        {
            return View(_productRepository.GetById(id));
        }

        public void SetCookies(string key, string value) {
            HttpContext.Response.Cookies.Append(key, value);
        }

        public string GetCookie(string key)
        {
            HttpContext.Request.Cookies.TryGetValue(key,out string value);
            return value;
        }

        public IActionResult LogIn()
        {
            return View(new UserLoginModel());
        }

        [HttpPost]
        public IActionResult LogIn(UserLoginModel userLoginModel)
        {
            return View(new UserLoginModel());
        }
    }
}
