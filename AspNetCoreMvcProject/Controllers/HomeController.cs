using AspNetCoreMvcProject.Interfaces;
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
            SetCookies("person", "Omer");
            SetSession("person2", "Omer2");
            return View(_productRepository.GetAll());
        }

        public IActionResult ProductDetail(int id)
        {
            ViewBag.Cookie = GetCookie("person");
            ViewBag.Session = GetSession("person2");
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
        
        public void SetSession(string key, string value)
        {
            HttpContext.Session.SetString(key, value);
        }

        public string GetSession(string key)
        {
            return HttpContext.Session.GetString(key);
        }
    }
}
