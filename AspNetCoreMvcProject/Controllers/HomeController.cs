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
        private readonly IBasketRepository _basketRepository;
        public HomeController(IProductRepository productRepository, SignInManager<AppUser> signInManager, IBasketRepository basketRepository)
        {
            _signInManager = signInManager;
            _productRepository = productRepository;
            _basketRepository = basketRepository;
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

        public ActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return View("LogIn", new UserLoginModel());
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

        public IActionResult Basket()
        {
            return View(_basketRepository.GetProductFromBasket());
        }

        public IActionResult AddToBasket(int id)
        {
            var product = _productRepository.GetById(id);
            _basketRepository.AddToBasket(product);
            TempData["notification"] = "Product added to basket";

            return RedirectToAction("");
        }

        public IActionResult RemoveBasket(decimal totalPrice)
        {
            _basketRepository.RemoveBasket();
            return RedirectToAction("Thanks",new { totalPrice = totalPrice });
        }
        public IActionResult RemoveFromBasket(int id)
        {
            var productRemove = _productRepository.GetById(id);
            _basketRepository.RemoveFromBasket(productRemove);

            return RedirectToAction("Basket");
        }

        public IActionResult Thanks(decimal totalPrice)
        {
            ViewBag.TotalPrice = totalPrice/100;
            return View();
        }
    }
}
