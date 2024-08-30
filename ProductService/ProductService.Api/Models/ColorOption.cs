using System.Text.Json.Serialization;

namespace ProductService.Api.Models
{
    public class ColorOption
    {
        public int Id { get; set; }  // Primary Key
        public string Color { get; set; }
        public string Img { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }  // Foreign Key
        public virtual Product Product { get; set; }  // Navigation Property
    }

    public class ColorOptionDto
    {
        public string Color { get; set; }
        public string Img { get; set; }
        public int Quantity { get; set; }
    }
}
