namespace ProductService.Api.Models
{
    public class Label
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductLabel> ProductLabels { get; set; }
    }
}
