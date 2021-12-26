using AspNetCoreMvcProject.Entities;
using AspNetCoreMvcProject.Interfaces;
using AspNetCoreMvcProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IProductRepository _productRepository;
        public HomeController(IProductRepository productRepository, SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _productRepository = productRepository;
        }

        public IActionResult Index(int? categoryId)
        {
            ViewBag.CategoryId = categoryId;
            return View();
        }

        public IActionResult ProductDetail(int id)
        {
            return View(_productRepository.GetById(id));
        }

        public void SetCookies(string key, string value)
        {
            HttpContext.Response.Cookies.Append(key, value);
        }

        public string GetCookie(string key)
        {
            HttpContext.Request.Cookies.TryGetValue(key, out string value);
            return value;
        }

        public IActionResult LogIn()
        {
            return View(new UserLoginModel());
        }

        [HttpPost]
        public IActionResult LogIn(UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
                var lockoutOnFailure = false;
                var signInResult = _signInManager.PasswordSignInAsync(userLoginModel.UserName, userLoginModel.Password, userLoginModel.RememberMe, lockoutOnFailure).Result;

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                ModelState.AddModelError("", "User name or password error");
            }
            return View(userLoginModel);
        }
    }
}
