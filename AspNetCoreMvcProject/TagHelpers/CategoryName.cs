using AspNetCoreMvcProject.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvcProject.TagHelpers
{
    [HtmlTargetElement("getCategoryName")]
    public class CategoryName : TagHelper
    {
        public int ProductId { get; set; }
        private readonly IProductRepository _productRepository;
        public CategoryName(IProductRepository productRepository)
        {
             _productRepository = productRepository;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var data = "";
            var categories = _productRepository.GetCategories(ProductId).Select(I=>I.CategoryName);
            foreach (var category in categories)
            {
                data += category + "";
            }

            output.Content.SetContent(data);
        }
    }
}
