using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcProject.Entities
{
    [Table("Products")]
    public class Product : IEquatable<Product>
    {
        public int ProductId { get; set; }
        [MaxLength(100)]
        public string ProductName { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        public decimal UnitPrice { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }

        public bool Equals([AllowNull] Product other)
        {
            return ProductId == other.ProductId && ProductName == other.ProductName &&
                Image == other.Image && UnitPrice == other.UnitPrice;
        }
    }
}
