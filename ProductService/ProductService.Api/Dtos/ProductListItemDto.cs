using ProductService.Api.Models;

namespace ProductService.Api.Dtos
{
    public class ProductListItemDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public string HoverImg { get; set; }
        public string CategoryName { get; set; }

        public decimal Price { get; set; }

        public Rating Rating { get; set; }

        public List<ColorOptionDto> ColorOptions { get; set; }



    }
}
