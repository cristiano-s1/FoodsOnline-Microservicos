using System.ComponentModel.DataAnnotations;

namespace FoodsOnline.Web.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Estoque")]
        public long Stock { get; set; }

        [Display(Name = "Imagem")]
        public string? ImagePath { get; set; }

        public string? CategoryName { get; set; }

        [Display(Name = "Categorias")]
        public int CategoryId { get; set; }
    }
}
