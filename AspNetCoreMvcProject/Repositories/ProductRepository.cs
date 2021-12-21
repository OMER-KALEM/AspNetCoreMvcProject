using AspNetCoreMvcProject.Contexts;
using AspNetCoreMvcProject.Entities;
using AspNetCoreMvcProject.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreMvcProject.Repositories
{
    public class ProductRepository : EFRepositoryBase<Product>, IProductRepository
    {
    }
}
