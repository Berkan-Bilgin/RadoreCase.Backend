using ProductService.Api.Models;

namespace ProductService.Api.Dtos
{
    public class ProductCreateDto
    {
        public int CategoryId { get; set; }
        public IFormFile Img { get; set; } // Dosya yüklemeleri için IFormFile
        public string HoverImg { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public double Stars { get; set; }
        public int Reviews { get; set; }
        public List<ColorOptionDto> ColorOptions { get; set; }

    }
}
