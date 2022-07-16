namespace Shop.Common.Models
{
    public class Product
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public int Price { get; set; } 
        public string ImageURL { get; set; } = null!;

    }
}
