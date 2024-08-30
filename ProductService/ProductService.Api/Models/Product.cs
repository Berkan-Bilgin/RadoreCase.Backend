namespace ProductService.Api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Img { get; set; }
        public string HoverImg { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public Rating Rating { get; set; }
        public List<ColorOption> ColorOptions { get; set; }


        public Category Category { get; set; }
        public List<ProductLabel> ProductLabels { get; set; }

    }
}
