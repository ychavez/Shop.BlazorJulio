using Shop.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace Shop.Blazor.DTO
{
    public class ProductDetailDTO
    {
        public ProductDetailDTO()
        {
            product = new();
            Count = 1;
        }

        public Product product { get; set; } 

        [Range(1,int.MaxValue, ErrorMessage = "por favor agregue un valor menor que 0")]
        public int Count { get; set; }

    }
}
