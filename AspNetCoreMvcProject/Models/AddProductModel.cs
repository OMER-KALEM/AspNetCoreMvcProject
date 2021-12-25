using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcProject.Models
{
    public class AddProductModel
    {
        [Required(ErrorMessage = "Product Name Cannot Be Empty")]
        public string ProductName { get; set; }
        [Range(1,double.MaxValue,ErrorMessage = "Check Unit Price ")]
        public decimal UnitPrice { get; set; }
        public IFormFile Image { get; set; }
    }
}
