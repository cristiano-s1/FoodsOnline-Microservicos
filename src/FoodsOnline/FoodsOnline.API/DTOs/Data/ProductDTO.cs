using FoodsOnline.API.Models;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace FoodsOnline.API.DTOs.Data
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Informar o nome do produto")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Informar o preço do produto")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Informar a descrição do produto")]
        [MinLength(5)]
        [MaxLength(200)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Informar o estoque do produto")]
        [Range(1, 9999)]
        public long Stock { get; set; }

        public string? ImagePath { get; set; }

        public string? CategoryName { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }

        public int CategoryId { get; set; }
    }
}
