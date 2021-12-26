using AspNetCoreMvcProject.CustomExtensions;
using AspNetCoreMvcProject.Entities;
using AspNetCoreMvcProject.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcProject.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasketRepository(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void AddToBasket(Product product)
        {
            var basketList =_httpContextAccessor.HttpContext.Session.GetObject<List<Product>>("basket");
            
            if (basketList == null)
            {
                basketList = new List<Product>();
                basketList.Add(product);
            }
            else
            {
                basketList.Add(product);
            }

            _httpContextAccessor.HttpContext.Session.SetObject("basket", basketList);
        }

        public void RemoveFromBasket(Product product)
        {
            var basketList = _httpContextAccessor.HttpContext.Session.GetObject<List<Product>>("basket");
            basketList.Remove(product);
            _httpContextAccessor.HttpContext.Session.SetObject("basket", basketList);
        }

        public List<Product> GetProductFromBasket()
        {
            return _httpContextAccessor.HttpContext.Session.GetObject<List<Product>>("basket");
        }

        public void RemoveBasket()
        {
            _httpContextAccessor.HttpContext.Session.Remove("basket");
        }
    }
}
