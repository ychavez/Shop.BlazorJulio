namespace Shop.Blazor.Models
{
    public class Product
    {
        public string Id { get; set; } 
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public int Price { get; set; }
        public string ImageURL { get; set; }

    }
}
