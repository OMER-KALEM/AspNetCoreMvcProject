using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcProject.Models
{
    public class AddCategoryModel
    {
        [Required(ErrorMessage = "Category Name cannot be empty")]
        public string CategoryName { get; set; }
    }
}
