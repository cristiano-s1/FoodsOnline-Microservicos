using FoodsOnline.API.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodsOnline.API.DTOs.Data
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Informar o nome da Categoria")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
