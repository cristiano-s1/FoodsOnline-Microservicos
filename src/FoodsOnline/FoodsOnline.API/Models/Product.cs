namespace FoodsOnline.API.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public long Stock { get; set; }
        public string? ImagePath { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
