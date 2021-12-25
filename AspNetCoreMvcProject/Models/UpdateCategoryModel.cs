using System.ComponentModel.DataAnnotations;

namespace AspNetCoreMvcProject.Models
{
    public class UpdateCategoryModel
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category Name Cannot Be Empty")]
        public string CategoryName { get; set; }
    }
}
