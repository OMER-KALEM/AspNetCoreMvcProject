using AspNetCoreMvcProject.Entities;
using System.Collections.Generic;

namespace AspNetCoreMvcProject.Interfaces
{
    public interface IBasketRepository
    {
        void AddToBasket(Product product);
        void RemoveFromBasket(Product product);
        List<Product> GetProductFromBasket();
        void RemoveBasket();
    }
}
