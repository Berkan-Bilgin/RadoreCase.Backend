namespace ProductService.Api.Models
{
    public class Rating
    {
        public double Stars { get; set; }
        public int Reviews { get; set; }
        public double Min { get; set; } = 0;
        public double Max { get; set; } = 5;
    }
}
