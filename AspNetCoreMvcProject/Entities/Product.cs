using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcProject.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        [MaxLength(100)]
        public string ProductName { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        public decimal UnitPrice { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
    }
}
