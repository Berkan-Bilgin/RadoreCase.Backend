namespace ProductService.Api.Models
{
    public class ProductLabel
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int LabelId { get; set; }
        public Label Label { get; set; }
    }
}
